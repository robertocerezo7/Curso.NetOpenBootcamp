using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.DataAccess
{
    public class UniversityDBContext: DbContext
    {
            public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options)
        { 
        
        }  

        // Add bSets (Tables od our DataBase)

        public DbSet<User>? Users { get; set; }

        public DbSet<Course>? Course { get; set; }

        public DbSet<Chapter>? Chapters { get; set; }

        public DbSet<Category>? Category { get; set; }

        public DbSet<Student>? Students { get; set; }

        

    }
}
