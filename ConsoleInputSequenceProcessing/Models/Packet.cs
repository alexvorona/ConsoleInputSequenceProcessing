using System;
using System.Linq;

namespace TestConsole.Models
{
    public class Packet
    { 
        private Payload _payload;

        public Payload Payload { get => _payload; }

        public Packet(string sequence)
        {
            if (! ContainsValidChars(sequence))
            {
                throw new ArgumentException("Invalid characters");
            }      
            _payload = new Payload(sequence.Substring(1, sequence.Length - 2));
        }               

        public bool ContainsValidChars(string str)
        {
            int min = 32;
            int max = 127;

            return str.All(c => min <= c && c <= max);
        }
    }
}
