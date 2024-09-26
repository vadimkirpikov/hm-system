using AutoMapper;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;

namespace HousingManagementService.Mappings;

public class ViewMapper: Profile
{
    public ViewMapper()
    {
        CreateMap<Department, DepartmentView>();
        CreateMap<DepartmentPlot, DepartmentPlotView>();
        CreateMap<Flat, FlatView>();
        CreateMap<House, HouseView>();
        CreateMap<Lodger, LodgerView>();
        CreateMap<Ownership, OwnershipView>();
        CreateMap<PayerCode, PayerCodeView>();
        CreateMap<Plot, PlotView>();
        CreateMap<Rate, RateView>();
        CreateMap<Service, ServiceView>();
    }
}