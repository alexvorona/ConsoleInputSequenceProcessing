using System;
using System.Linq;

namespace TestConsole.Commands
{
    public class SoundCommand : IConsoleCommand
    {
        private const int  _paramsCount = 2;
        private const int minFrequency = 37;
        private const int maxFrequency = 32767;

        private int _freq;

        private int _duration;
       
        public int Frequency
        {
            get => _freq;
            set
            {
                if (value < minFrequency || value > maxFrequency) throw new ArgumentException("Invalid value (Frequency)");
                _freq = value;
            }
        }

        public int Duration
        {
            get => _duration;
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value (Duration)");
                _duration = value;
            }
        }

        public SoundCommand(string payload)
        {
            string[] parameters = ExtractParameters(payload);
            Frequency = int.Parse(parameters[0]);
            Duration = int.Parse(parameters[1]);
        }

        private static string[] ExtractParameters(string payload)
        {
            string[] parameters = payload.Split(new char[] { ',' });
            if (parameters.Count() != _paramsCount)
            {
                throw new ArgumentException("Invalid parameters");
            }

            return parameters;
        }

        public void Execute()
        {
#if DEBUG
            Console.WriteLine($">>> Sound : {_freq}, {_duration}");
#endif
            Console.Beep(Frequency, Duration);
        }
    }
}