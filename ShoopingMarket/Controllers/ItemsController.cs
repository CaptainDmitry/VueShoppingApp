using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoopingMarket.Model;

namespace ShoopingMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly BDContext _context;

        public ItemsController(BDContext context)
        {
            _context = context;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Item> items = _context.Items.ToList();
            return Ok(items);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            Item item = _context.Items.Where(x => x.Id == id).FirstOrDefault();
            if (item != null) return Ok(item);
            return NotFound();
        }

        // POST api/<ItemsController>
        [HttpPost]
        public IActionResult Post([FromBody] Item newItem)
        {
            _context.Items.AddAsync(newItem);
            _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetId), new { id = newItem.Id }, newItem);
        }

        //// PUT api/<ItemsController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Item p = _context.Items.FirstOrDefault(x => x.Id == id);
            if (p == null) return NotFound();
            _context.Items.Remove(p);
            _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
