#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace loginRegDemo.Models;


public class User 
{
    [Key]
    public int UserId {get;set;}
    [Required]
    [MinLength(2,ErrorMessage ="Username must be at least 2 characters")]
    public string Username  {get;set;}
    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email  {get;set;}
    [Required]
    [MinLength(8,ErrorMessage =" Password must be at least 8 characters")]
    [DataType(DataType.Password)]
    public string Password  {get;set;}
    [Display(Name ="Do you want to Subscribe to our Blog ?")]
    public bool Subscribe  {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password")]
    [Display(Name ="Confirm Password")]
    public string Confirm  {get;set;}
}


public class UniqueEmailAttribute : ValidationAttribute

{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return new ValidationResult("Email is required");

        }
        //~ this is our connection to the database 
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        if(_context.Users.Any(e=> e.Email == value.ToString()))
        {
            //!if it matches, this is a problem, throw an Error
            return new ValidationResult("Email must be unique!");
        }else {
            //! we pass validation
            return ValidationResult.Success;
        }
    }
}