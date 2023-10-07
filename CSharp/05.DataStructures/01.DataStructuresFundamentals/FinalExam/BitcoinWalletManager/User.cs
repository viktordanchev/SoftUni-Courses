namespace BitcoinWalletManagementSystem
{
    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public long Balance { get; set; }

        public int TransactionsCount { get; set; }
    }
}