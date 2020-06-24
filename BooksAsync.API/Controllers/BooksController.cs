using AutoMapper;
using BooksAsync.API.Filters;
using BooksAsync.API.Models;
using BooksAsync.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAsync.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksController(IBooksRepository repo, IMapper mapper)
        {
            _booksRepository = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [BooksResultFilter]
        public async Task<IActionResult> GetBooks()
        {
            var bookEntities = await _booksRepository.GetBooksAsync();
            return Ok(bookEntities);
        }

        [HttpGet]
        [Route("{id}", Name = "GetBook")]
        [BookResultFilter]
        public async Task<IActionResult> GetBooks(Guid id)
        {
            var bookEntity = await _booksRepository.GetBookAsync(id);
            if (bookEntity == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(bookEntity);
            }
        }

        [HttpPost]
        [BookResultFilter]
        public async Task<IActionResult> CreateBook(BookForCreation bookForCreation)
        {
            var bookEntity = _mapper.Map<Entities.Book>(bookForCreation);

            _booksRepository.AddBook(bookEntity);

            await _booksRepository.SaveChangesAsync();

            return CreatedAtRoute("GetBook", new { id = bookEntity.Id }, bookEntity);
        }
    }
}
