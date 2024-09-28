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

CREATE OR REPLACE FUNCTION get_remaining_services(plotId int) RETURNS text[] AS
$$
DECLARE
    result text[];
BEGIN
    SELECT array_agg("Name")
    INTO result
    FROM "Services"
    WHERE "Name" NOT IN (SELECT unnest(get_current_services(plotId)));
    RETURN result;
end
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
       pc."FeePercent"
FROM "Flats" f
         JOIN "Houses" h ON f."HouseId" = h."Id"
         JOIN "Ownerships" o ON f."Id" = o."FlatId"
         JOIN "PayerCodes" pc ON o."LodgerId" = pc."LodgerId";
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


-- ALTER TABLE "Rates"
--     ADD CONSTRAINT house_check CHECK ( "HouseId" IN (SELECT "Id"
--                                                      FROM "Houses"
--                                                      WHERE "PlotId" IN (SELECT dp."PlotId"
--                                                                         FROM "DepartmentPlots" dp
--                                                                         WHERE "DepartmentId" = "Rates"."DepartmentId")));

-- Втрой отчет - выручка отедлов
CREATE OR REPLACE VIEW "DepartmentsRevenue" AS
SELECT r."DepartmentId",
       d."Name"                                                                                           as "DepartmentName",
       s."Id" AS "ServiceId",
       s."Name"                                                                                           as "ServiceName",
       count(f."Id")                                                                                      as "FlatsCount",
       sum((r."ConstantPricePerMonth" + r."PricePerSquareMeter" * f."TotalArea") * pc."FeePercent" / 100) as "Revenue"
FROM "Rates" r
         JOIN "Flats" f ON r."HouseId" = f."HouseId"
         JOIN "Departments" d ON r."DepartmentId" = d."Id"
         JOIN "Services" s ON d."ServiceId" = s."Id"
         JOIN "Ownerships" o on f."Id" = o."FlatId"
         JOIN "PayerCodes" pc ON o."LodgerId" = pc."LodgerId"
GROUP BY 1, 2,3, 4;

-- Третий отчет - участки с неполной комплектацией
CREATE OR REPLACE VIEW "SuitabilityOfPlots" AS
WITH qwe AS (SELECT count(*) as c FROM "Services")
SELECT dp."PlotId",
       p."PriorityLevel",
       p."Budget",
       (SELECT c from qwe) - count(*)      AS "RemainingServicesCount",
       get_remaining_services(dp."PlotId") AS "RemainingServices"
FROM "DepartmentPlots" dp
         JOIN "Plots" p ON dp."PlotId" = p."Id"
GROUP BY 1, 2, 3
HAVING abs((SELECT c FROM qwe) - count(*)) <> 0;

