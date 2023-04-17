using tickets.api.Data;
using tickets.api.Helpers;
using tickets.shared.DTOs;
using tickets.shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace tickets.api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/sucursales")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly DataContext _context;

        public SucursalesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Generales_Sucursales
                .Include(x => x.Empresa)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Nombre.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return Ok(await queryable
                .OrderBy(x => x.Nombre)
                .Paginate(pagination)
                .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Generales_Sucursales.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Nombre.ToLower().Contains(pagination.Filter.ToLower()));
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
            return Ok(await _context.Generales_Sucursales.ToListAsync());
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var sucursal = await _context.Generales_Sucursales
                .Include(x => x.Empresa)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return Ok(sucursal);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Generales_Sucursales sucursales)
        {
            try
            {
                _context.Add(sucursales);
                await _context.SaveChangesAsync();
                return Ok(sucursales);
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
        public async Task<ActionResult> PutAsync(Generales_Sucursales sucursal)
        {
            try
            {
                _context.Update(sucursal);
                await _context.SaveChangesAsync();
                return Ok(sucursal);
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
            var sucursal = await _context.Generales_Sucursales.FirstOrDefaultAsync(x => x.Id == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            _context.Remove(sucursal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
