using CodeGenerator.DOMAIN.Interfaces;
using CodeGenerator.DOMAIN.Models;
using CodeGenerator.INFRA.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeGeneratorController : ControllerBase
    {
        private readonly ICodeGeneratorService codeGenerator;
        private readonly ITemplateService templateService;
        private readonly ITypeConverterService typeConverterService;
        public CodeGeneratorController(ICodeGeneratorService codeGenerator, ITemplateService templateService, ITypeConverterService typeConverterService)
        {
            this.codeGenerator = codeGenerator;
            this.templateService = templateService;
            this.typeConverterService = typeConverterService;
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

        [HttpGet]
        [Route("GetAllTemplates")]
        public IActionResult GetAllTemplates()
        {
            return Ok(templateService.GetAllTemplates());
        }

        [HttpGet]
        [Route("GetAllLanguages")]
        public IActionResult GetAllLanguages()
        {
            return Ok(typeConverterService.GetAvailableLanguages());
        }
    }
}