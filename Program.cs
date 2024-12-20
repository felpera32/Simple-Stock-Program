using System;
using System.ComponentModel.DataAnnotations;


class Program
{
    static Dictionary<string, int> stock = new Dictionary<string, int>();


    static void Main()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("STOCK");
            Console.WriteLine("[1] Add product");
            Console.WriteLine("[2] Remove product");
            Console.WriteLine("[3] Check stock");
            Console.Write("Choose an option: ");
            string userEsc = Console.ReadLine();
            if(int.TryParse(userEsc, out int esc) && esc > 0 && esc < 4)
            {
                switch (esc)
                {
                    case 1:
                
                        Console.Clear();
                        addProduct();
                        break;

                    case 2:
                        Console.Clear();
                        removeProduct();
                        break;

                    case 3:
                
                        Console.Clear();
                        checkProducts();
                        skip();
                        Console.Clear();
                        break;
                
                }

            }
            else
            {
                Console.WriteLine("Entrada invalida, tente novamente");
                Thread.Sleep(1000);
            }
                
        }
    }




    static void addProduct()
    {   
            Console.Write("Product name: ");
            var productName = Console.ReadLine();

            Console.Write("Amount: ");
            string enterAmount = Console.ReadLine();

            if (int.TryParse(enterAmount, out int amount))
            {
                if (stock.ContainsKey(productName))
                {
                    stock[productName] += amount;
                    Console.WriteLine($"{amount} {productName} were added from stock.");
                }
                else
                {
                    stock.Add(productName, amount);
                    Console.WriteLine($"{amount} {productName} were added from stock.");
                 }

                Console.WriteLine("Product added successfully");
                skip();
                Console.Clear();

            }
        else
            {
                Console.WriteLine("Invalid quantity. Please try again.");
            }



    }


    static void removeProduct()
    {
        Console.WriteLine("Products         |         Amount");

        checkProducts();

        Console.Write("Product name: ");
        string productName = Console.ReadLine();

        if(stock.ContainsKey(productName))
        {
            Console.Write("Amount: ");
            string enterAmount = Console.ReadLine();

            if(int.TryParse(enterAmount, out int amount))
            {
                if(amount > stock[productName] && amount < 1)
                {
                    Console.WriteLine("Invalid quantity.");
                    skip();
                    Console.Clear();


                }
                else
                {
                    stock[productName] -= amount;
                    Console.WriteLine($"{amount} {productName} were removed from stock.");
                    skip();
                    Console.Clear();

                }

                if (stock[productName] == 0)
                {
                    stock.Remove(productName);
                }

            }
            else
            {
                Console.WriteLine("Invalid quantity. Please try again.");
                

            }

        }

        else if(string.IsNullOrEmpty(productName))
        {
            Console.WriteLine("Invalid product name. Please try again.");
            skip();


        }
        else
        {
            Console.WriteLine("product isn't in stock");
            skip();


        }
    }

    static void checkProducts()
    {
        
        if (stock.Count >= 1)
        {
            Console.WriteLine("Products         |         Amount");

            foreach (KeyValuePair<string, int> item in stock)
            {
                Console.WriteLine($"{item.Key}                      {item.Value}");

            }

        }
        else
        {
            Console.WriteLine("No products in stock.");
        }


    }


    static void skip()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}