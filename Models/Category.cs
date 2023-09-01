namespace Ch4Lab.Models;

public class Category
{
    public char CategoryCode { get; set; }

    public string? Description { get; set; }

    public List<Contact>? Contacts { get; set; }
}