namespace Contracts
{
    public class BidPlaced
    {
        public string Id { get; set; }
        public string AuctionId { get; set; }
        public string Bidder { get; set; }
        public string BidTime { get; set; }
        public int Amount { get; set; }
        public string BidStatus { get; set; }
    }
}
