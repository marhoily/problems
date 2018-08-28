using FluentAssertions;
using Xunit;

namespace DesignPatters
{
    public sealed class Pattern3
    {
        public abstract class Approver
        {
            protected Approver Next { get; }

            protected Approver(Approver next = null) { Next = next; }
            protected abstract bool ApproveCore(decimal amount);
            public bool ApproveExpense(decimal amount)
            {
                var approver = this;
                while (approver != null)
                {
                    if (!approver.ApproveCore(amount))
                        return false;
                    approver = approver.Next;
                }
                return true;
            }
        }

        public class Director : Approver
        {
            public Director(Approver next = null) : base(next) { }
            protected override bool ApproveCore(decimal amount) => amount < 10000;
        }

        public class President : Approver
        {
            public President(Approver next = null) : base(next) { }
            protected override bool ApproveCore(decimal amount) => amount < 1000;
        }

        public class VicePresident : Approver
        {
            public VicePresident(Approver next = null) : base(next) { }
            protected override bool ApproveCore(decimal amount) => amount < 100;
        }

        [Fact]
        public void Test()
        {
            var approver = new Director(
                new President(
                    new VicePresident()));
            approver.ApproveExpense(10).Should().BeTrue();
            approver.ApproveExpense(150).Should().BeFalse();
        }
    }
}
 
