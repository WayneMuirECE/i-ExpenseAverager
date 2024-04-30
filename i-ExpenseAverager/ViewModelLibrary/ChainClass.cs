namespace i_ExpenceAverager.ViewModelLibrary
{
    public class ChainClass
    {
        private readonly int numOfLinks;
        private readonly int nodesPerLink;
        public ChainLink ChainHead { get; }

        public ChainClass(int numOfLinks, int nodesPerLink)
        {
            this.numOfLinks = Math.Max(numOfLinks, 1);
            this.nodesPerLink = Math.Max(nodesPerLink, 1);

            ChainLink lastLink = null;

            for (int i = 0; i < this.numOfLinks; i++)
            {
                var link = new ChainLink(this.nodesPerLink, lastLink);
                lastLink = link;
            }

            ChainHead = lastLink;
        }
    }
}
