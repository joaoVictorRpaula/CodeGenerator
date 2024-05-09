using CodeGenerator.DOMAIN.Interfaces;
using CodeGenerator.DOMAIN.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeGeneratorController : ControllerBase
    {
        private readonly ICodeGeneratorService codeGenerator;
        public CodeGeneratorController(ICodeGeneratorService codeGenerator)
        {
            this.codeGenerator = codeGenerator;
        }

        [HttpPost]
        [Route("Generate")]
        public async Task<IActionResult> GenerateAsync(ApplicationDto applicationDto)
        {
            try
            {
                await this.codeGenerator.Generate(applicationDto);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}