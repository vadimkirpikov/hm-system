using HousingManagementService.Data;
using HousingManagementService.Models.Domain;
using HousingManagementService.Repositories.Base.Abstractions;
using HousingManagementService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Implementions;

public class HouseAndFlatsRepository(HousingManagementDbContext context, ICreateRepository<House> housesRepository, IBulkInsertRepository<Flat> flatsRepository): IHouseAndFlatsRepository
{
    public async Task AddHouseWithFlatsAsync(House house, List<Flat> flats)
    {
        await using var transaction = await context.Database.BeginTransactionAsync();
        await housesRepository.AddAsync(house);
        var addedHouse = await context.Houses.SingleOrDefaultAsync(h => h.Address.Equals(house.Address));
        flats.ForEach(flat => flat.HouseId = addedHouse!.Id);
        await flatsRepository.BulkInsertAsync(flats);
        await transaction.CommitAsync();
    }
}