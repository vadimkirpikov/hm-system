using HousingManagementService.Controllers.Base;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers.DerivedFromBase;

[ApiController]
[Route("suitability-of-plots")]
public class SuitabilitiesOfPlotsController(IReadReportService<SuitabilityOfPlot> readReportService) : BaseReportsController<SuitabilityOfPlot>(readReportService);