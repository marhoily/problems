using System;
using FakeItEasy;
using Xunit ;

namespace DesignPatters
{
    public sealed class Pattern8
    {
        public sealed class MessageArgs : EventArgs
        {
            public string Text { get; }
            public MessageArgs(string text) { Text = text; }
        }
        public interface IInChannel
        {
            event EventHandler<MessageArgs> MessageReceived;
        }

        public interface IOutChannel
        {
            void Send(string message);
        }

        sealed class ChatRoom
        {
            private readonly IInChannel _input;
            private readonly IOutChannel _output;

            public ChatRoom(IInChannel input, IOutChannel output)
            {
                _input = input;
                _output = output;
            }

            public void Initialize()
            {
                _input.MessageReceived += OnReceived;

            }
            private void OnReceived(object sender, MessageArgs message)
            {
                _output.Send(message.Text);
            }
        }
        [Fact]
        public void Test()
        {
            var input = A.Fake<IInChannel>();
            var output = A.Fake<IOutChannel>();
            var chatRoom = new ChatRoom(input, output);
            chatRoom.Initialize();
            input.MessageReceived += Raise.With(new MessageArgs("hello!"));
            A.CallTo(() => output.Send("hello!")).MustHaveHappened();
        }
    }
}
 