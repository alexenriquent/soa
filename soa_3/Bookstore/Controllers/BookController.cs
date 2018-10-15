using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.Controllers {

    public class BookController : Controller {

        storage.IBookStorage storageProxy = new storage.BookStorageClient();
        purchase.IBookPurchase purchaseProxy = new purchase.BookPurchaseClient();

        public ActionResult Index() {
            return View(storageProxy.ReadBooks());
        }

        public ActionResult Add() {
            if (TempData["message"] == null)
                ViewBag.message = "";
            else
                ViewBag.message = TempData["message"];
            return View(storageProxy.ReadBooks());
        }

        [HttpPost]
        public ActionResult Add(string id, string name, string author, int year, float price, int stock) {
            List<storage.Book> books = storageProxy.ReadBooks();

            if (books.Any(x => x.ID == id)) {
                TempData["message"] = "Record already exists.";
                return RedirectToAction("/Add");
            }

            storage.Book book = new storage.Book {
                ID = id, Name = name, Author = author, Year = year,
                Price = price, Stock = stock
            };
            books.Add(book);
            storageProxy.WriteBooks(books);
            return Redirect("/Book/Add");
        }

        public ActionResult Delete() {
            if (TempData["message"] == null)
                ViewBag.message = "";
            else
                ViewBag.message = TempData["message"];
            return View(storageProxy.ReadBooks());
        }

        [HttpPost]
        public ActionResult Delete(string attribute, string value) {
            List<storage.Book> books = storageProxy.ReadBooks();

            switch (attribute) {
                case "index":
                    if (int.Parse(value) < 1 || int.Parse(value) > books.Count) {
                        TempData["message"] = "Record not found.";
                        return RedirectToAction("/Delete");
                    }
                    books.RemoveAt(int.Parse(value) - 1);
                    break;
                case "id":
                    if (!books.Any(o => o.ID == value)) {
                        TempData["message"] = "Record not found.";
                        return RedirectToAction("/Delete");
                    }
                    books.RemoveAll((x => x.ID == value));
                    break;
                case "year":
                    if (!books.Any(o => o.Year == int.Parse(value))) {
                        TempData["message"] = "Record not found.";
                        return RedirectToAction("/Delete");
                    }
                    books.RemoveAll((x => x.Year == int.Parse(value)));
                    break;
            }
            storageProxy.WriteBooks(books);
            return Redirect("/Book/Delete");
        }

        public ActionResult Search() {
            if (TempData["books"] == null)
                ViewBag.books = new List<storage.Book>();
            else
                ViewBag.books = TempData["books"];
            return View();
        }

        [HttpPost]
        public ActionResult Search(string attribute, string value) {
            var books = from x in storageProxy.ReadBooks() select x;

            switch (attribute) {
                case "id": books = books.Where(x => x.ID.Contains(value)); break;
                case "name": books = books.Where(x => x.Name.ToLower().Contains(value.ToLower())); break;
                case "author": books = books.Where(x => x.Author.ToLower().Contains(value.ToLower())); break;
                case "year": books = books.Where(x => x.Year == int.Parse(value)); break;
            }

            TempData["books"] = books.ToList();
            return RedirectToAction("/Search");
        }

        public ActionResult Purchase() {
            if (TempData["message"] == null)
                ViewBag.message = "";
            else
                ViewBag.message = TempData["message"];
            return View(storageProxy.ReadBooks());
        }

        [HttpPost]
        public ActionResult Purchase(float budget, int[] key, int[] value) {
            Dictionary<int, int> orders = new Dictionary<int, int>();

            for (int i = 0; i < key.Length; i++) {
                if (!orders.ContainsKey(key[i])) {
                    orders.Add(key[i], value[i]);
                } else {
                    TempData["message"] = "Please do not enter any book number more than once.";
                    return RedirectToAction("/Purchase");
                }
            }

            purchase.BookPurchaseInfo request = new purchase.BookPurchaseInfo() {
                budget = budget,
                items = orders
            };

            purchase.BookPurchaseResponse response = purchaseProxy.PurchaseBooks(request);
            ViewBag.response = response.response;
            return View(storageProxy.ReadBooks());
        }
    }
}