namespace i_ExpenseAverager.ViewModelLibrary
{
    public class ChainLink
    {
        private Queue<object> nodes;

        public int MaxNodes { get; }
        public ChainLink LinkDown { get; }

        public ChainLink(int nodesPerLink, ChainLink linkDown)
        {
            MaxNodes = nodesPerLink;
            nodes = new Queue<object>();
            LinkDown = linkDown;
        }

        public void AddNode(object nodeToAdd)
        {
            if (nodes.Count >= MaxNodes)
            {
                object pass = nodes.Dequeue();
                LinkDown?.AddNode(pass);
            }

            nodes.Enqueue(nodeToAdd);
        }

        public IEnumerable<object> GetNodes()
        {
            return nodes.AsEnumerable();
        }
    }

}
