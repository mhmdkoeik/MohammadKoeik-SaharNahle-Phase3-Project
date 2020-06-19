using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LMS.Models;

namespace LMS.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/books
        public IEnumerable<Book> GetBooks(string query )
        {
            var booksQuery = _context.Books;

            return booksQuery.ToList();
        }

        // GET api/books/1
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.ID == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST api/books/create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult CreateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var books = book; 
            _context.Books.Add(books);
            _context.SaveChanges();

            books.ID = book.ID;
            return Created(new Uri(Request.RequestUri + "/" + books.ID), book);
        }

        // PUT api/books/update/1
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult UpdateBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bookInDb = _context.Books.SingleOrDefault(c => c.ID == id);

            if (bookInDb == null)
            {
                return NotFound();
            }

            book = bookInDb;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/books/1
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(c => c.ID == id);

            if (bookInDb == null)
            {
                return NotFound();
            }

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}