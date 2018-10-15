using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace BookStorage {
    public class BookStorage : IBookStorage {

        public IEnumerable<Book> ReadBooks() {
            string[] bookList = new string[0];
            List<Book> books = new List<Book>();
            try {
                bookList = File.ReadAllLines(HttpRuntime.AppDomainAppPath + "books.txt");
            } catch (IOException e) {
                Console.WriteLine(e.Message);
            }
            for (int i = 0; i < bookList.Length; i++) {
                string[] elements = bookList[i].Split(',');
                Book book = new Book() {
                    ID = elements[0],
                    Name = elements[1],
                    Author = elements[2],
                    Year = int.Parse(elements[3]),
                    Price = float.Parse(elements[4].Substring(1)),
                    Stock = int.Parse(elements[5])
                };
                books.Add(book);
            }
            return books;
        }

        public void WriteBooks(IEnumerable<Book> books) {
            string bookList = string.Empty;
            foreach (Book book in books) {
                bookList += book.ID + ',' + book.Name + ',' + book.Author + ',' +
                        book.Year + ",$" + book.Price + ',' + book.Stock + '\n';
            }
            try {
                File.WriteAllText(HttpRuntime.AppDomainAppPath + "books.txt", bookList.Substring(0, bookList.Length - 1));
            } catch (IOException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
