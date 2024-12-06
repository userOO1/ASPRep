using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parser.Core.ss;
using Parser.Core;
using ASPParser.Core.DB_connection;
using Microsoft.EntityFrameworkCore;

namespace ASPParser.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParseController : ControllerBase
    {
        private readonly IPageDataParser<List<Order>> _parser;

        public ParseController(IPageDataParser<List<Order>> parser)
        {
            _parser = parser;
        }
        [HttpPost]
        public async Task<ActionResult<List<List<Order>>>> SaveParsedOrders()
        {
            List<List<Order>> parse = await _parser.Worker();
            return Ok(parse);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<List<Order>>>> GetParsedOrders()
        {
            List<List<Order>> parse = await _parser.Worker();
            using (var context = new TestContext())
            {
                // Получение всех записей из таблицы Orders
                var orders = await context.Orders.ToListAsync();

                return Ok(orders);
            }
        }
    }
}