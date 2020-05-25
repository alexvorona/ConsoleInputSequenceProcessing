using System;
using System.Text;

namespace TestConsole.Models
{
    public class Processor
    {
        private const char StartChar = 'P';
        private const char EndChar = 'E';
        private const string Accepted = "ASK";
        private const string Invalid = "NASK";

        StringBuilder _sequence = null;
        Packet _packet;

        public void Process(ConsoleKeyInfo keyInfo)
        {          
            if (_sequence == null && (keyInfo.KeyChar == StartChar))
            {
                _sequence = new StringBuilder();
            }
            if (_sequence != null)
            {
                _sequence.Append(keyInfo.KeyChar);
                if (keyInfo.KeyChar == EndChar)
                {
                    Response(Accepted);
                    try
                    {
                        _packet = new Packet(_sequence.ToString());
                        _packet.Payload.Command.Execute();
                    }
                    catch
                    {
                        Response(Invalid);
                    }
                    finally
                    {
                        _sequence = null;
                    }
                }
            }
        }

        private static void Response(string response)
        {
            Console.WriteLine(response);
        }
    }
}
