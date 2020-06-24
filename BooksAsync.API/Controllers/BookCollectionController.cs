using AutoMapper;
using BooksAsync.API.Filters;
using BooksAsync.API.ModelBinders;
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
    [BookResultFilter]
    public class BookCollectionController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BookCollectionController(IBooksRepository repo, IMapper mapper)
        {
            _booksRepository = repo;
            _mapper = mapper;
        }

        // implemented in that way, in the response it will have a url that contains the combined ids 
        // of the newly created collection. if we fetch that url, then we receive the collection that we just posted
        [HttpPost]
        public async Task<IActionResult> CreateBookCollection(IEnumerable<BookForCreation> bookCollection)
        {
            var bookEntities = _mapper.Map<IEnumerable<Entities.Book>>(bookCollection);

            foreach (var bookEntity in bookEntities)
            {
                _booksRepository.AddBook(bookEntity);
            }

            await _booksRepository.SaveChangesAsync();

            var booksToReturn = await _booksRepository.GetBooksAsync(bookEntities.Select(b => b.Id).ToList());
            var bookIds = String.Join(",", booksToReturn.Select(a => a.Id));

            return CreatedAtRoute("GetBookCollection", new { bookIds}, booksToReturn);
        }

        [HttpGet("({bookIds})", Name="GetBookCollection")]
        public async Task<IActionResult> GetBookCollection(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> bookIds)
        {
            var bookEntities = await _booksRepository.GetBooksAsync(bookIds);
            if (bookIds.Count() != bookEntities.Count()) return NotFound();

            return Ok();
        }

    }
}
