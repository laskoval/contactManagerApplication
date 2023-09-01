namespace Ch4Lab.Models;

public class Contact
{
    public int ContactId { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? EMail { get; set; }
    public string? Organization { get; set; }


    public char CategoryCode { get; set; }
    public Category? Category { get; set; }

    public DateTime DateCreated { get; set; }
}