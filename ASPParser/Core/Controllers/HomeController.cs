using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parser.Core.ss;
using Parser.Core;

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

        [HttpGet]
        public async Task<ActionResult<List<List<Order>>>> GetParsedOrders()
        {
            List<List<Order>> parse = await _parser.Worker();
            return Ok(parse);
        }
    }
}