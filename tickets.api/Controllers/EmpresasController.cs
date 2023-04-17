using tickets.api.Data;
using tickets.api.Helpers;
using tickets.shared.DTOs;
using tickets.shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace tickets.api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/empresas")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly DataContext _context;

        public EmpresasController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Generales_Empresas
                .Include(e => e.Sucursales)
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
            var queryable = _context.Generales_Empresas.AsQueryable();

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
            return Ok(await _context.Generales_Empresas.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var empresa = await _context.Generales_Empresas
                .Include(x => x.Sucursales)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Generales_Empresas empresa)
        {

            //TODO: TRABAJAR EN SUBIR LA IMAGEN

            try
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return Ok(empresa);
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
        public async Task<ActionResult> PutAsync(Generales_Empresas empresa)
        {
            try
            {
                _context.Update(empresa);
                await _context.SaveChangesAsync();
                return Ok(empresa);
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
            var empresa = await _context.Generales_Empresas.FirstOrDefaultAsync(x => x.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
