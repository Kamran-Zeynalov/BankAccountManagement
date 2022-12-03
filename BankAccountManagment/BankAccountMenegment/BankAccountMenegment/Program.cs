using BankAccountMenegment.Base;
using BankAccountMenegment.Service;

namespace BankAccountMenegment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char selection;
            Console.WriteLine("Welcome our Cinema");
            do
            { 
                Console.WriteLine("1. User registration");
                Console.WriteLine("2. User login");
                //Console.WriteLine("3. Find user");
                //Console.WriteLine("4. Check Balance");
                //Console.WriteLine("5. Top up balance");
                //Console.WriteLine("6. Change Password");
                //Console.WriteLine("7. Bank user list");
                //Console.WriteLine("8. Block User");
            selection:
                selection = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (selection)
                {
                    case '1':
                        MenuService.UserRegistrstion();
                        Console.Clear();
                        break;
                    case '2':
                        MenuService.Login();
                        Console.Clear();
                        break;
                    case '3':
                        MenuService.FindUser();
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                    case '4':
                        MenuService.CheckBalance();
                        Console.Clear();
                        break;
                    case '5':
                        MenuService.TopUpBalance();
                        Console.Clear();
                        break;
                    case '6':
                        MenuService.ChanegePassword();
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                    case '7':
                        MenuService.UserList();
                        Console.Clear();
                        break;
                    case '8':
                        MenuService.BlockUser();
                        Console.Clear();
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Please choose correct number");
                        Console.Clear();
                        goto selection;
                }
            } while (selection != '0');
        }
    }
}