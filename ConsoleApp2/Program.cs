using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;
            while (menu)
            {


                Console.WriteLine("1.Регистрация");
                Console.WriteLine("2.Выход");
                Console.WriteLine("Введите номер команды: ");
                int number = int.Parse(Console.ReadLine());
                if (number == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Введите Имя, Фамилию: ");
                    string FIO = Console.ReadLine();

                    Console.WriteLine("Введите возраст: ");
                    string age = Console.ReadLine();

                    Console.WriteLine("Введите дату рождения(дд.мм.гггг):");
                    string birth = Console.ReadLine();
                    Console.WriteLine("Введите номер телефона:");
                    string phoneNumber = Console.ReadLine();
                    Random random = new Random();
                    int code = random.Next(0000, 9999);
                    string codeNumber = code.ToString();
                    TwilioClient.Init("AC1a598276587b64428ea8138a1bff7d43", "e3ee1f130c64e73d0cd7600877b86c84");
                    MessageResource.Create(
                        to: new PhoneNumber(phoneNumber),
                        from: new PhoneNumber("+12053786345"),
                        body: codeNumber);
                    Console.WriteLine(code);
                    Console.WriteLine("Введите отправленный код: ");
                    string answer = Console.ReadLine();
                    if (answer == codeNumber)
                    {
                        Console.WriteLine("Код верный!!!");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else if (answer != codeNumber)
                    {
                        Console.WriteLine("Введите повторно отправленный код: ");
                        TwilioClient.Init("AC1a598276587b64428ea8138a1bff7d43", "e3ee1f130c64e73d0cd7600877b86c84");
                        MessageResource.Create(
                            to: new PhoneNumber(phoneNumber),
                            from: new PhoneNumber("+12053786345"),
                            body: codeNumber);
                        Console.WriteLine(code);
                    }
                    Console.ReadKey();
                }
                else if (number == 2)
                {
                    Environment.Exit(0);
                }
                Console.ReadKey();
            }
        }
    }
}


