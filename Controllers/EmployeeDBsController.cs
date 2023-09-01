using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDBsController : ControllerBase
    {
        private readonly EmpDBContext _context;

        public EmployeeDBsController(EmpDBContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeDBs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDB>>> GetEmployess()
        {
          if (_context.Employess == null)
          {
              return NotFound();
          }
            return await _context.Employess.ToListAsync();
        }

        // GET: api/EmployeeDBs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDB>> GetEmployeeDB(int id)
        {
          if (_context.Employess == null)
          {
              return NotFound();
          }
            var employeeDB = await _context.Employess.FindAsync(id);

            if (employeeDB == null)
            {
                return NotFound();
            }

            return employeeDB;
        }

        // PUT: api/EmployeeDBs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeDB(int id, EmployeeDB employeeDB)
        {
            if (id != employeeDB.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeDB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDBExists(id))
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

        // POST: api/EmployeeDBs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeDB>> PostEmployeeDB(EmployeeDB employeeDB)
        {
          if (_context.Employess == null)
          {
              return Problem("Entity set 'EmpDBContext.Employess'  is null.");
          }
            _context.Employess.Add(employeeDB);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeDB", new { id = employeeDB.Id }, employeeDB);
        }

        // DELETE: api/EmployeeDBs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeDB(int id)
        {
            if (_context.Employess == null)
            {
                return NotFound();
            }
            var employeeDB = await _context.Employess.FindAsync(id);
            if (employeeDB == null)
            {
                return NotFound();
            }

            _context.Employess.Remove(employeeDB);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeDBExists(int id)
        {
            return (_context.Employess?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
