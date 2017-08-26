namespace Redux
{
    public class State
    {
        public int Count { get; private set; }

        public State() { }

        public State(int count)
        {
            Count = count;
        }
    }
}