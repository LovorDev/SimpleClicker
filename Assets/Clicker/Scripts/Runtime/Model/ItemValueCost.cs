namespace Clicker.Scripts.Runtime.Model
{
    public record ItemValueCost
    {
        public double Cost;
        public double Value;
        public ItemValueCost(double cost, double value)
        {
            Cost = cost;
            Value = value;
        }
    }
}