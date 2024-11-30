using LINQDemoExample;
using System;

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>()
        {
            new Product{Id=1,Name="Mouse",Price=799,CompanyName="Dell"},
            new Product{Id=2,Name="Mouse",Price=699,CompanyName="Lenovo"},
            new Product{Id=3,Name="Laptop",Price=34799,CompanyName="Dell"},
            new Product{Id=4,Name="Laptop",Price=45799,CompanyName="Sony"},
            new Product{Id=5,Name="Laptop",Price=38799,CompanyName="Lenovo"},
            new Product{Id=6,Name="Keyboard",Price=599,CompanyName="Dell"},
            new Product{Id=7,Name="Keyboard",Price=999,CompanyName="Microsoft"},
            new Product{Id=8,Name="RAM 4GB",Price=2799,CompanyName="Corsair"},
            new Product{Id=9,Name="Speaker",Price=5799,CompanyName="Sony"},
            new Product{Id=10,Name="USB Mouse",Price=1299,CompanyName="Microsoft"},
        };

        // 1. Display all products
        var allProducts = from p in products
                          select p;
        Console.WriteLine("All Products:");
        foreach (var product in allProducts)
            Console.WriteLine($"{product.Name} - {product.CompanyName} - {product.Price}");

        // 2. Products with price greater than 1500
        var priceGreaterThan1500 = from p in products
                                   where p.Price > 1500
                                   select p;
        Console.WriteLine("\nProducts with price > 1500:");
        foreach (var product in priceGreaterThan1500)
            Console.WriteLine($"{product.Name} - {product.Price}");

        // 3. Products with price between 10000 and 40000
        var priceBetween10000And40000 = from p in products
                                        where p.Price >= 10000 && p.Price <= 40000
                                        select p;
        Console.WriteLine("\nProducts with price between 10000 and 40000:");
        foreach (var product in priceBetween10000And40000)
            Console.WriteLine($"{product.Name} - {product.Price}");

        // 4. Products of Dell company
        var dellProducts = from p in products
                           where p.CompanyName == "Dell"
                           select p;
        Console.WriteLine("\nDell Products:");
        foreach (var product in dellProducts)
            Console.WriteLine($"{product.Name} - {product.Price}");

        // 5. All company laptops
        var laptops = from p in products
                      where p.Name.Contains("Laptop")
                      select p;
        Console.WriteLine("\nAll Laptops:");
        foreach (var product in laptops)
            Console.WriteLine($"{product.Name} - {product.CompanyName} - {product.Price}");

        // 6. Products with company name starting with 'M'
        var companyStartsWithM = from p in products
                                 where p.CompanyName.StartsWith("M")
                                 select p;
        Console.WriteLine("\nProducts with company name starting with 'M':");
        foreach (var product in companyStartsWithM)
            Console.WriteLine($"{product.Name} - {product.CompanyName}");

        // 7. All company mouse whose price is less than 1000
        var mouseUnder1000 = from p in products
                             where p.Name.Contains("Mouse") && p.Price < 1000
                             select p;
        Console.WriteLine("\nMouse under 1000:");
        foreach (var product in mouseUnder1000)
            Console.WriteLine($"{product.Name} - {product.CompanyName} - {product.Price}");

        // 8. All products in descending order by price
        var descendingByPrice = from p in products
                                orderby p.Price descending
                                select p;
        Console.WriteLine("\nProducts in descending order by price:");
        foreach (var product in descendingByPrice)
            Console.WriteLine($"{product.Name} - {product.Price}");

        // 9. All products in ascending order by company name
        var ascendingByCompany = from p in products
                                 orderby p.CompanyName
                                 select p;
        Console.WriteLine("\nProducts in ascending order by company name:");
        foreach (var product in ascendingByCompany)
            Console.WriteLine($"{product.Name} - {product.CompanyName}");

        // 10. All keyboards in ascending order by price
        var keyboardsByPrice = from p in products
                               where p.Name.Contains("Keyboard")
                               orderby p.Price
                               select p;
        Console.WriteLine("\nKeyboards in ascending order by price:");
        foreach (var product in keyboardsByPrice)
            Console.WriteLine($"{product.Name} - {product.Price}");
        // Lambda Queries

        // 1. Products in descending order by price
        var lambdaDescendingByPrice = products.OrderByDescending(p => p.Price);
        Console.WriteLine("\nProducts (Lambda) in descending order by price:");
        foreach (var product in lambdaDescendingByPrice)
            Console.WriteLine($"{product.Name} - {product.Price}");

        // 2. Product with Id 5
        var productWithId5 = products.FirstOrDefault(p => p.Id == 5);
        Console.WriteLine("\nProduct with Id 5:");
        Console.WriteLine($"{productWithId5?.Name} - {productWithId5?.Price}");

        // 3. Products with price less than 5000
        var priceUnder5000 = products.Where(p => p.Price < 5000);
        Console.WriteLine("\nProducts with price < 5000:");
        foreach (var product in priceUnder5000)
            Console.WriteLine($"{product.Name} - {product.Price}");

        // 4. Top 3 products with maximum price
        var top3MaxPrice = products.OrderByDescending(p => p.Price).Take(3);
        Console.WriteLine("\nTop 3 products with maximum price:");
        foreach (var product in top3MaxPrice)
            Console.WriteLine($"{product.Name} - {product.Price}");

        // 5. Top 5 products with minimum price
        var top5MinPrice = products.OrderBy(p => p.Price).Take(5);
        Console.WriteLine("\nTop 5 products with minimum price:");
        foreach (var product in top5MinPrice)
            Console.WriteLine($"{product.Name} - {product.Price}");

    }
}
