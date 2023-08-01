using ASPNETMVC_Practica.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVC_Practica.Data

{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }





    }
}
