using System.Collections.Generic;

namespace TestBupha3.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; } // Age will determine if the owner is an adult or child
        public List<Book> Books { get; set; } = new List<Book>();

        public bool IsAdult => Age >= 18; // Determine if this is an adult based on age
    }
}
