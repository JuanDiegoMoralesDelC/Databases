using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : BaseEntity, new()
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _entity;
        public BaseController(ApplicationContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                if (_entity == null) return NoContent();
                var data = await _entity.ToListAsync();
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (_entity == null) return NoContent();
                var data = await _entity.FindAsync(id);

                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, T data)
        {
            try
            {
                if (id != data.Id)
                {
                    return BadRequest();
                }

                _context.Entry(data).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !TExists(id) ? NotFound() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(T data)
        {
            try
            {
                if (_entity == null) return NoContent();

                _entity.Add(data);
                await _context.SaveChangesAsync();

                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (_entity == null) return NoContent();

                var data = await _entity.FindAsync(id);
                if (data == null)
                {
                    return NotFound();
                }

                _entity.Remove(data);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private bool TExists(int id)
        {
            return _entity.Any(e => e.Id == id);
        }
    }
}
