using System.Numerics;
using ConsoleApp.Controllers;
using Repository.Enums;
using Service.Helpers.Extensions;




UserController userController = new();
GroupController groupController = new();

//userController.Register();
//userController.Login();

//groupController.Create();
//groupController.GetAll();



while (true)
{
    GetMenues();

    Operation: string operationStr = Console.ReadLine();
    int operation;
    bool isCorrectOperation = int.TryParse(operationStr, out operation);

    if (isCorrectOperation)
    {
        switch (operation)
        {
            case (int)OperationType.Register:
                userController.Register();
                break;
            case (int)OperationType.Login:
                userController.Login();
                break;
            case (int)OperationType.GroupCreate:
                groupController.Create();
                break;
            case (int)OperationType.GroupGetAll:
                break;
                groupController.GetAll();
            case (int)OperationType.GroupDelete:
                groupController.Delete();
                break;


            default:
                break;
        }
    }
    else
    {
        ConsoleColor.DarkRed.WriteConsole("Operation format is wrong,please select again:");
        goto Operation;
    }

}





static void GetMenues()
{
    ConsoleColor.DarkBlue.WriteConsole("Please select option: 1.Register 2.Login");
    ConsoleColor.DarkBlue.WriteConsole("Group operations: 3.Create, 4.Delete, 5.Edit, 6.Search, 7.Sort, 8.GetById, 9.GetAll");
    ConsoleColor.DarkBlue.WriteConsole("Student operations: 10.Create, 11.Delete, 12.Edit, 13.Search, 14.Sort, 15.GetById, 16.GetAll");

}



