using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DotNetAuthSample.Api.Data;
using DotNetAuthSample.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetAuthSample.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Role role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = role.Id }, role);
        }

        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await _context.Roles.AsNoTracking().ToListAsync();
            return Ok(roles);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Role role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _context.Roles.FindAsync(id);
            if (existing == null)
                return NotFound($"Role with ID {id} not found");

            existing.Name = role.Name;
            existing.Description = role.Description;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
                return NotFound($"Role with ID {id} not found");

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return Ok("Role deleted successfully");
        }
    }
}
