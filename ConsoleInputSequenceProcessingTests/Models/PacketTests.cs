using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Commands;

namespace TestConsole.Models.Tests
{
    [TestClass()]
    public class PacketTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Invalid characters")]
        public void InvalidCharacters1Test()
        {
            var packet = new Packet($"PT:hel{(char)1}lo:E");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Invalid characters")]
        public void InvalidCharacters128Test()
        {
            var packet = new Packet($"PT:hel{(char)128}lo:E");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Invalid payload format")]
        public void InvalidPayloadFormatTest()
        {
            var packet = new Packet($"PT:E");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Invalid payload format")]
        public void InvalidPayloadFormat2Test()
        {
            var packet = new Packet($"PT:helloE");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Invalid command")]
        public void InvalidCommandTest()
        {
            var packet = new Packet($"PC:hello:E");
        }

        [TestMethod()]
        public void EtalonTextCmdCharacterTest()
        {
            var packet = new Packet("PT:hello:E");
            Assert.AreEqual(packet.Payload.CmdCharacter, 'T');
        }

        [TestMethod()]
        public void EtalonTextParametersTest()
        {
            var packet = new Packet("PT:hello:E");
            Assert.AreEqual(packet.Payload.Parameters, "hello");
        }

        [TestMethod()]
        public void EtalonTextCmdCommandTypeTest()
        {
            var packet = new Packet("PT:hello:E");
            Assert.AreEqual(packet.Payload.Command.GetType(), typeof(TextCommand));
        }

        [TestMethod()]
        public void EtalonSoundCmdCharacterTest()
        {
            var packet = new Packet("PS:10000,500:E");
            Assert.AreEqual(packet.Payload.CmdCharacter, 'S');
        }

        [TestMethod()]
        public void EtalonSoundParametersTest()
        {
            var packet = new Packet("PS:10000,500:E");
            Assert.AreEqual(packet.Payload.Parameters, "10000,500");
        }

        [TestMethod()]
        public void EtalonSoundCmdCommandTypeTest()
        {
            var packet = new Packet("PS:10000,500:E");
            Assert.AreEqual(packet.Payload.Command.GetType(), typeof(SoundCommand));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Invalid parameters")]
        public void InvalidParametersSoundTest()
        {
            var packet = new Packet("PS:10000,500,1:E");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Invalid value (Frequency)")]
        public void InvalidSoundFrequencyTest()
        {
            var packet = new Packet("PS:1,500:E");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Invalid value (Duration)")]
        public void InvalidSoundDurationTest()
        {
            var packet = new Packet("PS:10000,0:E");
        }
    }
}