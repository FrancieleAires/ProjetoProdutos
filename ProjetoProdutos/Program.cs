using System;
using ProjetoProdutos.Entities;
using System.Globalization;
using System.Collections.Generic;

namespace ProjetoProdutos

{
    internal class Program
    {

        //Feito por FrancieleAires :)

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter the number of products: ");
            Console.ForegroundColor= ConsoleColor.White;
            int n = int.Parse(Console.ReadLine());
            List<Product> list = new List<Product>();

            for(int i = 1; i <= n; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"Product #{i} data: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Common, used or imported (c/u/i)? ");
                char choose = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (choose == 'c')
                {
                    list.Add(new Product(name, price));
                }
                else if (choose == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, date));
                }
                else
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, customsFee));
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("PRICE TAGS: ");
            Console.ForegroundColor = ConsoleColor.White;

            //percorrendo a lista de produtos
            foreach(Product product in list)
            {
                Console.WriteLine(product.PriceTag());
            }
        }
    }
}