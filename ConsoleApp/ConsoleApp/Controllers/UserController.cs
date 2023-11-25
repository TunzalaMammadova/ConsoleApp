using System;
using System.Xml.Linq;
using Domain.Models;
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
            Name: ConsoleColor.DarkBlue.WriteConsole("Please enter your name:");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Name;
            }

            Surname: ConsoleColor.DarkBlue.WriteConsole("Please enter your surname:");
            string surname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Surname;
            }

            
            Age: ConsoleColor.DarkBlue.WriteConsole("Please enter your age:");
            string intStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(intStr))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Age;
            }
            int age;
            bool IsCorrectAge = int.TryParse(intStr, out age);
            if (IsCorrectAge is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong,please try again");
                goto Age;
            }

            Email: ConsoleColor.DarkBlue.WriteConsole("Please enter your email");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Email;
            }
            else if (!email.CheckEmail())
            {
                ConsoleColor.Red.WriteConsole("Format is wrong, please try again");
                goto Email;
            }
            else
            {
                email.CheckEmail();
            }
            
            Password: ConsoleColor.White.WriteConsole("Please enter your password");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {   
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Password;
            }

            ConsoleColor.White.WriteConsole("Please enter your confirmpassword");
            string confirmPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(confirmPassword) || confirmPassword != password)
            {
                ConsoleColor.Red.WriteConsole("Password does not match ,please try again");
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

            ConsoleColor.DarkGreen.WriteConsole("Registration is successfull");
        }


        public void Login()
        {
            Email: ConsoleColor.DarkBlue.WriteConsole("Please enter your email:");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                
            }
            else if (!email.CheckEmail())
            {
                ConsoleColor.Red.WriteConsole("Format is wrong, please try again");
                
            }

            ConsoleColor.White.WriteConsole("Please enter your password:");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
            }



            if (_userService.Login(email, password))
            {
                ConsoleColor.Green.WriteConsole("Login Successfull");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Username or password incorrect");
                goto Email;
            }

           

        }



    }
}

