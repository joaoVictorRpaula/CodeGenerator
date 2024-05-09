using CodeGenerator.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Interfaces
{
    public interface ICodeGeneratorService
    {
        Task Generate(ApplicationDto applicationDto);
    }
}
