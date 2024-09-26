using AutoMapper;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;

namespace HousingManagementService.Mappings;

public class DtoMapperR: Profile
{
    public DtoMapperR()
    {
        CreateMap<DepartmentDto, Department>();
        CreateMap<DepartmentPlotDto, DepartmentPlot>();
        CreateMap<FlatDto, Flat>();
        CreateMap<HouseDto, House>();
        CreateMap<LodgerDto, Lodger>();
        CreateMap<OwnershipDto, Ownership>();
        CreateMap<PayerCodeDto, PayerCode>();
        CreateMap<PlotDto, Plot>();
        CreateMap<RateDto, Rate>();
        CreateMap<ServiceDto, Service>();
    }
}