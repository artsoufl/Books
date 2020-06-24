using AutoMapper;
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
    [Route("api/bookcollections")]
    public class BookCollectionController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BookCollectionController(IBooksRepository repo, IMapper mapper)
        {
            _booksRepository = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookCollection(IEnumerable<BookForCreation> bookCollection)
        {
            var bookEntities = _mapper.Map<IEnumerable<Entities.Book>>(bookCollection);

            foreach (var bookEntity in bookEntities)
            {
                _booksRepository.AddBook(bookEntity);
            }

            await _booksRepository.SaveChangesAsync();

            return Ok();
        }

    }
}
