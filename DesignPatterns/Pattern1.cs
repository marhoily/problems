using FakeItEasy;
using Xunit;

namespace DesignPatters
{
    public sealed class Pattern1
    {
        public interface IAmericanSocket { void GetPower(); }
        public interface IEuropeanSocket { void RetrievePower(); }
        public sealed class EuropeanDevice {
            public void Plug(IEuropeanSocket socket) 
                => socket.RetrievePower();
        }

        sealed class AmericanToEuropean : IEuropeanSocket
        {
            private readonly IAmericanSocket _socket;

            public AmericanToEuropean(IAmericanSocket socket) {
                _socket = socket;
            }

            public void RetrievePower() => _socket.GetPower();
        }

        private readonly EuropeanDevice _europeanDevice = new EuropeanDevice();

        [Fact]
        public void TestAmericanToEuropean()
        {
            var americanSocket = A.Fake<IAmericanSocket>();
            _europeanDevice.Plug(new AmericanToEuropean(americanSocket));
            A.CallTo(() => americanSocket.GetPower())
                .MustHaveHappened();
        }
    }
}
 