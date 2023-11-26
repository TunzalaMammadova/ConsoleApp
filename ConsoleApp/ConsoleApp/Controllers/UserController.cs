using System;
using System.Xml.Linq;
using Domain.Models;
using Service.Helpers.Constants;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.İnterfaces;

namespace ConsoleApp.Controllers
{
	public class UserController
	{
        private readonly IUserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public void Register()
        {
            Name: ConsoleColor.Yellow.WriteConsole(UserNotification.EnterName);
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole(UserNotification.InputEmptyMessage);
                goto Name;
            }

            Surname: ConsoleColor.Yellow.WriteConsole(UserNotification.EnterSurname);
            string surname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole(UserNotification.InputEmptyMessage);
                goto Surname;
            }

            
            Age: ConsoleColor.Yellow.WriteConsole(UserNotification.EnterAge);
            string intStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(intStr))
            {
                ConsoleColor.Red.WriteConsole(UserNotification.InputEmptyMessage);
                goto Age;
            }

            int age;
            bool IsCorrectAge = int.TryParse(intStr, out age);
            if (IsCorrectAge is false)
            {
                ConsoleColor.Red.WriteConsole(UserNotification.FormatWrongMessage);
                goto Age;
            }

            if (age <= 14 || age > 100)
            {
                ConsoleColor.Red.WriteConsole(UserNotification.CorrectAge);
                goto Age;
            }

            Email: ConsoleColor.Yellow.WriteConsole(UserNotification.EnterMail);
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole(UserNotification.InputEmptyMessage);
                goto Email;
            }
            else if (!email.EmailFormat())
            {
                ConsoleColor.Red.WriteConsole(UserNotification.FormatWrongMessage);
                goto Email;
            }
            else
            {
                email.EmailFormat();
            }
            
            Password: ConsoleColor.Yellow.WriteConsole(UserNotification.EnterPassword);
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {   
                ConsoleColor.Red.WriteConsole(UserNotification.InputEmptyMessage);
                goto Password;
            }

            ConsoleColor.Yellow.WriteConsole(UserNotification.EnterConfirmPassword);
            string confirmPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(confirmPassword) || confirmPassword != password)
            {
                ConsoleColor.Red.WriteConsole(UserNotification.PasswordWrong);
                goto Password;
            }


            User user = new User()
            {
                Name = name,
                Surname = surname,
                Age = age,
                Email = email,
                Password = password
            };

            _userService.Register(user);

            ConsoleColor.DarkGreen.WriteConsole(UserNotification.RegisterSuccess);
        }


        public void Login()
        {
            Email: ConsoleColor.Yellow.WriteConsole(UserNotification.EnterMail);
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole(UserNotification.InputEmptyMessage);
                goto Email;
            }
            else if (!email.EmailFormat())
            {
                ConsoleColor.Red.WriteConsole(UserNotification.FormatWrongMessage);
                goto Email;
                
            }

            Password: ConsoleColor.Yellow.WriteConsole(UserNotification.EnterPassword);
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.Red.WriteConsole(UserNotification.InputEmptyMessage);
                goto Password;
            }



            if (_userService.Login(email, password))
            {
                ConsoleColor.Green.WriteConsole(UserNotification.LoginSuccess);
            }
            else
            {
                ConsoleColor.Red.WriteConsole(UserNotification.LoginIsUnsuccess);
                goto Email;
            }

           

        }



    }
}

