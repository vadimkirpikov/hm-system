using HousingManagementService.Controllers.Base;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers.DerivedFromBase;

[ApiController]
[Route("departments-revenue")]
public class DepartmentsRevenueController(IReadReportService<DepartmentRevenue> readReportService): BaseReportsController<DepartmentRevenue>(readReportService);