using BooksAsync.API.Filters;
using BooksAsync.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAsync.API.Controllers
{
    [ApiController]
    [Route("api/synchronousbooks")]
    public class SynchronousBooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public SynchronousBooksController(IBooksRepository repo)
        {
            _booksRepository = repo;
        }

        [HttpGet]
        [BooksResultFilter]
        public IActionResult GetBooks()
        {
            var bookEntities = _booksRepository.GetBooks();
            return Ok(bookEntities);
        }
    }
}
