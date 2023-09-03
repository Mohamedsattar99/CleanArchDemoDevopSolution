using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class DemoDbContextFactory : DesignTimeDbContextFactoryBase<DemoDbContext>
    {
        protected override DemoDbContext CreateNewInstance(DbContextOptions<DemoDbContext> options)
        {
            return new DemoDbContext(options);
        }
    }
}
