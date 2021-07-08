using SalesIntegrator.Service;
using SalesIntegrator.Controller;
using System;
using SalesIntegrator.Model;
using Microsoft.Extensions.DependencyInjection;
using SalesIntegrator.View;
using SalesIntegrator.Controller.Interface;
using System.Runtime.InteropServices;
using System.IO;
using SalesIntegrator.Utils;
using SalesIntegrator.Service.Interface;
using System.Reflection;
using SalesIntegrator.Mapper.Interface;
using SalesIntegrator.Mapper;

namespace SalesIntegrator
{
    public class Program
    {
        private readonly IController _controller;

        private static FileStream FileStream;
        private static StreamWriter StreamWriter;
        private static int ConsoleVisibility;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        

        public Program(IController controller)
        {
            _controller = controller;
        }

        static void StartConsole()
        {
            while (true)
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
                    break;
                }
                else if (key == 'C' || key == 'c')
                {
                    NonBlockingConsole.WriteLine("Console logging enabled.");
                    break;
                }
            }
        }
        static void DisposeConsole()
        {
            if (ConsoleVisibility != Constants.CONSOLE_HIDDEN)
            {
                NonBlockingConsole.WriteLine("Press any key to close the application.");
                Console.ReadKey();
            }
        }

        [STAThread]
        static void Main()
        {
            StartConsole();
            ServiceProvider.GetService<Program>().Initialize();
            DisposeConsole();
        }


        private static readonly ServiceProvider ServiceProvider =
            new ServiceCollection()
            .AddSingleton<IAPIService, BaselinkerService>()
            .AddSingleton<IController, Controller.Controller>()
            .AddSingleton<IDataService, DataService>()
            .AddSingleton<IERPService, SubiektService>()
            .AddSingleton<IDatabaseService, DatabaseService>()
            .AddTransient<IMapper, BaselinkerMapper>()
            .AddTransient<IMapper, SubiektMapper>()
            .AddTransient<Program>()
            .BuildServiceProvider();


        
        public void Initialize()
        {
            _controller.Initialize();
            _controller.Authorize();
            _controller.RegisterOrders();
        }

    }

}
