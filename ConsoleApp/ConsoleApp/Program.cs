using System.Numerics;
using ConsoleApp.Controllers;
using Repository.Enums;
using Service.Helpers.Extensions;




UserController userController = new();
GroupController groupController = new();
StudentController studentController = new();



while (true)
{
    GetMenues();

    string operationStr = Console.ReadLine();
    int operation;
    bool isCorrectOperation = int.TryParse(operationStr, out operation);
    
    
        switch (operation)
        {
            case (int)OperationType.Register:
                userController.Register();
                break;
            case (int)OperationType.Login:
                userController.Login();
                goto NextOperation;
            default:
            ConsoleColor.Red.WriteConsole("Operation format is wrong,please select again:");
                break;

               

        }
  
}
NextOperation: Console.WriteLine("Welcome our application");



while (true)
{
  Menues();

    string operationStr = Console.ReadLine();
    int operation;
    bool isCorrectOperation = int.TryParse(operationStr, out operation);

    if (isCorrectOperation)
    {
        switch (operation)
        {   
            case (int)OperationType.GroupCreate:
                groupController.Create();
                break;
            case (int)OperationType.GroupDelete:
                groupController.Delete();
                break;
            case (int)OperationType.GroupEdit:
                groupController.Edit();
                break;
            case (int)OperationType.GroupSearch:
                groupController.Search();
                break;
            case (int)OperationType.GroupSorting:
                groupController.Sorting();
                break;
            case (int)OperationType.GroupGetById:
                groupController.GetById();
                break;
            case (int)OperationType.GroupGetAll:
                groupController.GetAll();
                break;
            case (int)OperationType.StudentCreate:
                studentController.Create();
                break;
            case (int)OperationType.StudentDelete:
                studentController.Delete();
                break;
            case (int)OperationType.StudentEdit:
                studentController.Edit();
                break;
            case (int)OperationType.StudentSearch:
                studentController.Search();
                break;
            case (int)OperationType.StudentSorting:
                studentController.Sorting();
                break;
            case (int)OperationType.StudentGetById:
                studentController.GetById();
                break;
            case (int)OperationType.StudentGetAll:
                studentController.GetAll();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Operation format is wrong,please select again:");
                break;
        }
    }
}






static void GetMenues()
{
    ConsoleColor.White.WriteConsole("Please select option: 1.Register 2.Login");
    
}


static void Menues()
{
    ConsoleColor.DarkBlue.WriteConsole("Group operations: 3.Create, 4.Delete, 5.Edit, 6.Search, 7.Sort, 8.GetById, 9.GetAll");
    ConsoleColor.DarkBlue.WriteConsole("Student operations: 10.Create, 11.Delete, 12.Edit, 13.Search, 14.Sort, 15.GetById, 16.GetAll");

}


