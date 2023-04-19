using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tickets.api.Data;
using tickets.api.Helpers;
using tickets.shared.DTOs;
using tickets.shared.Models;

namespace tickets.api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly DataContext _context;

        public TicketsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            //var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity!.Name);
            //if (user == null)
            //{
            //    return BadRequest("User not valid.");
            //}

            var queryable = _context.Tickets
                .Include(c => c.Clasificacion)
                .Include(c => c.Cliente)
                .Include(c => c.Contacto)
                .Include(c => c.Empleado)
                .Include(c => c.User)
                .AsQueryable();

            //if (user.UserType == shared.Enums.UserType.Super_User)
            //{
            //    queryable = queryable.Where(t => t.Empleado.UserId == user.Id);
            //}


            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Titulo.ToLower().Contains(pagination.Filter.ToLower()) ||
                x.Notas!.ToLower().Contains(pagination.Filter.ToLower()) ||
                x.Cliente!.Nombre!.ToLower().Contains(pagination.Filter.ToLower()) ||
                x.Contacto!.Nombre!.ToLower().Contains(pagination.Filter.ToLower())
                );
            }

            return Ok(await queryable
                .OrderByDescending(x => x.FechaRegistro)
                .Paginate(pagination)
                .ToListAsync());
        }


        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Tickets.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Titulo.ToLower().Contains(pagination.Filter.ToLower()) ||
                x.Notas!.ToLower().Contains(pagination.Filter.ToLower()) ||
                x.Cliente!.Nombre!.ToLower().Contains(pagination.Filter.ToLower()) ||
                x.Contacto!.Nombre!.ToLower().Contains(pagination.Filter.ToLower())
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var ticket = await _context.Tickets
                .Include(c => c.Clasificacion)
                .Include(c => c.Cliente)
                .Include(c => c.Contacto)
                .Include(c => c.Empleado)
                .Include(c => c.User)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Tickets ticket)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity!.Name);
                if (user == null)
                {
                    return BadRequest("User not valid.");
                }

                var newTicket = new Tickets
                {
                    Id = ticket.Id,
                    UserId = user.Id,
                    ClasificacionId = ticket.ClasificacionId,
                    ClienteId = ticket.ClienteId,
                    ContactoId = ticket.ContactoId,
                    EmpleadoId = ticket.EmpleadoId,
                    
                    Estado = shared.Enums.EstadosTickets.Nuevo,
                    Prioridad = ticket.Prioridad,                    
                    
                    FechaAsignada = ticket.FechaAsignada,
                    FechaEntrega = ticket.FechaEntrega,
                    FechaRegistro = DateTime.Now,
                    
                    Hora = DateTime.Now.TimeOfDay,
                    HoraEntrega = ticket.HoraEntrega,
                    
                    Titulo = ticket.Titulo,
                    Notas = ticket.Notas,

                    NotasArchivado = ticket.NotasArchivado,
                    FechaArchivado = ticket.FechaArchivado
                };

                _context.Add(newTicket);
                await _context.SaveChangesAsync();
                return Ok(newTicket);
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

    }
}
