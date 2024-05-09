﻿using CodeGenerator.DOMAIN.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Interfaces
{
    public interface ITypeConverterService
    {
        IList<Column> ConvertToCSharpType(IList<Column> columns);
    }
}
