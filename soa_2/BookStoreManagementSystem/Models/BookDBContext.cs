namespace BookStoreManagementSystem.Models {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class S4452232 {

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The field Index cannot be negative.")]
        public int Index { get; set; }

        [Key]
        [Required]
        [RegularExpression(@"\d+", ErrorMessage = "The field ID must be a string of numbers.")]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "The field Year must be a 4-digit number.")]
        public int Year { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, float.MaxValue, ErrorMessage = "The field Price cannot be negative.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The field Stock cannot be negative.")]
        public int Stock { get; set; }
    }

    public class BookDBContext : DbContext {

        public BookDBContext() 
            : base("name=BookDBContext") {
            Database.SetInitializer(new BookDBInitialiser());
        }

        public System.Data.Entity.DbSet<BookStoreManagementSystem.Models.S4452232> S4452232 { get; set; }
    }

    public class BookDBInitialiser : DropCreateDatabaseAlways<BookDBContext> {

        protected override void Seed(BookDBContext context) {
            localhost.DataStorage storage = new localhost.DataStorage();
            IList<S4452232> books = new List<S4452232>();
            string[] bookList = storage.Read();

            for (int i = 0; i < bookList.Length; i++) {
                string[] elements = bookList[i].Split(',');
                S4452232 book = new S4452232 {
                    Index = i + 1,
                    ID = elements[0],
                    Name = elements[1],
                    Author = elements[2],
                    Year = int.Parse(elements[3]),
                    Price = decimal.Parse(elements[4].Substring(1)),
                    Stock = int.Parse(elements[5])
                };
                books.Add(book);
            }

            foreach (S4452232 book in books)
                context.S4452232.Add(book);

            base.Seed(context);
        }
    }
}