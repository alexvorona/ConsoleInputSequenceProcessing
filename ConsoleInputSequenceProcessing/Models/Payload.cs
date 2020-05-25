using System;
using System.Linq;
using TestConsole.Commands;

namespace TestConsole.Models
{
    public class Payload
    {
        private const char Separator = ':';
        private const int MinSequenceLenght = 3;

        private string _sequence;
        private char _cmdCharacter;
        private string _parameters;
        private IConsoleCommand _cmd;

        public Char CmdCharacter { get => _cmdCharacter; }
        public string Parameters { get => _parameters; }
        public IConsoleCommand Command { get => _cmd;  }

        public Payload(string sequence)
        {
            _sequence = sequence;
            if (_sequence.Length < MinSequenceLenght|| _sequence[1] != Separator || _sequence.Last() != ':')
            {
                throw new ArgumentException("Invalid payload format");
            }
            _cmdCharacter = _sequence[0];
            _parameters = _sequence.Substring(2, sequence.Length - 3);
            SetCommand();
        }

        private void SetCommand()
        {
            switch (CmdCharacter)
            {
                case 'T':
                    _cmd = new TextCommand(Parameters);
                    break;
                case 'S':
                    _cmd = new SoundCommand(Parameters);
                    break;
                default:
                    throw new System.ArgumentException("Invalid command");
            }           
        }
    }
}