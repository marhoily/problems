using System.Text;
using FluentAssertions;
using Xunit;

namespace DesignPatters
{
    public sealed class Pattern5
    {
        interface IDrawable
        {
            void Draw(StringBuilder canvas);
        }
        class Ellipse : IDrawable
        {
            public void Draw(StringBuilder canvas)
            {
                canvas.Append("Ellipse;");
            }
        }

        class Square : IDrawable
        {
            public void Draw(StringBuilder canvas)
            {
                canvas.Append("Square;");
            }
        }

        class Compound : IDrawable
        {
            private readonly IDrawable[] _list;
            public Compound(params IDrawable[] list) { _list = list; }
            public void Draw(StringBuilder canvas)
            {
                foreach (var drawable in _list)
                    drawable.Draw(canvas);
            }
        }
        [Fact]
        public void Test()
        {
            var canvas = new StringBuilder();
            new Compound(new Square(), new Ellipse())
                .Draw(canvas);
            canvas.ToString().Should().Be("Square;Ellipse;");
        }
    }
}
 
