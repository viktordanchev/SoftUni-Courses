namespace BitcoinWalletManager
{
    public class Transaction
    {
        public string Hash { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public int Value { get; set; }

        public int Nonce { get; set; }
    }
}
