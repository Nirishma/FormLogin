using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class Borrow
    {
        public int Id { get; set; }
        public DateTime Borrow_Date { get; set; }
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public virtual Student student { get; set; }
        public virtual Book book { get; set; }

    }
}
