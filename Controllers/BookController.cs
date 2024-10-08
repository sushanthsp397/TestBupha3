using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestBupha3.Data_Repo;
using TestBupha3.Models;

namespace TestBupha3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        [HttpGet("adults")]
        public ActionResult<IEnumerable<Book>> GetBooksOwnedByAdults()
        {
            var books = Data.Books.Where(b => b.Owner.IsAdult).ToList();
            return Ok(books);
        }

        [HttpGet("children")]
        public ActionResult<IEnumerable<Book>> GetBooksOwnedByChildren()
        {
            var books = Data.Books.Where(b => !b.Owner.IsAdult).ToList();
            return Ok(books);
        }

        [HttpPost]
        public ActionResult<Book> PostBook([FromBody] Book book)
        {
            var owner = Data_Repo.Data.Owners.FirstOrDefault(o => o.Id == book.OwnerId);
            if (owner == null)
            {
                return BadRequest("Owner not found.");
            }

            book.Id = Data.Books.Count + 1;
            book.Owner = owner;
            owner.Books.Add(book);
            Data.Books.Add(book);

            return CreatedAtAction(nameof(GetBooksOwnedByAdults), new { id = book.Id }, book);
        }
    }
}
