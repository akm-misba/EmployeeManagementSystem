using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Models
{
    public  class MVCDBContext:DbContext
    {
        public MVCDBContext()
            : base()
        {
            
        }
        public MVCDBContext(DbContextOptions<MVCDBContext> options)
           : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           // one to many relationship
           // modelBuilder.Entity<Department>()
           // .WithOne(d => d.Companies)
           // .WithMany(c => c.Departments)
           // .HasForeignKey(d => d.ComId);
           // modelBuilder.Entity<Designation>()
           // .HasRequired(d => d.Companies)
           // .WithMany(c => c.Designations)
           // .HasForeignKey(d => d.ComId);
           // modelBuilder.Entity<Shift>()
           //.HasRequired(s => s.Companies)
           //.WithMany(c => c.Shifts)
           //.HasForeignKey(s => s.ComId);



            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Shift> Shifts { get; set; }    

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }  
        public DbSet<AttendanceSummary> AttendanceSummaries { get; set; }   
        public DbSet<Salary> SalarySummaries{ get; set;}
    }
}
