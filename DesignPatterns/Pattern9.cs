namespace DesignPatters
{
    public sealed class Pattern9
    {
        public sealed class Game
        {
            private int _x;
            private int _y;

            public void MoveUp() => _y -= 1;
            public void MoveDown() => _y += 1;
            public void MoveLeft() => _x -= 1;
            public void MoveRight() => _x += 1;

            public void GetWorld(out int x, out int y)
            {
                x = _x;
                y = _y;
            }

            sealed class Snapshot
            {
                public readonly int X;
                public readonly int Y;
                public Snapshot(int x, int y)
                {
                    X = x;
                    Y = y;
                }
            }

            public object Save() => new Snapshot(_x, _y);
            public void Load(object save)
            {
                var s = (Snapshot) save;
                _x = s.X;
                _y = s.Y;
            }
        }

        [Fact]
        public void Test()
        {
            var game = new Game();
            game.MoveUp();
            game.MoveLeft();
            var savePoint = game.Save();
            game.MoveDown();
            game.MoveRight();
            game.Load(savePoint);
            int x, y;
            game.GetWorld(out x, out y);
            x.Should().Be(-1);
            y.Should().Be(-1);
        }
    }
}