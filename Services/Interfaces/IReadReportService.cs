namespace HousingManagementService.Services.Interfaces;

public interface IReadReportService<TView>
{
    Task<IEnumerable<TView>> ReadAsync(string? filter=null, string? orderBy=null);
}