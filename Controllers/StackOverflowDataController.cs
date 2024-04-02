using Microsoft.AspNetCore.Mvc;
using StackOverflowRESTAPIProject.Services;

namespace StackOverflowRESTAPIProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StackOverflowDataController : ControllerBase
    {
        private readonly StackOverflowService _stackOverflowService;

        public StackOverflowDataController(StackOverflowService stackOverflowService)
        {
            _stackOverflowService = stackOverflowService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] uint page = 1, [FromQuery] uint pageSize = 100)
        {
            return Ok(await _stackOverflowService.GetTagsAsync(page, pageSize));
        }

        [HttpGet("refill")]
        public async Task<IActionResult> Refill([FromQuery] uint count = 1000)
        {
            await _stackOverflowService.GetTagsFromApi(count);
            return Ok();
        }
    }
}