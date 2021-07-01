using SalesIntegrator.Services;
using System;
using SalesIntegrator.Models;
using Microsoft.Extensions.DependencyInjection;
using SalesIntegrator.Views;
using SalesIntegrator.Controllers;
using System.Runtime.InteropServices;
using System.IO;
using SalesIntegrator.Utils;
using SalesIntegrator.Interfaces;

namespace SalesIntegrator
{
    public class Program
    {
        private readonly IController _controller;
        private readonly ISubiektService _subiektService;
        private readonly IDataService _dataService;

        public static FileStream FileStream;
        public static StreamWriter StreamWriter;
        public static DBConnectionModel DBUser;
        public static InsertUserModel InsertUser;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        static int ConsoleVisibility;

        public Program(IController controller, ISubiektService subiektService, IDataService dataService)
        {
            _controller = controller;
            _subiektService = subiektService;
            _dataService = dataService;

        }
        private void HandleSubiekt(DBConnectionModel dbUser, InsertUserModel insertUser)
        {
            _subiektService.StartSubiekt(dbUser, insertUser);
            NonBlockingConsole.WriteLine("Subiekt GT properly started");
            _subiektService.ProcessOrders(_dataService.Orders);
            NonBlockingConsole.WriteLine("JOB FINISHED :)");
            if (ConsoleVisibility != Constants.CONSOLE_HIDDEN)
            {
                NonBlockingConsole.WriteLine("Press any key to close the application.");
                Console.ReadKey();
            }
        }

        static void StartConsole()
        {
            NonBlockingConsole.WriteLine("Press key to select logging type: f - log to file; c - log to console;");
            char key = Console.ReadKey().KeyChar;
            ConsoleVisibility = Constants.CONSOLE_DISPLAY;
            if (key == 'F' || key == 'f')
            {
                string directory = string.Empty;
                while (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
                {
                    NonBlockingConsole.WriteLine(@"Provide correct directory to save the file to (example: C:\logs)");
                    directory = Console.ReadLine();
                }
                var fileName = string.Format("SalesIntegratorLog_{0}.txt", DateTime.Now.ToString("ddMMyyyy_hhmm"));
                string fileFullPath = Path.Combine(directory, fileName);
                FileStream = new FileStream(fileFullPath, FileMode.Create);
                StreamWriter = new StreamWriter(FileStream) { AutoFlush = true };
                Console.SetOut(StreamWriter);
                Console.SetError(StreamWriter);
                var handle = GetConsoleWindow();
                ConsoleVisibility = Constants.CONSOLE_HIDDEN;
                ShowWindow(handle, ConsoleVisibility);
            }
        }

        [STAThread]
        static void Main()
        {
            StartConsole();
            Program program = _serviceProvider.GetService<Program>().Initialize();
            DBConnectionModel dbUser = new DBConnectionModel();
            InsertUserModel insertUser = new InsertUserModel();
            LoginForm loginForm = new LoginForm(dbUser, insertUser);
            loginForm.ShowDialog();
            program.HandleSubiekt(dbUser, insertUser);
        }


        private static readonly ServiceProvider _serviceProvider =
            new ServiceCollection()
            .AddSingleton<IOrderService, BaselinkerService>()
            .AddSingleton<IController, Controller>()
            .AddSingleton<IDataService, DataService>()
            .AddSingleton<ISubiektService, SubiektService>()
            .AddSingleton<IDatabaseService, DatabaseService>()
            .AddTransient<Program>()
            .BuildServiceProvider();


        
        public Program Initialize()
        {
            _controller.Initialize();
            return this;

        }
        public IController GetController()
        {
            return _controller;
        }

    }

}
