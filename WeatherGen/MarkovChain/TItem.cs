namespace WeatherGen.MarkovChain
{
    public class TItem<T>
    {
        public double Count { get; set; }
        public double Probability { get; set; }
        public T Name { get; set; }
        public TItem()
        {
            Count = 1;
            Probability = 1.0;
        }
        public override string ToString()
        {
            return "Count: " + Count + " Probability: " + Probability;
        }
        
        
    }
}
