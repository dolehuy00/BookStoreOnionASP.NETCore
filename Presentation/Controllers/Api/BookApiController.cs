using Microsoft.AspNetCore.Mvc;
using Service.Abstractions;
using Shared;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookApiController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookApiController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] BookDTO bookDTO)
        {
            try
            {
                var newBookDTO = await _bookService.Add(bookDTO);
                return Ok(bookDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] BookDTO bookDTO)
        {
            try
            {
                await _bookService.Update(bookDTO);
                return Ok(bookDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Add(int bookId)
        {
            try
            {
                await _bookService.Delete(bookId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{bookId}")]
        public async Task<IActionResult> Get(int bookId)
        {
            try
            {
                var book = await _bookService.Get(bookId);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var books = await _bookService.GetAll();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
