//using Moq;
//using Xunit;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Linq;
//using TestBupha3.Controllers;
//using TestBupha3.Models;
//using TestBupha3.Data_Repo;

//public class BooksControllerTests
//{
//    private readonly BookController _controller;

//    public BooksControllerTests()
//    {
//        // Set up any necessary dependencies or in-memory data
//        _controller = new BookController();

//        // Optionally, you can add initial data to your in-memory store here.
//        // Example: Add some test data to InMemoryDataStore
//        Data.Owners.Add(new Owner { Id = 1, Name = "Adult Owner", Age = 30, Books = new List<Book>() });
//        Data.Owners.Add(new Owner { Id = 2, Name = "Child Owner", Age = 12, Books = new List<Book>() });

//        Data.Books.Add(new Book { Id = 1, Title = "Adult Book", Author = "Author A", OwnerId = 1 });
//        Data.Books.Add(new Book { Id = 2, Title = "Children's Book", Author = "Author B", OwnerId = 2 });
//    }

//    [Fact]
//    public void GetBooksOwnedByAdults_Returns_AdultBooks()
//    {
//        // Act
//        var result = _controller.GetBooksOwnedByAdults();
//        var okResult = result as OkObjectResult;
//        var books = okResult.Value as IEnumerable<Book>;

//        // Assert
//        Assert.NotNull(result);
//        Assert.IsType<OkObjectResult>(result);
//        Assert.NotNull(books); // Ensure books is not null
//        Assert.True(books.All(b => Data.Owners.First(o => o.Id == b.OwnerId).Age >= 18)); // Check if all books belong to adult owners
//    }

//    [Fact]
//    public void GetBooksOwnedByChildren_Returns_ChildrenBooks()
//    {
//        // Act
//        var result = _controller.GetBooksOwnedByChildren();
//        var okResult = result as OkObjectResult;
//        var books = okResult.Value as IEnumerable<Book>;

//        // Assert
//        Assert.NotNull(result);
//        Assert.IsType<OkObjectResult>(result);
//        Assert.NotNull(books); // Ensure books is not null
//        Assert.True(books.All(b => Data.Owners.First(o => o.Id == b.OwnerId).Age < 18)); // Check if all books belong to child owners
//    }

//    [Fact]
//    public void PostBook_Adds_NewBook()
//    {
//        // Arrange
//        var newBook = new Book
//        {
//            Title = "New Book",
//            Author = "New Author",
//            OwnerId = 1 // Assign to an adult owner
//        };

//        // Act
//        var result = _controller.PostBook(newBook);
//        var createdResult = result as CreatedAtActionResult;
//        var book = createdResult.Value as Book;

//        // Assert
//        Assert.NotNull(result);
//        Assert.IsType<CreatedAtActionResult>(result);
//        Assert.NotNull(book); // Ensure the created book is not null
//        Assert.Equal(newBook.Title, book.Title);
//        Assert.Equal(newBook.Author, book.Author);
//        Assert.Equal(newBook.OwnerId, book.OwnerId);
//    }
//}
