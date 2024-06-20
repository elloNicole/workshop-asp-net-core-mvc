using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppSales.Models;

namespace WebAppSales.Data
{
    public class WebAppSalesContext : DbContext
    {
        public WebAppSalesContext (DbContextOptions<WebAppSalesContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppSales.Models.Department> Department { get; set; } = default!;
    }
}
