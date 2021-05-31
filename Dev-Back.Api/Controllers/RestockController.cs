using Dev_Back.Api.Entities;
using Dev_Back.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dev_Back.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestockController : ControllerBase
    {

        [HttpPost]
        [Route("[action]")]
        public ActionResult<int> RestockWhile(StockDao value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Stock.RestockWhile(value.ItemCount, value.Target);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<int> RestockForEach(StockDao value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Stock.RestockForEach(value.ItemCount, value.Target);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<int> RestockFor(StockDao value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Stock.RestockFor(value.ItemCount, value.Target);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<int> RestockDo(StockDao value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Stock.RestockDo(value.ItemCount, value.Target);
        }


    }
}
