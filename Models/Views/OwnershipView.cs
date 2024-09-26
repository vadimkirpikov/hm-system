namespace HousingManagementService.Models.Views;

public class OwnershipView
{
    public int Id { get; set; }
    
    public int LodgerId { get; set; }
    public int FlatId { get; set; }
    public int OwnedArea { get; set; }
}