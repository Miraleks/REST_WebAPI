using System;
using Newtonsoft.Json;
using WebClient.Connections;
using WebClient.Generators;

namespace WebClient
{
    static class Program
    {
        static void Main(string[] args)
        {
            StartMenu();                       
        }

        private static void StartMenu()
        {
            ConsoleKeyInfo input;

            do
            {
                Console.WriteLine("Выберите желаемое:");
                Console.WriteLine("1. Создание случайно сгенерированного пользователя на сервере");
                Console.WriteLine("2. Получение данных пользователя по id");
                Console.WriteLine("Esc. Выход");
                input = Console.ReadKey();

                if (input.Key == ConsoleKey.D1)
                {
                    var customer = CustomerGenerator.RandomCustomer();

                    string url = "https://localhost:5001/customers";
                    var response = ConnectorToUrl.POSTConnectionToUrl(url, customer);


                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                }
                else if (input.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("Введите id пользователя для получения данных");
                    var text = Convert.ToInt32(Console.ReadLine());

                    string url = "https://localhost:5001/customers/" + text;

                    var response = ConnectorToUrl.GETConnectionToUrl(url);

                    Customer customer = JsonConvert.DeserializeObject<Customer>(response);

                    Console.WriteLine(customer);
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                }
                Console.Clear();

            } while (input.Key != ConsoleKey.Escape);

            
        }
    }
}