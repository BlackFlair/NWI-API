using BookFinderAPI.Attributes;
using BookFinderAPI.Data;
using BookFinderAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey] //Custom Attribute
    public class BookFinderModelsController : ControllerBase
    {
        private readonly BookFinderAPIContext _context;

        public BookFinderModelsController(BookFinderAPIContext context)
        {
            _context = context;
        }

        // GET: api/BookFinderModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookFinderModel>>> GetBookFinderModel()
        {
            return await _context.BookFinderModel.ToListAsync();
        }

        // GET: api/BookFinderModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookFinderModel>> GetBookFinderModel(int id)
        {
            var bookFinderModel = await _context.BookFinderModel.FindAsync(id);

            if (bookFinderModel == null)
            {
                return NotFound();
            }

            return bookFinderModel;
        }

        // PUT: api/BookFinderModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookFinderModel(int id, BookFinderModel bookFinderModel)
        {
            if (id != bookFinderModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookFinderModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookFinderModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookFinderModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookFinderModel>> PostBookFinderModel(BookFinderModel bookFinderModel)
        {
            _context.BookFinderModel.Add(bookFinderModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookFinderModel", new { id = bookFinderModel.Id }, bookFinderModel);
        }

        // DELETE: api/BookFinderModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookFinderModel(int id)
        {
            var bookFinderModel = await _context.BookFinderModel.FindAsync(id);
            if (bookFinderModel == null)
            {
                return NotFound();
            }

            _context.BookFinderModel.Remove(bookFinderModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookFinderModelExists(int id)
        {
            return _context.BookFinderModel.Any(e => e.Id == id);
        }
    }
}
