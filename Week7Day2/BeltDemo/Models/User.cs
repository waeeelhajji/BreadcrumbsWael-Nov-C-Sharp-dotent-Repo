#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BeltDemo.Models;
public class User
{
    [Key]
    public int UserId { get; set; }
    [Required(ErrorMessage ="Email is required")]
    [EmailAddress]
    public string Email { get; set; } 
    [Required(ErrorMessage ="Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [NotMapped]
    [Required(ErrorMessage ="Password need to matched")]
    [DataType(DataType.Password)]
    [Display(Name ="Confirm Password")]
    public string Confirm { get; set; }
}

