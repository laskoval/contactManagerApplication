using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Ch4Lab.Models;

public class Contact
{
    public int ContactId { get; set; }
[Required(ErrorMessage = "The First Name field is required. ")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "The Last Name field is required. ")]
    public string? LastName { get; set; }

     [Required(ErrorMessage = "The Phone field is required. ")]
    public string? Phone { get; set; }

     [Required(ErrorMessage = "The EMail field is required. ")]
    public string? EMail { get; set; }
   
    public string? Organization { get; set; }

    public char CategoryCode { get; set; }
    public Category? Category { get; set; }

    public DateTime DateCreated { get; set; }


}