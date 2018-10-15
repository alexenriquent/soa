using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookPurchase {

    public class BookPurchase : IBookPurchase {

        public BookPurchaseResponse PurchaseBooks(BookPurchaseInfo info) {
            localhost.BookStorage storage = new localhost.BookStorage();
            List<localhost.Book> books = storage.ReadBooks().ToList();
            BookPurchaseResponse response = new BookPurchaseResponse();
            float totalCost = 0;

            foreach (KeyValuePair<int, int> entry in info.items) {
                totalCost += (books.ElementAt(entry.Key - 1).Price * entry.Value);
                if (entry.Value > books.ElementAt(entry.Key - 1).Stock) {
                    response.result = false;
                    response.response = "Not enough stocks";
                    return response;
                }
            }

            if (totalCost > info.budget) {
                response.result = false;
                response.response = "Not enough money";
                return response;
            }

            response.result = true;
            response.response = "$" + Math.Round((info.budget - totalCost), 2).ToString();
            return response;
        }
    }
}
