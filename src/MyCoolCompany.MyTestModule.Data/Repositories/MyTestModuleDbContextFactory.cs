using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace MyCoolCompany.MyTestModule.Data.Repositories
{
  
    public class MyTestModuleDbContextFactory : IDesignTimeDbContextFactory<MyTestModuleDbContext>
    {
        public MyTestModuleDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyTestModuleDbContext>();

            builder.UseSqlServer("Data Source=(local);Initial Catalog=VirtoCommerce3;Persist Security Info=True;User ID=sa;Password=123;Connect Timeout=30;TrustServerCertificate=True;");

            return new MyTestModuleDbContext(builder.Options);
        }
    }
}
