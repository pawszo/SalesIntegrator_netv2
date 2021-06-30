using SalesIntegrator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesIntegrator.Models;
using Microsoft.Extensions.DependencyInjection;
using SalesIntegrator.Views;
using SalesIntegrator.Controllers;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Concurrent;
using System.Threading;
using SalesIntegrator.Utils;

namespace SalesIntegrator
{
    public class Program
    {
        private readonly IController _controller;
        private readonly ISubiektService _subiektService;

        public static FileStream FileStream;
        public static StreamWriter StreamWriter;
        public static DBConnectionModel DBUser;
        public static InsertUserModel InsertUser;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        static int ConsoleVisibility;

        public Program(IController controller, ISubiektService subiektService)
        {
            _controller = controller;
            _subiektService = subiektService;

        }
        private void StartSubiekt()
        {
            _subiektService.StartSubiekt(DBUser, InsertUser);
            NonBlockingConsole.WriteLine("Subiekt GT properly started");
            _subiektService.PassOrders(_controller.ReceivedOrders);
            NonBlockingConsole.WriteLine($"{_controller.ReceivedOrders.Count()} orders are passed to Subiekt GT");
            _subiektService.ProcessOrders();



        }

        [STAThread]
        static void Main()
        {
            NonBlockingConsole.WriteLine("Press key to select logging type: f - log to file; c - log to console;");
            char key = Console.ReadKey().KeyChar;
            if (key == 'f' || key == 'f')
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
            Program program = _serviceProvider.GetService<Program>().Initialize();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();

            program.StartSubiekt();
            NonBlockingConsole.WriteLine("JOB FINISHED :)");
            if (ConsoleVisibility != Constants.CONSOLE_HIDDEN)
            {
                NonBlockingConsole.WriteLine("Press any key to close the application.");
                Console.ReadKey();
            }
            
        }


        private static readonly ServiceProvider _serviceProvider =
            new ServiceCollection()
            .AddSingleton<IBaseLinkerService, BaselinkerService>()
            .AddSingleton<IController, Controller>()
            .AddSingleton<IDataService, DataService>()
            .AddSingleton<ISubiektService, SubiektService>()
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
    public static class NonBlockingConsole
    {
        private readonly static BlockingCollection<string> m_Queue = new BlockingCollection<string>();

        static NonBlockingConsole()
        {
            var thread = new Thread(
              () =>
              {
                  while (true) Console.WriteLine(m_Queue.Take());
              });
            thread.IsBackground = true;
            thread.Start();
        }

        public static void WriteLine(string value)
        {

            m_Queue.Add($"{DateTime.Now:dd-MM-yyyy_hh:mm} {value}");
        }
    }

}
