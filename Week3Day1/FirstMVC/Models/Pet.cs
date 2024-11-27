#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FirstMVC.Models;

public class Pet
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Species { get; set; }
    public bool IsFriendly { get; set; }
    [Required]
    public int Age { get; set; }
}