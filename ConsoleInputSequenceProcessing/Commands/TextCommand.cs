using System;

namespace TestConsole.Commands
{
    public class TextCommand : IConsoleCommand
    {
        private string _payload = string.Empty;

        public TextCommand(string payload)
        {            
            _payload = payload;
        }

        public void Execute()
        {
            Console.WriteLine(_payload);
        }
    }
}