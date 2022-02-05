using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeatRequest.API.Model;

namespace HeatRequest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private HeatRequestAppDbContext context;
        public ValuesController(HeatRequestAppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Route("setValue")]
        public IActionResult SetValue(HeatDto model)
        {
            try
            {
                context.Add(new Heat
                {
                    MakinaId = model.MakinaId,
                    Sicaklik = decimal.Parse(model.HeatValue.ToString("0.00")),
                    Tarih = DateTime.Now
                });
                context.SaveChanges();
                return Ok(new string[]
                {
                    "Basarili"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new string[]
                {
                    "Basarisiz",e.Message.ToString()
                });
            }
        }

        [HttpGet]
        [Route("getValues")]
        public IActionResult GetValues()
        {
            try
            {
                return Ok(context.Heat.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(new string[]
                {
                    "Verileri cekme basarisiz oldu"
                });
            }
        }
    }
}
