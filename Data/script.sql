-- Вспомогательные функции
CREATE OR REPLACE FUNCTION get_current_services(plotId int) RETURNS text[] AS
$$
DECLARE
    result text[];
BEGIN
    SELECT array_agg(s."Name")
    INTO result
    FROM "DepartmentPlots" dp
             JOIN "Departments" d ON dp."DepartmentId" = d."Id"
             JOIN "Services" s ON d."ServiceId" = s."Id"
    WHERE dp."PlotId" = plotId;

    RETURN result;
END
$$ LANGUAGE plpgsql;


CREATE OR REPLACE VIEW "LodgersView" AS
SELECT *
FROM "Lodgers";

CREATE OR REPLACE VIEW "PlotsView" AS
SELECT *
FROM "Plots";

CREATE OR REPLACE VIEW "DepartmentsView" AS
SELECT *
FROM "Departments";

CREATE OR REPLACE VIEW "DepartmentPlotsView" AS
SELECT *
FROM "DepartmentPlots";

CREATE OR REPLACE VIEW "HousesView" AS
SELECT *
FROM "Houses";

CREATE OR REPLACE VIEW "ServicesView" AS
SELECT *
FROM "Services";

CREATE OR REPLACE VIEW "FlatsView" AS
SELECT *
FROM "Flats";

CREATE OR REPLACE VIEW "OwnershipsView" AS
SELECT *
FROM "Ownerships";

CREATE OR REPLACE VIEW "RatesView" AS
SELECT *
FROM "Rates";

CREATE OR REPLACE VIEW "OwnershipsView2" AS
SELECT o."FlatId", l."LodgerPassport"
FROM "Ownerships" o
         JOIN "Lodgers" l ON l."Id" = o."LodgerId";
--  

-- Отчет 1, Квартплата, последнее представление - содержимое отчета, первые 2 - вспомогательные
CREATE OR REPLACE VIEW "TotalSumsOfRates" AS
SELECT h."Id",
       SUM(r."ConstantPricePerMonth") AS "ConstPrice",
       SUM(r."PricePerSquareMeter")   AS "MeterPrice"
FROM "Houses" h
         JOIN "Rates" r ON h."Id" = r."HouseId"
GROUP BY h."Id";

CREATE OR REPLACE VIEW "ExtensionsForFlats" AS
SELECT f."Id" as "FlatId",
       h."Id" AS "HouseId",
       h."Address",
       f."Number",
       f."TotalArea",
       l."FeePercent"
FROM "Flats" f
         JOIN "Houses" h ON f."HouseId" = h."Id"
         JOIN "Ownerships" o ON f."Id" = o."FlatId"
         JOIN "Lodgers" l ON o."LodgerId" = l."Id";

CREATE OR REPLACE VIEW "Rents" AS
SELECT ef."FlatId",
       ef."Address"                                                                 as "HouseAddress",
       ef."Number"                                                                  as "FlatNumber",
       (ts."ConstPrice" + ts."MeterPrice" * ef."TotalArea") * ef."FeePercent" / 100 AS "Rent"
FROM "ExtensionsForFlats" ef
         JOIN "TotalSumsOfRates" ts ON ef."HouseId" = ts."Id";

SELECT count(*)
FROM "Services";
SELECT dp."PlotId", count(*)
FROM "DepartmentPlots" dp
GROUP BY dp."PlotId";


-- Втрой отчет - выручка отедлов
CREATE OR REPLACE VIEW "DepartmentsRevenue" AS
SELECT r."DepartmentId",
       d."Name"                                                                                           as "DepartmentName",
       s."Id"                                                                                             AS "ServiceId",
       s."Name"                                                                                           as "ServiceName",
       count(f."Id")                                                                                      as "FlatsCount",
       sum((r."ConstantPricePerMonth" + r."PricePerSquareMeter" * f."TotalArea") * pc."FeePercent" / 100) as "Revenue"
FROM "Rates" r
         JOIN "Flats" f ON r."HouseId" = f."HouseId"
         JOIN "Departments" d ON r."DepartmentId" = d."Id"
         JOIN "Services" s ON d."ServiceId" = s."Id"
         JOIN "Ownerships" o on f."Id" = o."FlatId"
         JOIN "Lodgers" pc ON o."LodgerId" = pc."Id"
GROUP BY 1, 2, 3, 4;

-- Третий отчет - список жильцов на избирательный участок
CREATE OR REPLACE VIEW "LodgersPlots" AS
SELECT DISTINCT p."Id" as "PlotId",
                CONCAT(l."MiddleName", ' ', l."FirstName", ' ', l."LastName") as "FullName",
                l."LodgerPassport"
FROM "Lodgers" l
         JOIN "Ownerships" o ON l."Id" = o."LodgerId"
         JOIN "Flats" f ON o."FlatId" = f."Id"
         JOIN "Houses" h ON f."HouseId" = h."Id"
         JOIN "Plots" p ON h."PlotId" = p."Id";

-- ТРИГГЕРЫ
-- Запрет на обслуживание несколькими отедлами одной службы одного участка
CREATE OR REPLACE FUNCTION check_department_service_plot()
    RETURNS TRIGGER
    LANGUAGE plpgsql
AS
$$
BEGIN
    IF EXISTS (SELECT 1
               FROM "DepartmentPlots" dp
                        JOIN "Departments" d ON dp."DepartmentId" = d."Id"
               WHERE dp."PlotId" = NEW."PlotId"
                 AND d."ServiceId" = (SELECT "ServiceId" FROM "Departments" WHERE "Id" = NEW."DepartmentId")
                 AND dp."Id" != NEW."Id") THEN
        RAISE EXCEPTION 'This plot is already serviced by another department of the same service.';
    END IF;

    RETURN NEW;
END;
$$;
CREATE OR REPLACE TRIGGER trg_check_department_service_plot
    BEFORE INSERT OR UPDATE
    ON "DepartmentPlots"
    FOR EACH ROW
EXECUTE FUNCTION check_department_service_plot();

-- Проверка требования для тарифа, что дом есть на учаскте, который обсулживает отдел
CREATE OR REPLACE FUNCTION check_rate_department_plot_relation()
    RETURNS TRIGGER
    LANGUAGE plpgsql
AS
$$
BEGIN
    IF NOT EXISTS (SELECT 1
                   FROM "DepartmentPlots" dp
                            JOIN "Houses" h ON h."PlotId" = dp."PlotId"
                   WHERE h."Id" = NEW."HouseId"
                     AND dp."DepartmentId" = NEW."DepartmentId") THEN
        RAISE EXCEPTION 'Дом находится на участке, который не обслуживается данным отделом';
    END IF;

    RETURN NEW;
END;
$$;

CREATE OR REPLACE TRIGGER trg_check_rate_department_plot_relation
    BEFORE INSERT OR UPDATE
    ON "Rates"
    FOR EACH ROW
EXECUTE FUNCTION check_rate_department_plot_relation();


-- Триггер для случайного распределения отделов для нового участка
CREATE OR REPLACE FUNCTION assign_random_departments_to_plot()
    RETURNS TRIGGER AS
$$
DECLARE
    service_id INTEGER;
    department_id INTEGER;
BEGIN
    FOR service_id IN (SELECT "Id" FROM "Services")
        LOOP
            SELECT "Id" INTO department_id
            FROM "Departments"
            WHERE "ServiceId" = service_id
            ORDER BY random()
            LIMIT 1;
            
            INSERT INTO "DepartmentPlots" ("PlotId", "DepartmentId")
            VALUES (NEW."Id", department_id);
        END LOOP;

    RETURN NEW;
END;
$$
    LANGUAGE plpgsql;

CREATE TRIGGER trg_assign_random_departments
    AFTER INSERT
    ON "Plots"
    FOR EACH ROW
EXECUTE FUNCTION assign_random_departments_to_plot();




