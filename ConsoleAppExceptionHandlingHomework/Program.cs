using System.Net.Http.Headers;

namespace ConsoleAppExceptionHandlingHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserProfile user = new UserProfile();

            Console.Write("Username: ");
            user.username = Console.ReadLine();

            Console.Write("Password: ");
            user.password = Console.ReadLine();

            try
            {
                ValidateUser(user);

                Console.WriteLine("Welcome to the System...");
            }
            catch(InvalidUserCredentialsException e) 
            {
                Logger.LogError(InvalidUserCredentialsException.code, e.Message);
            }
            finally
            {
                Console.WriteLine("Section is finished!");
            }
        }
        class Logger
        {
            public static void LogError(string code, string message)
            {
                Console.Write($"[{DateTime.Now.ToString("HH:mm:ss")} ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ERR");
                Console.ResetColor();
                Console.Write("] ");
                Console.WriteLine($"{code}: {message}");
            }
        }

        static void ValidateUser(UserProfile user)
        {
            if (user.username != "admin" || user.password != "pass")
            {
                throw new InvalidUserCredentialsException();
            }
            else { }
            
        }
        class UserProfile
        {
            public string username = "admin";
            public string password = "pass";
        }
        class InvalidUserCredentialsException : Exception
        {
            public const string code = "invalid_user_credentials";
            public InvalidUserCredentialsException() : base("Username or password is incorrect")
            {
            }
        }
    }
}
