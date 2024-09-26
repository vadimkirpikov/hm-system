using System.ComponentModel.DataAnnotations;

namespace HousingManagementService.Models.Views;

public class PayerCodeView
{
    public int Id { get; set; }
    public int LodgerId { get; set; }
    public int FeePercent { get; set; }
    public int Duty { get; set; }
}