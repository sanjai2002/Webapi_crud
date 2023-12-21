using System.ComponentModel.DataAnnotations;
namespace DeleteApi.Models;
public class UserModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? EmailId { get; set; }
    [Required]
    public string? Password { get; set; }
}