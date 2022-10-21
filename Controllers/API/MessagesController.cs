using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapp_travel_agency.Controllers.API
{
  
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        ApplicationDbContext _ctx;
        public MessagesController()
        {
            _ctx = new ApplicationDbContext();
        }



        [HttpPost("{id}")]
        public IActionResult Send(int id, Message message)
        {
            SmartBox smartBox = _ctx.smartBoxes.Where(x => x.Id == id).FirstOrDefault(); ;
            if (smartBox == null)
            {
                return NotFound("Il travel package selezionato non esiste");
            }
            //Message ms = new();
            //ms = message;
            message.SmartBoxId = id;
            _ctx.Messages.Add(message);
            _ctx.SaveChanges();
            return Ok("Messagge inviato correttamente");

        }
    }
    
}

