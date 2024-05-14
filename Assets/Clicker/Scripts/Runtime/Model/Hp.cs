namespace Clicker.Scripts.Runtime.Model
{
    public record Hp
    {
        public double Current;
        public readonly double Max;

        public Hp(int current, int max)
        {
            Current = current;
            Max = max;
        }

        public Hp(int max)
        {
            Current = max;
            Max = max;
        }
    }
}