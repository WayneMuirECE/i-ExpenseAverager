namespace i_ExpenseAverager.ViewModelLibrary
{
    public class ChainClass
    {
        private readonly int _numOfLinks;
        private readonly int _nodesPerLink;
        public ChainLink ChainHead { get; }

        public ChainClass(int numOfLinks, int nodesPerLink)
        {
            _numOfLinks = Math.Max(numOfLinks, 1);
            _nodesPerLink = Math.Max(nodesPerLink, 1);

            ChainLink lastLink = null;

            for (int i = 0; i < _numOfLinks; i++)
            {
                var link = new ChainLink(_nodesPerLink, lastLink);
                lastLink = link;
            }

            ChainHead = lastLink;
        }
    }
}
