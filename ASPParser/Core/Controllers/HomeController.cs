//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Parser.Core.ss;
//using Parser.Core;
//
//namespace ASPParser.Core.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class ParseController : ControllerBase
//    {
//        private readonly IParsing<List<Order>> _parser;
//
//        public ParseController(IParser<List<Order>> parser)
//        {
//            _parser = parser;
//        }
//
//        [HttpGet]
//        public async Task<ActionResult<List<List<Order>>>> GetParsedOrders()
//        {
//            List<List<Order>> parse = await _parser.Worker();
//            return Ok(parse);
//        }
//    }
//}
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
        private readonly Parsing<List<Order>> _parser;

        public ParseController()
        {
            _parser = new Parsing<List<Order>>(new EisParser());
        }

        [HttpGet]
        public async Task<ActionResult<List<List<Order>>>> GetParsedOrders()
        {
            List<List<Order>> parse = await _parser.Worker();
            return Ok(parse);
        }
    }
}