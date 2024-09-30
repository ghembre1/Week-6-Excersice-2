using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Added this to be able to read and write to files
using System.Text.Json; // Added this to be able to use JSON properties like the serialize and deserialize
namespace Week_6_Excersice_2
{
    public class Book
    {
       // Properties for the book and allows us to get and assign value for the properties
        public string Title { get; set; } 
        public string Author { get; set; }
        public int Year { get; set; }
        public static object JsonSerializer { get; private set; }

        public static void SerializeToJson(string filename, Book book) // method to serialize to JSON
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(book, options);
            File.WriteAllText(filename, jsonString);
        }

        // Deserialize a JSON file into a Book object
        public static Book DeserializeFromJson(string filename) // Method to Deserialize from JSON
        {
            string jsonString = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<Book>(jsonString);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book myBook = new Book // Creates a new book object and its properties
            {
                Title = "Harry Potter",
                Author = "J. K. Rowling",
                Year = 1997
            };

            // Sets filename as the path to the json file
            string filename = "book.json";

            // Serialize the book to a JSON file
            Book.SerializeToJson(filename, myBook);
            Console.WriteLine("Book serialized to JSON."); // prints to user the book has been serialized

            // Deserialize the book from the JSON file
            Book deserializedBook = Book.DeserializeFromJson(filename);

            // Prints to users the details of the book
            Console.WriteLine($"Title: {deserializedBook.Title}");
            Console.WriteLine($"Author: {deserializedBook.Author}");
            Console.WriteLine($"Year: {deserializedBook.Year}");
        }
    }
}

