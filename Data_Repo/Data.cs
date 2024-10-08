using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestBupha3.Models;

namespace TestBupha3.Data_Repo
{
    public static class Data
    {
        public static List<Book> Books { get; } = new List<Book>();
        public static List<Owner> Owners { get; } = new List<Owner>();

        static Data()
        {
            // Initialize Owners
            Owners.AddRange(new List<Owner>
        {
            new Owner { Id = 1, Name = "Adult 1 sushanth", Age = 35 }, // Adult
            new Owner { Id = 2, Name = "child 1 sush", Age = 12 }, // Child (Student)
            new Owner { Id = 3, Name = "child 2", Age = 10 } // Another Child (Student)
        });

            // Initialize Books
            Books.AddRange(new List<Book>
        {
            new Book { Id = 1, Title = "Harry Potter-1", Author = "J.K. Rowling", OwnerId = 1, Owner = Owners[0] }, // Adult Book
            new Book { Id = 2, Title = "Harry Potter-2 ", Author = "J.K. Rowling", OwnerId = 2, Owner = Owners[1] }, // Children Book
            new Book { Id = 3, Title = "Harry Potter-3", Author = "J.K. Rowling", OwnerId = 3, Owner = Owners[2] } // Children Book
        });

            // Assign Books to Owners
            Owners[0].Books.Add(Books[0]);
            Owners[1].Books.Add(Books[1]);
            Owners[2].Books.Add(Books[2]);
        }
    }
}
