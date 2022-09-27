using CacheTask.Models;
using CacheTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.Text.Json;

namespace CacheTask.Controllers
{
    public class HomeController : Controller
    {
        private const string CACHE_HOMEVM = "homeVM";
        private IMemoryCache _memoryCache;
        HomeVM _homeVM = new HomeVM
        {
            Products= new List<Product>(){
new Product { ProductId = 1, ProductName= "Chai", CategoryId = 1, Discontinued = false, QuantityPerUnit = "10 boxes x 20 bags", ReorderLevel = 10, SupplierId = 1, UnitPrice = 18.00m,UnitsInStock = 39,UnitsOnOrder= 0 },
new Product { ProductId = 2, ProductName= "Chang", CategoryId = 1, Discontinued = false, QuantityPerUnit = "24 - 12 oz bottles", ReorderLevel = 25, SupplierId = 1, UnitPrice = 19.00m,UnitsInStock = 17,UnitsOnOrder= 40 },
new Product { ProductId = 3, ProductName= "Aniseed Syrup", CategoryId = 2, Discontinued = false, QuantityPerUnit = "12 - 550 ml bottles", ReorderLevel = 25, SupplierId = 1, UnitPrice = 10.00m,UnitsInStock = 13,UnitsOnOrder= 70 },
new Product { ProductId = 4, ProductName= "Chem Anton's Cajun Seasoning", CategoryId = 2, Discontinued = false, QuantityPerUnit = "48 - 6 oz jars", ReorderLevel = 0, SupplierId = 2, UnitPrice = 22.00m,UnitsInStock = 53,UnitsOnOrder= 0 },
new Product { ProductId = 5, ProductName= "Chem Anton's Gumbo Mix", CategoryId = 2, Discontinued = true, QuantityPerUnit = "36 boxes", ReorderLevel = 0, SupplierId = 2, UnitPrice = 21.35m,UnitsInStock = 0,UnitsOnOrder= 0 },
new Product { ProductId = 6, ProductName= "Grandma's Boysenberry Spread", CategoryId = 2, Discontinued = false, QuantityPerUnit = "12 - 8 oz jars", ReorderLevel = 25, SupplierId = 3, UnitPrice = 25.00m,UnitsInStock = 120,UnitsOnOrder= 0 },
new Product { ProductId = 7, ProductName= "Uncle Bob's Organic Dried Pears", CategoryId = 7, Discontinued = false, QuantityPerUnit = "12 - 1 lb pkgs.", ReorderLevel = 10, SupplierId = 3, UnitPrice = 30.00m,UnitsInStock = 15,UnitsOnOrder= 0 },
new Product { ProductId = 8, ProductName= "Northwoods Cranberry Sauce", CategoryId = 2, Discontinued = false, QuantityPerUnit = "12 - 12 oz jars", ReorderLevel = 0, SupplierId = 3, UnitPrice = 40.00m,UnitsInStock = 6,UnitsOnOrder= 0 },
new Product { ProductId = 9, ProductName= "Mishi Kobe Niku", CategoryId = 6, Discontinued = true, QuantityPerUnit = "18 - 500 g pkgs.", ReorderLevel = 0, SupplierId = 4, UnitPrice = 97.00m,UnitsInStock = 29,UnitsOnOrder= 0 },
new Product { ProductId = 10, ProductName= "Ikura", CategoryId = 8, Discontinued = false, QuantityPerUnit = "12 - 200 ml jars", ReorderLevel = 0, SupplierId = 4, UnitPrice = 31.00m,UnitsInStock = 31,UnitsOnOrder= 0 },
new Product { ProductId = 11, ProductName= "Queso Cabrales", CategoryId = 4, Discontinued = false, QuantityPerUnit = "1 kg pkg.", ReorderLevel = 30, SupplierId = 5, UnitPrice = 21.00m,UnitsInStock = 22,UnitsOnOrder= 30 },
new Product { ProductId = 12, ProductName= "Queso Manchego La Pastora", CategoryId = 4, Discontinued = false, QuantityPerUnit = "10 - 500 g pkgs.", ReorderLevel = 0, SupplierId = 5, UnitPrice = 38.00m,UnitsInStock = 86,UnitsOnOrder= 0 },
new Product { ProductId = 13, ProductName= "Konbu", CategoryId = 8, Discontinued = false, QuantityPerUnit = "2 kg box", ReorderLevel = 5, SupplierId = 6, UnitPrice = 6.00m,UnitsInStock = 24,UnitsOnOrder= 0 },
new Product { ProductId = 14, ProductName= "Tomu", CategoryId = 7, Discontinued = false, QuantityPerUnit = "40 - 100 g pkgs.", ReorderLevel = 0, SupplierId = 6, UnitPrice = 23.25m,UnitsInStock = 35,UnitsOnOrder= 0 },
new Product { ProductId = 15, ProductName= "Genen Shouyu", CategoryId = 2, Discontinued = false, QuantityPerUnit = "24 - 250 ml bottles", ReorderLevel = 5, SupplierId = 6, UnitPrice = 15.50m,UnitsInStock = 39,UnitsOnOrder= 0 },
new Product { ProductId = 16, ProductName= "Pavlova", CategoryId = 3, Discontinued = false, QuantityPerUnit = "32 - 500 g boxes", ReorderLevel = 10, SupplierId = 7, UnitPrice = 17.45m,UnitsInStock = 29,UnitsOnOrder= 0 },
new Product { ProductId = 17, ProductName= "Alice Mutton", CategoryId = 6, Discontinued = true, QuantityPerUnit = "20 - 1 kg tins", ReorderLevel = 0, SupplierId = 7, UnitPrice = 39.00m,UnitsInStock = 0,UnitsOnOrder= 0 },
new Product { ProductId = 18, ProductName= "Carnarvon Tigers", CategoryId = 8, Discontinued = false, QuantityPerUnit = "16 kg pkg.", ReorderLevel = 0, SupplierId = 7, UnitPrice = 62.50m,UnitsInStock = 42,UnitsOnOrder= 0 },
new Product { ProductId = 19, ProductName= "Teatime Chocolate Biscuits", CategoryId = 3, Discontinued = false, QuantityPerUnit = "10 boxes x 12 pieces", ReorderLevel = 5, SupplierId = 8, UnitPrice = 9.20m,UnitsInStock = 25,UnitsOnOrder= 0 },
new Product { ProductId = 20, ProductName= "Sir Rodney's Marmalade", CategoryId = 3, Discontinued = false, QuantityPerUnit = "30 gimt boxes", ReorderLevel = 0, SupplierId = 8, UnitPrice = 81.00m,UnitsInStock = 40,UnitsOnOrder= 0 },
new Product { ProductId = 21, ProductName= "Sir Rodney's Scones", CategoryId = 3, Discontinued = false, QuantityPerUnit = "24 pkgs. x 4 pieces", ReorderLevel = 5, SupplierId = 8, UnitPrice = 10.00m,UnitsInStock = 3,UnitsOnOrder= 40 },
new Product { ProductId = 22, ProductName= "Gustam's Knäckebröd", CategoryId = 5, Discontinued = false, QuantityPerUnit = "24 - 500 g pkgs.", ReorderLevel = 25, SupplierId = 9, UnitPrice = 21.00m,UnitsInStock = 104,UnitsOnOrder= 0 },
new Product { ProductId = 23, ProductName= "Tunnbröd", CategoryId = 5, Discontinued = false, QuantityPerUnit = "12 - 250 g pkgs.", ReorderLevel = 25, SupplierId = 9, UnitPrice = 9.00m,UnitsInStock = 61,UnitsOnOrder= 0 },
new Product { ProductId = 24, ProductName= "Guaraná mantástica", CategoryId = 1, Discontinued = true, QuantityPerUnit = "12 - 355 ml cans", ReorderLevel = 0, SupplierId = 10, UnitPrice = 4.50m,UnitsInStock = 20,UnitsOnOrder= 0 },
new Product { ProductId = 25, ProductName= "NuNuCa Nuß-Nougat-Creme", CategoryId = 3, Discontinued = false, QuantityPerUnit = "20 - 450 g glasses", ReorderLevel = 30, SupplierId = 11, UnitPrice = 14.00m,UnitsInStock = 76,UnitsOnOrder= 0 },
new Product { ProductId = 26, ProductName= "Gumbär Gummibärchen", CategoryId = 3, Discontinued = false, QuantityPerUnit = "100 - 250 g bags", ReorderLevel = 0, SupplierId = 11, UnitPrice = 31.23m,UnitsInStock = 15,UnitsOnOrder= 0 },
new Product { ProductId = 27, ProductName= "Schoggi Schokolade", CategoryId = 3, Discontinued = false, QuantityPerUnit = "100 - 100 g pieces", ReorderLevel = 30, SupplierId = 11, UnitPrice = 43.90m,UnitsInStock = 49,UnitsOnOrder= 0 },
new Product { ProductId = 28, ProductName= "Rössle Sauerkraut", CategoryId = 7, Discontinued = true, QuantityPerUnit = "25 - 825 g cans", ReorderLevel = 0, SupplierId = 12, UnitPrice = 45.60m,UnitsInStock = 26,UnitsOnOrder= 0 },
new Product { ProductId = 29, ProductName= "Thüringer Rostbratwurst", CategoryId = 6, Discontinued = true, QuantityPerUnit = "50 bags x 30 sausgs.", ReorderLevel = 0, SupplierId = 12, UnitPrice = 123.79m,UnitsInStock = 0,UnitsOnOrder= 0 },
new Product { ProductId = 30, ProductName= "Nord-Ost Matjeshering", CategoryId = 8, Discontinued = false, QuantityPerUnit = "10 - 200 g glasses", ReorderLevel = 15, SupplierId = 13, UnitPrice = 25.89m,UnitsInStock = 10,UnitsOnOrder= 0 },
new Product { ProductId = 31, ProductName= "Gorgonzola Telino", CategoryId = 4, Discontinued = false, QuantityPerUnit = "12 - 100 g pkgs", ReorderLevel = 20, SupplierId = 14, UnitPrice = 12.50m,UnitsInStock = 0,UnitsOnOrder= 70 },
new Product { ProductId = 32, ProductName= "Mascarpone mabioli", CategoryId = 4, Discontinued = false, QuantityPerUnit = "24 - 200 g pkgs.", ReorderLevel = 25, SupplierId = 14, UnitPrice = 32.00m,UnitsInStock = 9,UnitsOnOrder= 40 },
new Product { ProductId = 33, ProductName= "Geitost", CategoryId = 4, Discontinued = false, QuantityPerUnit = "500 g", ReorderLevel = 20, SupplierId = 15, UnitPrice = 2.50m,UnitsInStock = 112,UnitsOnOrder= 0 },
new Product { ProductId = 34, ProductName= "Sasquatch Ale", CategoryId = 1, Discontinued = false, QuantityPerUnit = "24 - 12 oz bottles", ReorderLevel = 15, SupplierId = 16, UnitPrice = 14.00m,UnitsInStock = 111,UnitsOnOrder= 0 },
new Product { ProductId = 35, ProductName= "Steeleye Stout", CategoryId = 1, Discontinued = false, QuantityPerUnit = "24 - 12 oz bottles", ReorderLevel = 15, SupplierId = 16, UnitPrice = 18.00m,UnitsInStock = 20,UnitsOnOrder= 0 },
new Product { ProductId = 36, ProductName= "Inlagd Sill", CategoryId = 8, Discontinued = false, QuantityPerUnit = "24 - 250 g  jars", ReorderLevel = 20, SupplierId = 17, UnitPrice = 19.00m,UnitsInStock = 112,UnitsOnOrder= 0 },
new Product { ProductId = 37, ProductName= "Gravad lax", CategoryId = 8, Discontinued = false, QuantityPerUnit = "12 - 500 g pkgs.", ReorderLevel = 25, SupplierId = 17, UnitPrice = 26.00m,UnitsInStock = 11,UnitsOnOrder= 50 },
new Product { ProductId = 38, ProductName= "Côte de Blaye", CategoryId = 1, Discontinued = false, QuantityPerUnit = "12 - 75 cl bottles", ReorderLevel = 15, SupplierId = 18, UnitPrice = 263.50m,UnitsInStock = 17,UnitsOnOrder= 0 },
new Product { ProductId = 39, ProductName= "Chartreuse verte", CategoryId = 1, Discontinued = false, QuantityPerUnit = "750 cc per bottle", ReorderLevel = 5, SupplierId = 18, UnitPrice = 18.00m,UnitsInStock = 69,UnitsOnOrder= 0 },
new Product { ProductId = 40, ProductName= "Boston Crab Meat", CategoryId = 8, Discontinued = false, QuantityPerUnit = "24 - 4 oz tins", ReorderLevel = 30, SupplierId = 19, UnitPrice = 18.40m,UnitsInStock = 123,UnitsOnOrder= 0 },
new Product { ProductId = 41, ProductName= "Jack's New England Clam Chowder", CategoryId = 8, Discontinued = false, QuantityPerUnit = "12 - 12 oz cans", ReorderLevel = 10, SupplierId = 19, UnitPrice = 9.65m,UnitsInStock = 85,UnitsOnOrder= 0 },
new Product { ProductId = 42, ProductName= "Singaporean Hokkien mried Mee", CategoryId = 5, Discontinued = true, QuantityPerUnit = "32 - 1 kg pkgs.", ReorderLevel = 0, SupplierId = 20, UnitPrice = 14.00m,UnitsInStock = 26,UnitsOnOrder= 0 },
new Product { ProductId = 43, ProductName= "Ipoh Commee", CategoryId = 1, Discontinued = false, QuantityPerUnit = "16 - 500 g tins", ReorderLevel = 25, SupplierId = 20, UnitPrice = 46.00m,UnitsInStock = 17,UnitsOnOrder= 10 },
new Product { ProductId = 44, ProductName= "Gula Malacca", CategoryId = 2, Discontinued = false, QuantityPerUnit = "20 - 2 kg bags", ReorderLevel = 15, SupplierId = 20, UnitPrice = 19.45m,UnitsInStock = 27,UnitsOnOrder= 0 },
new Product { ProductId = 45, ProductName= "Rogede sild", CategoryId = 8, Discontinued = false, QuantityPerUnit = "1k pkg.", ReorderLevel = 15, SupplierId = 21, UnitPrice = 9.50m,UnitsInStock = 5,UnitsOnOrder= 70 },
new Product { ProductId = 46, ProductName= "Spegesild", CategoryId = 8, Discontinued = false, QuantityPerUnit = "4 - 450 g glasses", ReorderLevel = 0, SupplierId = 21, UnitPrice = 12.00m,UnitsInStock = 95,UnitsOnOrder= 0 },
new Product { ProductId = 47, ProductName= "Zaanse koeken", CategoryId = 3, Discontinued = false, QuantityPerUnit = "10 - 4 oz boxes", ReorderLevel = 0, SupplierId = 22, UnitPrice = 9.50m,UnitsInStock = 36,UnitsOnOrder= 0 },
new Product { ProductId = 48, ProductName= "Chocolade", CategoryId = 3, Discontinued = false, QuantityPerUnit = "10 pkgs.", ReorderLevel = 25, SupplierId = 22, UnitPrice = 12.75m,UnitsInStock = 15,UnitsOnOrder= 70 },
new Product { ProductId = 49, ProductName= "Maxilaku", CategoryId = 3, Discontinued = false, QuantityPerUnit = "24 - 50 g pkgs.", ReorderLevel = 15, SupplierId = 23, UnitPrice = 20.00m,UnitsInStock = 10,UnitsOnOrder= 60 },
new Product { ProductId = 50, ProductName= "Valkoinen suklaa", CategoryId = 3, Discontinued = false, QuantityPerUnit = "12 - 100 g bars", ReorderLevel = 30, SupplierId = 23, UnitPrice = 16.25m,UnitsInStock = 65,UnitsOnOrder= 0 },
new Product { ProductId = 51, ProductName= "Manjimup Dried Apples", CategoryId = 7, Discontinued = false, QuantityPerUnit = "50 - 300 g pkgs.", ReorderLevel = 10, SupplierId = 24, UnitPrice = 53.00m,UnitsInStock = 20,UnitsOnOrder= 0 },
new Product { ProductId = 52, ProductName= "milo Mix", CategoryId = 5, Discontinued = false, QuantityPerUnit = "16 - 2 kg boxes", ReorderLevel = 25, SupplierId = 24, UnitPrice = 7.00m,UnitsInStock = 38,UnitsOnOrder= 0 },
new Product { ProductId = 53, ProductName= "Perth Pasties", CategoryId = 6, Discontinued = true, QuantityPerUnit = "48 pieces", ReorderLevel = 0, SupplierId = 24, UnitPrice = 32.80m,UnitsInStock = 0,UnitsOnOrder= 0 },
new Product { ProductId = 54, ProductName= "Tourtière", CategoryId = 6, Discontinued = false, QuantityPerUnit = "16 pies", ReorderLevel = 10, SupplierId = 25, UnitPrice = 7.45m,UnitsInStock = 21,UnitsOnOrder= 0 },
new Product { ProductId = 55, ProductName= "Pâté chinois", CategoryId = 6, Discontinued = false, QuantityPerUnit = "24 boxes x 2 pies", ReorderLevel = 20, SupplierId = 25, UnitPrice = 24.00m,UnitsInStock = 115,UnitsOnOrder= 0 },
new Product { ProductId = 56, ProductName= "Gnocchi di nonna Alice", CategoryId = 5, Discontinued = false, QuantityPerUnit = "24 - 250 g pkgs.", ReorderLevel = 30, SupplierId = 26, UnitPrice = 38.00m,UnitsInStock = 21,UnitsOnOrder= 10 },
new Product { ProductId = 57, ProductName= "Ravioli Angelo", CategoryId = 5, Discontinued = false, QuantityPerUnit = "24 - 250 g pkgs.", ReorderLevel = 20, SupplierId = 26, UnitPrice = 19.50m,UnitsInStock = 36,UnitsOnOrder= 0 },
new Product { ProductId = 58, ProductName= "Escargots de Bourgogne", CategoryId = 8, Discontinued = false, QuantityPerUnit = "24 pieces", ReorderLevel = 20, SupplierId = 27, UnitPrice = 13.25m,UnitsInStock = 62,UnitsOnOrder= 0 },
new Product { ProductId = 59, ProductName= "Raclette Courdavault", CategoryId = 4, Discontinued = false, QuantityPerUnit = "5 kg pkg.", ReorderLevel = 0, SupplierId = 28, UnitPrice = 55.00m,UnitsInStock = 79,UnitsOnOrder= 0 },
new Product { ProductId = 60, ProductName= "Camembert Pierrot", CategoryId = 4, Discontinued = false, QuantityPerUnit = "15 - 300 g rounds", ReorderLevel = 0, SupplierId = 28, UnitPrice = 34.00m,UnitsInStock = 19,UnitsOnOrder= 0 },
new Product { ProductId = 61, ProductName= "Sirop d'érable", CategoryId = 2, Discontinued = false, QuantityPerUnit = "24 - 500 ml bottles", ReorderLevel = 25, SupplierId = 29, UnitPrice = 28.50m,UnitsInStock = 113,UnitsOnOrder= 0 },
new Product { ProductId = 62, ProductName= "Tarte au sucre", CategoryId = 3, Discontinued = false, QuantityPerUnit = "48 pies", ReorderLevel = 0, SupplierId = 29, UnitPrice = 49.30m,UnitsInStock = 17,UnitsOnOrder= 0 },
new Product { ProductId = 63, ProductName= "Vegie-spread", CategoryId = 2, Discontinued = false, QuantityPerUnit = "15 - 625 g jars", ReorderLevel = 5, SupplierId = 7, UnitPrice = 43.90m,UnitsInStock = 24,UnitsOnOrder= 0 },
new Product { ProductId = 64, ProductName= "Wimmers gute Semmelknödel", CategoryId = 5, Discontinued = false, QuantityPerUnit = "20 bags x 4 pieces", ReorderLevel = 30, SupplierId = 12, UnitPrice = 33.25m,UnitsInStock = 22,UnitsOnOrder= 80 },
new Product { ProductId = 65, ProductName= "Louisiana miery Hot Pepper Sauce", CategoryId = 2, Discontinued = false, QuantityPerUnit = "32 - 8 oz bottles", ReorderLevel = 0, SupplierId = 2, UnitPrice = 21.05m,UnitsInStock = 76,UnitsOnOrder= 0 },
new Product { ProductId = 66, ProductName= "Louisiana Hot Spiced Okra", CategoryId = 2, Discontinued = false, QuantityPerUnit = "24 - 8 oz jars", ReorderLevel = 20, SupplierId = 2, UnitPrice = 17.00m,UnitsInStock = 4,UnitsOnOrder= 100 },
new Product { ProductId = 67, ProductName= "Laughing Lumberjack Lager", CategoryId = 1, Discontinued = false, QuantityPerUnit = "24 - 12 oz bottles", ReorderLevel = 10, SupplierId = 16, UnitPrice = 14.00m,UnitsInStock = 52,UnitsOnOrder= 0 },
new Product { ProductId = 68, ProductName= "Scottish Longbreads", CategoryId = 3, Discontinued = false, QuantityPerUnit = "10 boxes x 8 pieces", ReorderLevel = 15, SupplierId = 8, UnitPrice = 12.50m,UnitsInStock = 6,UnitsOnOrder= 10 },
new Product { ProductId = 69, ProductName= "Gudbrandsdalsost", CategoryId = 4, Discontinued = false, QuantityPerUnit = "10 kg pkg.", ReorderLevel = 15, SupplierId = 15, UnitPrice = 36.00m,UnitsInStock = 26,UnitsOnOrder= 0 },
new Product { ProductId = 70, ProductName= "Outback Lager", CategoryId = 1, Discontinued = false, QuantityPerUnit = "24 - 355 ml bottles", ReorderLevel = 30, SupplierId = 7, UnitPrice = 15.00m,UnitsInStock = 15,UnitsOnOrder= 10 },
new Product { ProductId = 71, ProductName= "mlotemysost", CategoryId = 4, Discontinued = false, QuantityPerUnit = "10 - 500 g pkgs.", ReorderLevel = 0, SupplierId = 15, UnitPrice = 21.50m,UnitsInStock = 26,UnitsOnOrder= 0 },
new Product { ProductId = 72, ProductName= "Mozzarella di Giovanni", CategoryId = 4, Discontinued = false, QuantityPerUnit = "24 - 200 g pkgs.", ReorderLevel = 0, SupplierId = 14, UnitPrice = 34.80m,UnitsInStock = 14,UnitsOnOrder= 0 },
new Product { ProductId = 73, ProductName= "Röd Kaviar", CategoryId = 8, Discontinued = false, QuantityPerUnit = "24 - 150 g jars", ReorderLevel = 5, SupplierId = 17, UnitPrice = 15.00m,UnitsInStock = 101,UnitsOnOrder= 0 },
new Product { ProductId = 74, ProductName= "Longlime Tomu", CategoryId = 7, Discontinued = false, QuantityPerUnit = "5 kg pkg.", ReorderLevel = 5, SupplierId = 4, UnitPrice = 10.00m,UnitsInStock = 4,UnitsOnOrder= 20 },
new Product { ProductId = 75, ProductName= "Rhönbräu Klosterbier", CategoryId = 1, Discontinued = false, QuantityPerUnit = "24 - 0.5 l bottles", ReorderLevel = 25, SupplierId = 12, UnitPrice = 7.75m,UnitsInStock = 125,UnitsOnOrder= 0 },
new Product { ProductId = 76, ProductName= "Lakkalikööri", CategoryId = 1, Discontinued = false, QuantityPerUnit = "500 ml", ReorderLevel = 20, SupplierId = 23, UnitPrice = 18.00m,UnitsInStock = 57,UnitsOnOrder= 0 },
new Product { ProductId = 77, ProductName= "Original mrankmurter grüne Soße", CategoryId = 2, Discontinued = false, QuantityPerUnit = "12 boxes", ReorderLevel = 15, SupplierId = 12, UnitPrice = 13.00m,UnitsInStock = 32,UnitsOnOrder= 0 },
},
            Date=DateTime.Now
    };
        
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger,IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            if (!_memoryCache.TryGetValue(CACHE_HOMEVM, out string homeVM))
            {
                _homeVM.Date = DateTime.Now;
                homeVM = JsonSerializer.Serialize(_homeVM);
            }
            return View(JsonSerializer.Deserialize<HomeVM>(homeVM));
        }

        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                _homeVM.Products.Add(product);
                _memoryCache.TryGetValue(CACHE_HOMEVM, out string homeVM);

                _homeVM.Date = DateTime.Now;
                homeVM = JsonSerializer.Serialize(_homeVM);
                _memoryCache.Set(CACHE_HOMEVM, homeVM);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _homeVM.Products == null)
            {
                return NotFound();
            }

            var product = _homeVM.Products.Find(x=>x.ProductId==id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
             
                    Product existed = _homeVM.Products.FirstOrDefault(x=>x.ProductId==id);
                    if (existed==null) return NotFound();
                    
                    _homeVM.Products.Remove(existed);
                    _homeVM.Products.Add(product);
                _memoryCache.TryGetValue(CACHE_HOMEVM, out string homeVM);

                _homeVM.Date = DateTime.Now;
                homeVM = JsonSerializer.Serialize(_homeVM);
                _memoryCache.Set(CACHE_HOMEVM, homeVM);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }


        public  IActionResult Delete(int? id)
        {
            if (id == null ||_homeVM.Products == null)
            {
                return NotFound();
            }

            var product =  _homeVM.Products.FirstOrDefault(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_homeVM.Products == null)
            {
                return Problem("Entity set Products  are null.");
            }
            var product = _homeVM.Products.Find(x=>x.ProductId==id);
            if (product != null)
            {
                _homeVM.Products.Remove(product);
                _memoryCache.TryGetValue(CACHE_HOMEVM, out string homeVM);
                
                    _homeVM.Date = DateTime.Now;
                    homeVM = JsonSerializer.Serialize(_homeVM);
                    _memoryCache.Set(CACHE_HOMEVM, homeVM);
                
            }
            return RedirectToAction(nameof(Index));
        }
    }
}