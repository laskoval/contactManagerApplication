using Microsoft.EntityFrameworkCore;

namespace Ch4Lab.Models;

public class ContactManagerContext : DbContext 
{
    public DbSet<Contact> Contacts { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    public ContactManagerContext(DbContextOptions<ContactManagerContext> options) : base (options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mapping.
        var contact = modelBuilder.Entity<Contact>();
        contact.HasKey(p => p.ContactId);
        contact.Property(p => p.DateCreated).HasDefaultValueSql("GETUTCDATE()");
        contact.HasOne(p => p.Category)
            .WithMany(c => c.Contacts)
            .HasForeignKey(p => p.CategoryCode)
            .IsRequired();

        var category = modelBuilder.Entity<Category>();
        category.HasKey(p => p.CategoryCode);

        // Seed Data.
        contact.HasData(
            new Contact() { ContactId = 1001, CategoryCode = 'D', Phone = "(123)456-7890", FirstName = "Petruta", LastName = "Lipan", EMail = "lipanp@slu.edu", Organization = "University Museums & Galleries" },
            new Contact() { ContactId = 1002, CategoryCode = 'X', Phone = "(123)456-8907", FirstName = "Jack", LastName = "Laman", EMail = "jlaman@slu.edu", Organization = null },
            new Contact() { ContactId = 1003, CategoryCode = 'A', Phone = "(123)456-9078", FirstName = "Laura", LastName = "Johnson", EMail = "ljohnson@slu.edu", Organization = "University Museums & Galleries" },
            new Contact() { ContactId = 1004, CategoryCode = 'S', Phone = "(123)456-0789", FirstName = "Anna", LastName = "Verhoff", EMail = "averhoff@slu.edu", Organization = "University Museums & Galleries" }
        );
        category.HasData(
            new Category() { CategoryCode = 'X', Description = "None" },
            new Category() { CategoryCode = 'A', Description = "Administrator" },
            new Category() { CategoryCode = 'D', Description = "Director" },
            new Category() { CategoryCode = 'M', Description = "Manager" },
            new Category() { CategoryCode = 'S', Description = "Specialist" },
            new Category() { CategoryCode = 'L', Description = "Analyst" }
        );
    }
}