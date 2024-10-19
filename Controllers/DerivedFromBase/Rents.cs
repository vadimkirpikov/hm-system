using HousingManagementService.Controllers.Base;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers.DerivedFromBase;

[ApiController]
[Route("rents")]
public class RentsController(IReadReportService<RentView> readReportService)
    : BaseReportsController<RentView>(readReportService);