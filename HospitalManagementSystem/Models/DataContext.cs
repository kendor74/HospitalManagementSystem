using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {   
        }
        public DbSet<HospitalManagementSystem.Models.Pateint> Pateint { get; set; } = default!;
        public DbSet<HospitalManagementSystem.Models.Employee> Employee { get; set; } = default!;
    }
}
