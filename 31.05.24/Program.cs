using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace _31._05._24
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=2560;Initial Catalog=31.05.24;Integrated Security=True";

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
                Console.WriteLine("12. Додати нового покупця");
                Console.WriteLine("13. Додати нову країну");
                Console.WriteLine("14. Додати нове місто");
                Console.WriteLine("15. Додати новий розділ");
                Console.WriteLine("16. Додати новий акційний товар");
                Console.WriteLine("17. Оновити інформацію про покупця");
                Console.WriteLine("18. Оновити інформацію про країну");
                Console.WriteLine("19. Оновити інформацію про місто");
                Console.WriteLine("20. Оновити інформацію про розділ");
                Console.WriteLine("21. Оновити інформацію про акційний товар");
                Console.WriteLine("22. Видалити покупця");
                Console.WriteLine("23. Видалити країну");
                Console.WriteLine("24. Видалити місто");
                Console.WriteLine("25. Видалити розділ");
                Console.WriteLine("26. Видалити акційний товар");
                Console.WriteLine("27. Відобразити список міст певної країни");
                Console.WriteLine("28. Відобразити список розділів певного покупця");
                Console.WriteLine("29. Відобразити список акційних товарів певного розділу");
                Console.WriteLine("30. Вихід");
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
                        AddNewCustomer(connectionString);
                        break;
                    case "13":
                        AddNewCountry(connectionString);
                        break;
                    case "14":
                        AddNewCity(connectionString);
                        break;
                    case "15":
                        AddNewSection(connectionString);
                        break;
                    case "16":
                        AddNewPromotion(connectionString);
                        break;
                    case "17":
                        UpdateCustomer(connectionString);
                        break;
                    case "18":
                        UpdateCountry(connectionString);
                        break;
                    case "19":
                        UpdateCity(connectionString);
                        break;
                    case "20":
                        UpdateSection(connectionString);
                        break;
                    case "21":
                        UpdatePromotion(connectionString);
                        break;
                    case "22":
                        DeleteCustomer(connectionString);
                        break;
                    case "23":
                        DeleteCountry(connectionString);
                        break;
                    case "24":
                        DeleteCity(connectionString);
                        break;
                    case "25":
                        DeleteSection(connectionString);
                        break;
                    case "26":
                        DeletePromotion(connectionString);
                        break;
                    case "27":
                        DisplayCitiesByCountry(connectionString);
                        break;
                    case "28":
                        DisplaySectionsByCustomer(connectionString);
                        break;
                    case "29":
                        DisplayPromotionsBySection(connectionString);
                        break;
                    case "30":
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

        static void AddNewCustomer(string connectionString)
        {
            try
            {
                Console.Write("Введіть ПІБ: ");
                string fullName = Console.ReadLine();
                Console.Write("Введіть дату народження (yyyy-mm-dd): ");
                string birthDate = Console.ReadLine();
                Console.Write("Введіть стать: ");
                string gender = Console.ReadLine();
                Console.Write("Введіть Email: ");
                string email = Console.ReadLine();
                Console.Write("Введіть країну: ");
                string country = Console.ReadLine();
                Console.Write("Введіть місто: ");
                string city = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Customers (FullName, BirthDate, Gender, Email, Country, City) VALUES (@FullName, @BirthDate, @Gender, @Email, @Country, @City)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@BirthDate", birthDate);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Country", country);
                    command.Parameters.AddWithValue("@City", city);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Новий покупець доданий успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при додаванні покупця: " + ex.Message);
            }
        }

        static void AddNewCountry(string connectionString)
        {
            try
            {
                Console.Write("Введіть назву країни: ");
                string country = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Countries (Country) VALUES (@Country)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Country", country);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Нова країна додана успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при додаванні країни: " + ex.Message);
            }
        }

        static void AddNewCity(string connectionString)
        {
            try
            {
                Console.Write("Введіть назву міста: ");
                string city = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Cities (City) VALUES (@City)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@City", city);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Нове місто додане успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при додаванні міста: " + ex.Message);
            }
        }

        static void AddNewSection(string connectionString)
        {
            try
            {
                Console.Write("Введіть назву розділу: ");
                string section = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Sections (Section) VALUES (@Section)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Section", section);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Новий розділ доданий успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при додаванні розділу: " + ex.Message);
            }
        }

        static void AddNewPromotion(string connectionString)
        {
            try
            {
                Console.Write("Введіть назву товару: ");
                string product = Console.ReadLine();
                Console.Write("Введіть розділ: ");
                string section = Console.ReadLine();
                Console.Write("Введіть країну: ");
                string country = Console.ReadLine();
                Console.Write("Введіть дату початку акції (yyyy-mm-dd): ");
                string startDate = Console.ReadLine();
                Console.Write("Введіть дату кінця акції (yyyy-mm-dd): ");
                string endDate = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Promotions (Product, Section, Country, StartDate, EndDate) VALUES (@Product, @Section, @Country, @StartDate, @EndDate)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Product", product);
                    command.Parameters.AddWithValue("@Section", section);
                    command.Parameters.AddWithValue("@Country", country);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Новий акційний товар доданий успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при додаванні акційного товару: " + ex.Message);
            }
        }

        static void UpdateCustomer(string connectionString)
        {
            try
            {
                Console.Write("Введіть ID покупця для оновлення: ");
                int customerId = int.Parse(Console.ReadLine());
                Console.Write("Введіть новий ПІБ: ");
                string fullName = Console.ReadLine();
                Console.Write("Введіть новий Email: ");
                string email = Console.ReadLine();
                Console.Write("Введіть нову країну: ");
                string country = Console.ReadLine();
                Console.Write("Введіть нове місто: ");
                string city = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Customers SET FullName = @FullName, Email = @Email, Country = @Country, City = @City WHERE CustomerId = @CustomerId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Country", country);
                    command.Parameters.AddWithValue("@City", city);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Інформація про покупця оновлена успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при оновленні інформації про покупця: " + ex.Message);
            }
        }

        static void UpdateCountry(string connectionString)
        {
            try
            {
                Console.Write("Введіть стару назву країни для оновлення: ");
                string oldCountry = Console.ReadLine();
                Console.Write("Введіть нову назву країни: ");
                string newCountry = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Countries SET Country = @NewCountry WHERE Country = @OldCountry";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OldCountry", oldCountry);
                    command.Parameters.AddWithValue("@NewCountry", newCountry);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Інформація про країну оновлена успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при оновленні інформації про країну: " + ex.Message);
            }
        }

        static void UpdateCity(string connectionString)
        {
            try
            {
                Console.Write("Введіть стару назву міста для оновлення: ");
                string oldCity = Console.ReadLine();
                Console.Write("Введіть нову назву міста: ");
                string newCity = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Cities SET City = @NewCity WHERE City = @OldCity";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OldCity", oldCity);
                    command.Parameters.AddWithValue("@NewCity", newCity);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Інформація про місто оновлена успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при оновленні інформації про місто: " + ex.Message);
            }
        }

        static void UpdateSection(string connectionString)
        {
            try
            {
                Console.Write("Введіть стару назву розділу для оновлення: ");
                string oldSection = Console.ReadLine();
                Console.Write("Введіть нову назву розділу: ");
                string newSection = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Sections SET Section = @NewSection WHERE Section = @OldSection";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OldSection", oldSection);
                    command.Parameters.AddWithValue("@NewSection", newSection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Інформація про розділ оновлена успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при оновленні інформації про розділ: " + ex.Message);
            }
        }

        static void UpdatePromotion(string connectionString)
        {
            try
            {
                Console.Write("Введіть ID акційного товару для оновлення: ");
                int promotionId = int.Parse(Console.ReadLine());
                Console.Write("Введіть нову назву товару: ");
                string product = Console.ReadLine();
                Console.Write("Введіть новий розділ: ");
                string section = Console.ReadLine();
                Console.Write("Введіть нову країну: ");
                string country = Console.ReadLine();
                Console.Write("Введіть нову дату початку акції (yyyy-mm-dd): ");
                string startDate = Console.ReadLine();
                Console.Write("Введіть нову дату кінця акції (yyyy-mm-dd): ");
                string endDate = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Promotions SET Product = @Product, Section = @Section, Country = @Country, StartDate = @StartDate, EndDate = @EndDate WHERE PromotionId = @PromotionId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PromotionId", promotionId);
                    command.Parameters.AddWithValue("@Product", product);
                    command.Parameters.AddWithValue("@Section", section);
                    command.Parameters.AddWithValue("@Country", country);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Інформація про акційний товар оновлена успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при оновленні інформації про акційний товар: " + ex.Message);
            }
        }

        static void DeleteCustomer(string connectionString)
        {
            try
            {
                Console.Write("Введіть ID покупця для видалення: ");
                int customerId = int.Parse(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Customers WHERE CustomerId = @CustomerId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Покупець видалений успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при видаленні покупця: " + ex.Message);
            }
        }

        static void DeleteCountry(string connectionString)
        {
            try
            {
                Console.Write("Введіть назву країни для видалення: ");
                string country = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Countries WHERE Country = @Country";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Country", country);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Країна видалена успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при видаленні країни: " + ex.Message);
            }
        }

        static void DeleteCity(string connectionString)
        {
            try
            {
                Console.Write("Введіть назву міста для видалення: ");
                string city = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Cities WHERE City = @City";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@City", city);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Місто видалене успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при видаленні міста: " + ex.Message);
            }
        }

        static void DeleteSection(string connectionString)
        {
            try
            {
                Console.Write("Введіть назву розділу для видалення: ");
                string section = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Sections WHERE Section = @Section";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Section", section);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Розділ видалений успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при видаленні розділу: " + ex.Message);
            }
        }

        static void DeletePromotion(string connectionString)
        {
            try
            {
                Console.Write("Введіть ID акційного товару для видалення: ");
                int promotionId = int.Parse(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Promotions WHERE PromotionId = @PromotionId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PromotionId", promotionId);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Акційний товар видалений успішно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при видаленні акційного товару: " + ex.Message);
            }
        }

        static void DisplayCitiesByCountry(string connectionString)
        {
            try
            {
                Console.Write("Введіть назву країни: ");
                string country = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT City FROM Customers WHERE Country = @Country";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Country", country);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["City"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при відображенні міст за країною: " + ex.Message);
            }
        }

        static void DisplaySectionsByCustomer(string connectionString)
        {
            try
            {
                Console.Write("Введіть ID покупця: ");
                int customerId = int.Parse(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Section FROM Promotions WHERE CustomerId = @CustomerId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Section"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при відображенні розділів за покупцем: " + ex.Message);
            }
        }

        static void DisplayPromotionsBySection(string connectionString)
        {
            try
            {
                Console.Write("Введіть назву розділу: ");
                string section = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Product FROM Promotions WHERE Section = @Section";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Section", section);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Product"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при відображенні акційних товарів за розділом: " + ex.Message);
            }
        }
    }
}

