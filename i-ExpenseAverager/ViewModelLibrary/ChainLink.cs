namespace i_ExpenseAverager.ViewModelLibrary
{
    public class ChainLink
    {
        private Queue<object> _nodes;

        public int MaxNodes { get; }
        public ChainLink LinkDown { get; }

        public ChainLink(int nodesPerLink, ChainLink linkDown)
        {
            MaxNodes = nodesPerLink;
            _nodes = new Queue<object>();
            LinkDown = linkDown;
        }

        public void AddNode(object nodeToAdd)
        {
            if (_nodes.Count >= MaxNodes)
            {
                object pass = _nodes.Dequeue();
                LinkDown?.AddNode(pass);
            }

            _nodes.Enqueue(nodeToAdd);
        }

        public IEnumerable<object> GetNodes()
        {
            return _nodes.AsEnumerable();
        }
    }

}
