using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookStorage {

    [ServiceContract]
    public interface IBookStorage {

        [OperationContract]
        IEnumerable<Book> ReadBooks();

        [OperationContract]
        void WriteBooks(IEnumerable<Book> books);
    }

    [DataContract]
    public class Book {

        string id;
        string name;
        string author;
        int year;
        float price;
        int stock;

        [DataMember]
        public string ID {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Author {
            get { return author; }
            set { author = value; }
        }

        [DataMember]
        public int Year {
            get { return year; }
            set { year = value; }
        }

        [DataMember]
        public float Price {
            get { return price; }
            set { price = value; }
        }

        [DataMember]
        public int Stock {
            get { return stock; }
            set { stock = value; }
        }
    }
}
