using Microsoft.AspNetCore.Mvc;
using Services;

namespace BackApi.Controllers
{
    [Route("api/reflection")]
    [ApiController]
    public class ReflectionController : ControllerBase
    {
        private readonly IImporterReflectionService _importerReflectionService;

        public ReflectionController(IImporterReflectionService importerReflectionService)
        {
            _importerReflectionService = importerReflectionService;
        }

        [HttpGet("importers")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<string>>> GetImporters()
        {
            var assemblies = await _importerReflectionService.GetImporterAssembliesAsync();
            return Ok(assemblies);
        }
    }
}
