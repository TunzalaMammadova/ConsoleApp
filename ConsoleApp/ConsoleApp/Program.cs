using System.Numerics;
using ConsoleApp.Controllers;
using Service.Helpers.Extensions;


//ConsoleColor.Blue.WriteConsole("P418");


static void GetMenues()
{
    ConsoleColor.DarkBlue.WriteConsole("1.Register 2.Login");
    ConsoleColor.DarkBlue.WriteConsole("Group operations: 3.GroupCreate, 4.GroupDelete, 5.GroupEdit, 6.GroupSearch, 7.GroupSorting, 8.GroupGetById, 9.GroupGetAll");
    ConsoleColor.DarkBlue.WriteConsole("Student operations: 10.StudentCreate, 11.StudentDelete, 12.StudentEdit, 13.StudentSearch, 14.StudentSorting, 15.StudentGetById, 16.StudentGetAll,");

}

//GetMenues();


UserController userController = new();

userController.Register();