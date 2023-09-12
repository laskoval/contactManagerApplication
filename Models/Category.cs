namespace Ch4Lab.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Category
{
    public char CategoryCode { get; set; }

    public string? Description { get; set; }

    public List<Contact>? Contacts { get; set; }
}