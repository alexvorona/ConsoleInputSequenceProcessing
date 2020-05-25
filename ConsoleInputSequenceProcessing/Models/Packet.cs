using System;
using System.Linq;

namespace TestConsole.Models
{
    public class Packet
    {
        private const int minValidCode = 32;
        private const int maxValidCode = 127;

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
            return str.All(c => minValidCode <= c && c <= maxValidCode);
        }
    }
}
