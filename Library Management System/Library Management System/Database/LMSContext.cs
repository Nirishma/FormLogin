using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Database
{
    public class LMSContext:DbContext
    {
        public LMSContext(DbContextOptions<LMSContext> options)
        : base(options)
        {
        }

        public DbSet<Library_Management_System.Models.Student> Student { get; set; }
        public DbSet<Library_Management_System.Models.Book> Book { get; set; }
        public DbSet<Library_Management_System.Models.Borrow> Borrow { get; set; }




    }
}
