using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tickets.api.Data;
using tickets.api.Helpers;
using tickets.shared.DTOs;
using tickets.shared.Models;

namespace tickets.api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/contactos")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Clientes_Contactos
                .Include(e => e.Cliente)
                .Include(e => e.Tickets)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Nombre.ToLower().Contains(pagination.Filter.ToLower())
                || x.Apellido.ToLower().Contains(pagination.Filter.ToLower())
                || x.Departamento!.ToLower().Contains(pagination.Filter.ToLower())
                || x.Cargo!.ToLower().Contains(pagination.Filter.ToLower())
                || x.Telefono!.ToLower().Contains(pagination.Filter.ToLower())
                || x.Correo!.ToLower().Contains(pagination.Filter.ToLower())
                );
            }

            return Ok(await queryable
                .OrderBy(x => x.Nombre)
                .Paginate(pagination)
                .ToListAsync());
        }


        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Clientes_Contactos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Nombre.ToLower().Contains(pagination.Filter.ToLower())
                || x.Apellido.ToLower().Contains(pagination.Filter.ToLower())
                || x.Departamento!.ToLower().Contains(pagination.Filter.ToLower())
                || x.Cargo!.ToLower().Contains(pagination.Filter.ToLower())
                || x.Telefono!.ToLower().Contains(pagination.Filter.ToLower())
                || x.Correo!.ToLower().Contains(pagination.Filter.ToLower())
                );
            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);

            var resume = new PagesDTO
            {
                TotalCounts = count,
                TotalPages = totalPages
            };

            return Ok(resume);
        }

        [HttpGet("combo")]
        public async Task<ActionResult> GetCombo()
        {
            return Ok(await _context.Clientes_Contactos.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var empleado = await _context.Clientes_Contactos
                .Include(e => e.Cliente)
                .Include(e => e.Tickets)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Clientes_Contactos contacto)
        {
            try
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return Ok(contacto);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Clientes_Contactos contacto)
        {
            try
            {
                _context.Update(contacto);
                await _context.SaveChangesAsync();
                return Ok(contacto);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var empleado = await _context.Clientes_Contactos.FirstOrDefaultAsync(x => x.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
