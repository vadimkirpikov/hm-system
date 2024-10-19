using HousingManagementService.Controllers.Base;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers.DerivedFromBase;

[ApiController]
[Route("lodger-plots")]
public class LodgersPlotsController(IReadReportService<LodgerPlot> readReportService) : BaseReportsController<LodgerPlot>(readReportService);