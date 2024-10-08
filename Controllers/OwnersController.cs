using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestBupha3.Data_Repo;
using TestBupha3.Models;

namespace TestBupha3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        // Get all owners with children books
        [HttpGet("children-books")]
        public ActionResult<IEnumerable<Owner>> GetOwnersWithChildrenBooks()
        {
            var owners = Data.Owners.Where(o => o.Books.Any(b => b.Type == BookType.ChildrenBook)).ToList();
            return Ok(owners);
        }

        // Get all owners with adult books
        [HttpGet("adult-books")]
        public ActionResult<IEnumerable<Owner>> GetOwnersWithAdultBooks()
        {
            var owners = Data.Owners.Where(o => o.Books.Any(b => b.Type == BookType.AdultBook)).ToList();
            return Ok(owners);
        }


        // POST: api/owners/add-owner
        [HttpPost("add-owner")]
        public ActionResult<Owner> PostOwner([FromBody] Owner owner)
        {
            // Validate input
            if (owner == null || string.IsNullOrWhiteSpace(owner.Name) || owner.Age < 0)
            {
                return BadRequest("Invalid data.");
            }

            // Assign a new ID to the owner
            owner.Id = Data.Owners.Count + 1; // Generating a new ID
            owner.Books = new List<Book>(); // Initialize the book list as empty

            // Add the owner to the in-memory list
          Data.Owners.Add(owner);

            // Return the created owner with a 201 Created status
            return CreatedAtAction(nameof(PostOwner), new { id = owner.Id }, owner);
        }

        // Add book to an existing owner
        [HttpPost("{ownerId}/add-book")]
        public ActionResult<Book> AddBookToOwner(int ownerId, [FromBody] Book newBook)
        {
            var owner = Data.Owners.FirstOrDefault(o => o.Id == ownerId);
            if (owner == null)
            {
                return NotFound("Owner not found.");
            }

            newBook.Id = Data.Books.Count + 1;
            newBook.Owner = owner;
            newBook.OwnerId = ownerId;

            // Add the book to the owner and update the global book list
            owner.Books.Add(newBook);
            Data.Books.Add(newBook);

            return CreatedAtAction(nameof(AddBookToOwner), new { id = newBook.Id }, newBook);
        }
    }

}
