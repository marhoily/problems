using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace DesignPatters
{
    public sealed class Pattern7
    {
        public interface IBank { decimal SavingsAmount(string customer); }
        public interface ICredit { bool IsGoodCreditHistory(string customer); } 
        public interface ILoan { bool HasBadLoans(string customer); }

        sealed class Mortgage
        {
            private readonly IBank _bank;
            private readonly ICredit _credit;
            private readonly ILoan _loan;

            public Mortgage(IBank bank, ICredit credit, ILoan loan)
            {
                _bank = bank;
                _credit = credit;
                _loan = loan;
            }

            public bool IsEligible(string customer, decimal amount)
            {
                var savings = _bank.SavingsAmount(customer);
                var goodCredit = _credit.IsGoodCreditHistory(customer);
                var badLoans = _loan.HasBadLoans(customer);
                return savings >= amount/10.0m && goodCredit && badLoans;
            }
        }
        [Fact]
        public void Test()
        {
            var bank = A.Fake<IBank>();
            var credit = A.Fake<ICredit>();
            var loan = A.Fake<ILoan>();

            A.CallTo(() => bank.SavingsAmount("John")).Returns(15m);
            A.CallTo(() => credit.IsGoodCreditHistory("John")).Returns(true);
            A.CallTo(() => loan.HasBadLoans("John")).Returns(true);

            var mortgage = new Mortgage(bank, credit, loan);
            mortgage.IsEligible("John", 100).Should().BeTrue();
            mortgage.IsEligible("John", 200).Should().BeFalse();
        }
    }
}
