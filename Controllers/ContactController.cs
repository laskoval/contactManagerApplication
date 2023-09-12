using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ch4Lab.Models;
using Microsoft.EntityFrameworkCore;

namespace Ch4Lab.Controllers;

public class ContactController : Controller
{
     private readonly ContactManagerContext _db;
    private readonly ILogger<ContactController> _logger;

    public ContactController(ContactManagerContext db, ILogger<ContactController> logger)
    {
        _db = db;
        _logger = logger;
    }

// This function is used to display a list of contacts
    [HttpGet]
    public IActionResult Index()
    {
        var contact = _db.Contacts
        .Include(c => c.Category)
        .OrderBy(m => m.FirstName)
        .ToList();
       
        return View(contact);
    }
// This function is used to display a form for adding a new contact
  [HttpGet]
public IActionResult Add()
{
    var categories = _db.Categories.ToList();
    ViewBag.Categories = categories;
    
    return View("Edit", new Contact());
}

[HttpPost]
public IActionResult Add(Contact contact)
{

    return RedirectToAction("Index");
}

//This function is used to display a form to edite the existing contact
[HttpGet]
 public IActionResult Edit(int id)
    { 
    var contact = _db.Contacts.Include(c => c.Category).SingleOrDefault(c => c.ContactId == id);
    if (contact == null)
    {
      return NotFound();
    }

    var categories = _db.Categories.ToList();
    ViewBag.Categories = categories;

      return View("Edit", contact);
    }
//This function is used to handle the form submission while editing or adding a contact
[HttpPost]
public IActionResult Edit(Contact contact)
{
    if (!ModelState.IsValid)
    {
        var categories = _db.Categories.ToList();
        ViewBag.Categories = categories;
        return View("Edit", contact);
    }

    if (contact.ContactId == 0)
     {
        _db.Contacts.Add(contact);
        _db.SaveChanges();
       return RedirectToAction("Index");
     }
    else
     {
        _db.Contacts.Update(contact);
        _db.SaveChanges(); 
        return RedirectToAction("Details", new { id = contact.ContactId });
     }

        }

// This function is used to display the details of a certain contact
[HttpGet]
    public IActionResult Details(int id)
{
    var contact = _db.Contacts.Include(c => c.Category)
    .SingleOrDefault(c => c.ContactId == id);
     
     if (contact == null)
    {
        return NotFound();
    }

    return View(contact);
}

// This function is used to display the delete confirmation page for a contact
[HttpGet]
 public IActionResult Delete(int? id)
 {
    if (id == null)
    {
        return NotFound();
    }
        var contact = _db.Contacts
        .Include(c => c.Category)
        .FirstOrDefault(c => c.ContactId == id);

    if (contact == null)
    {
        return NotFound();
    }

    return View("DeleteConfirmation", contact);
        }
// This function is used to handle the deleting of contact
[HttpPost]
public IActionResult Delete(int id)
        {
            var contact = _db.Contacts.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

            _db.Contacts.Remove(contact);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
