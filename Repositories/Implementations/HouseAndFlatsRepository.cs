using HousingManagementService.Data;
using HousingManagementService.Models.Domain;
using HousingManagementService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Implementations;

public class HouseAndFlatsRepository(HousingManagementDbContext context, IHousesRepository  housesRepository, IFlatsRepository flatsRepository): IHouseAndFlatsRepository
{
    public async Task AddHouseWithFlatsAsync(House house, List<Flat> flats)
    {
        await using var transaction = await context.Database.BeginTransactionAsync();
        await housesRepository.AddAsync(house);
        var addedHouse = await context.Houses.SingleOrDefaultAsync(h => h.Address.Equals(house.Address));
        flats.ForEach(flat => flat.HouseId = addedHouse!.Id);
        await flatsRepository.AddFlatsToHouseAsync(flats);
        await transaction.CommitAsync();
    }
}