using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace DesignPatters
{
    public class Pattern2
    {
        sealed class Creation
        {
            private readonly List<string> _features = new List<string>();
            public Creation AddHead() { _features.Add("head"); return this; }
            public Creation AddArm() { _features.Add("arm"); return this; }
            public Creation AddLeg() { _features.Add("leg"); return this;}
            public Beast Create() => new Beast(_features);
        }
        sealed class Beast
        {
            public IReadOnlyCollection<string> Features { get; }
            public Beast(IReadOnlyCollection<string> features) { Features = features; }
        }

        [Fact]
        public void Test()
        {
            var beast = new Creation()
                .AddHead()
                .AddLeg().AddLeg()
                .AddArm()
                .Create();

            beast.Features.Should()
                .Equal("head", "leg", "leg", "arm");
        }
    }
}
