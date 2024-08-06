using HMS_API.Model.PatientHandler;
using Microsoft.EntityFrameworkCore;

namespace HMS_API.Model
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
            
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
