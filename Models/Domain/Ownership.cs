namespace HousingManagementService.Models.Domain;

public class Ownership
{
    public int Id { get; set; }
    
    public int LodgerId { get; set; }
    public Lodger Lodger { get; set; }
    public int FlatId { get; set; }
    public Flat Flat { get; set; }
    public int OwnedArea { get; set; }
}