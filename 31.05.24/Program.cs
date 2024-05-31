using System;
using System.Collections.Generic;

namespace _31._05._24
{
    // Клас для збереження інформації про акції
    public class Promotion
    {
        public string Country { get; set; }
        public string Section { get; set; }
        public string Product { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    // Клас для збереження інформації про покупців
    public class Customer
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public List<string> Interests { get; set; }

        public Customer()
        {
            Interests = new List<string>();
        }
    }

    // Головний клас програми
    public class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            List<Promotion> promotions = new List<Promotion>();

            // Основний цикл програми
            while (true)
            {
                Console.WriteLine("Оберіть опцію:");
                Console.WriteLine("1. Додати покупця");
                Console.WriteLine("2. Додати акцію");
                Console.WriteLine("3. Вихід");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCustomer(customers);
                        break;
                    case "2":
                        AddPromotion(promotions);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void AddCustomer(List<Customer> customers)
        {
            Customer customer = new Customer();

            Console.Write("Введіть ПІБ покупця: ");
            customer.FullName = Console.ReadLine();

            Console.Write("Введіть дату народження (yyyy-mm-dd): ");
            customer.BirthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Введіть стать покупця: ");
            customer.Gender = Console.ReadLine();

            Console.Write("Введіть email покупця: ");
            customer.Email = Console.ReadLine();

            Console.Write("Введіть країну покупця: ");
            customer.Country = Console.ReadLine();

            Console.Write("Введіть місто покупця: ");
            customer.City = Console.ReadLine();

            Console.WriteLine("Введіть перелік розділів, в яких зацікавлений покупець (через кому): ");
            string interests = Console.ReadLine();
            customer.Interests.AddRange(interests.Split(','));

            customers.Add(customer);
            Console.WriteLine("Покупця додано успішно!");
        }

        static void AddPromotion(List<Promotion> promotions)
        {
            Promotion promotion = new Promotion();

            Console.Write("Введіть країну акції: ");
            promotion.Country = Console.ReadLine();

            Console.Write("Введіть розділ акції: ");
            promotion.Section = Console.ReadLine();

            Console.Write("Введіть товар для акції: ");
            promotion.Product = Console.ReadLine();

            Console.Write("Введіть дату старту акції (yyyy-mm-dd): ");
            promotion.StartDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Введіть дату кінця акції (yyyy-mm-dd): ");
            promotion.EndDate = DateTime.Parse(Console.ReadLine());

            promotions.Add(promotion);
            Console.WriteLine("Акцію додано успішно!");
        }
    }
}
