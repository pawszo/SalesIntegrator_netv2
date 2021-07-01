using System;
using System.Collections.Concurrent;
using System.Threading;

namespace SalesIntegrator.Utils
{
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
