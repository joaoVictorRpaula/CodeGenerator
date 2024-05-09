using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.INFRA.Default;
using CodeGenerator.DOMAIN.Models;
using CodeGenerator.DOMAIN.Models.Db;

namespace CodeGenerator.INFRA.DynamicDbContext
{
    public class DynamicDbContext
    {
        public DefaultContext CreateDbContext(DbInformation dbInformation)
        {
            var connectionString = CreateConnectionString(dbInformation);
            var contextOptions = new DbContextOptionsBuilder<DefaultContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new DefaultContext(contextOptions);
        }

        private string CreateConnectionString(DbInformation dbInformation)
        {
            var connectionString = $"Server={dbInformation.Server};Database={dbInformation.Database};TrustServerCertificate=True;";

            if (dbInformation.Auth == Auth.Windows)
            {
                connectionString += "Integrated Security=SSPI;";
            }

            if (dbInformation.Auth == Auth.SqlServer)
            {
                if (dbInformation.User == null || dbInformation.Password == null)
                {
                    throw new Exception("User and Password can not be null.");
                }

                connectionString += $"User Id={dbInformation.User};Password={dbInformation.Password};";
            }

            return connectionString;
        }

    }
}
