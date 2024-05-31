using System;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.X86;

namespace _31._05._24
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=2054;Initial Catalog=31.05.24;Integrated Security=True";

            while (true)
            {
                Console.WriteLine("Оберіть опцію:");
                Console.WriteLine("1. Під'єднатися до бази даних");
                Console.WriteLine("2. Від'єднатися від бази даних");
                Console.WriteLine("3. Відобразити усіх покупців");
                Console.WriteLine("4. Відобразити email усіх покупців");
                Console.WriteLine("5. Відобразити список розділів");
                Console.WriteLine("6. Відобразити список акційних товарів");
                Console.WriteLine("7. Відобразити усі міста");
                Console.WriteLine("8. Відобразити усі країни");
                Console.WriteLine("9. Відобразити усіх покупців з певного міста");
                Console.WriteLine("10. Відобразити усіх покупців з певної країни");
                Console.WriteLine("11. Відобразити усі акції для певної країни");
                Console.WriteLine("12. Вихід");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ConnectToDatabase(connectionString);
                        break;
                    case "2":
                        DisconnectFromDatabase();
                        break;
                    case "3":
                        DisplayAllCustomers(connectionString);
                        break;
                    case "4":
                        DisplayAllCustomerEmails(connectionString);
                        break;
                    case "5":
                        DisplayAllSections(connectionString);
                        break;
                    case "6":
                        DisplayAllPromotions(connectionString);
                        break;
                    case "7":
                        DisplayAllCities(connectionString);
                        break;
                    case "8":
                        DisplayAllCountries(connectionString);
                        break;
                    case "9":
                        DisplayCustomersByCity(connectionString);
                        break;
                    case "10":
                        DisplayCustomersByCountry(connectionString);
                        break;
                    case "11":
                        DisplayPromotionsByCountry(connectionString);
                        break;
                    case "12":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void ConnectToDatabase(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Успішно під'єднано до бази даних!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при під'єднанні до бази даних: " + ex.Message);
            }
        }

        static void DisconnectFromDatabase()
        {
            Console.WriteLine("Від'єднання від бази даних здійснюється автоматично після завершення роботи з підключенням.");
        }

        static void DisplayAllCustomers(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT FullName FROM Customers";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["FullName"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при відображенні покупців: " + ex.Message);
            }
        }

        static void DisplayAllCustomerEmails(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Email FROM Customers";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Email"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при відображенні email покупців: " + ex.Message);
            }
        }

        static void DisplayAllSections(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT Section FROM Promotions";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Section"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при відображенні розділів: " + ex.Message);
            }
        }

        static void DisplayAllPromotions(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Product FROM Promotions";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Product"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при відображенні акційних товарів: " + ex.Message);
            }
        }

        static void DisplayAllCities(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT City FROM Customers";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["City"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при відображенні міст: " + ex.Message);
            }
        }

        static void DisplayAllCountries(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT Country FROM Customers";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Country"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при відображенні країн: " + ex.Message);
            }
        }

        static void DisplayCustomersByCity(string connectionString)
        {
            try
            {
                Console.Write("Введіть назву міста: ");
                string city = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT FullName FROM Customers WHERE City = @City";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@City", city);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["FullName"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при відображенні покупців за містом: " + ex.Message);
            }
        }

        static void DisplayCustomersByCountry(string connectionString)
        {
            try
            {
                Console.Write("Введіть назву країни: ");
                string country = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT FullName FROM Customers WHERE Country = @Country";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Country", country);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["FullName"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при відображенні покупців за країною: " + ex.Message);
            }
        }

        static void DisplayPromotionsByCountry(string connectionString)
        {
            try
            {
                Console.Write("Введіть назву країни: ");
                string country = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Product FROM Promotions WHERE Country = @Country";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Country", country);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Product"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при відображенні акцій для країни: " + ex.Message);
            }
        }
    }
}


//CREATE DATABASE 31.05.24;

//USE 31.05.24;

//CREATE TABLE Customers (
//    Id INT PRIMARY KEY IDENTITY,
//    FullName NVARCHAR(100),
//    BirthDate DATE,
//    Gender NVARCHAR(10),
//    Email NVARCHAR(100),
//    Country NVARCHAR(50),
//    City NVARCHAR(50)
//);

//CREATE TABLE Promotions (
//    Id INT PRIMARY KEY IDENTITY,
//    Country NVARCHAR(50),
//    Section NVARCHAR(50),
//    Product NVARCHAR(50),
//    StartDate DATE,
//    EndDate DATE
//);
