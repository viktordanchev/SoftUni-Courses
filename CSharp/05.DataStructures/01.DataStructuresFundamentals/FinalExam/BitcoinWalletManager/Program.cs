using System;

namespace BitcoinWalletManagementSystem
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var _walletManager = new BitcoinWalletManager();

            var user1 = new User { Id = "user1" };
            var user2 = new User { Id = "user2" };
            var user3 = new User { Id = "user3" };

            _walletManager.CreateUser(user1);
            _walletManager.CreateUser(user2);
            _walletManager.CreateUser(user3);

            var user1Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user1.Id, Balance = 1000 };
            var user2Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user2.Id, Balance = 1000 };
            var user3Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user3.Id, Balance = 1000 };

            _walletManager.CreateWallet(user1Wallet);
            _walletManager.CreateWallet(user2Wallet);
            _walletManager.CreateWallet(user3Wallet);

            var transaction1 = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                SenderWalletId = user1Wallet.Id,
                ReceiverWalletId = user2Wallet.Id,
                Amount = 100,
                Timestamp = DateTime.Now,
            };

            var transaction2 = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                SenderWalletId = user1Wallet.Id,
                ReceiverWalletId = user3Wallet.Id,
                Amount = 100,
                Timestamp = DateTime.Now,
            };

            _walletManager.PerformTransaction(transaction1);
            _walletManager.PerformTransaction(transaction2);

            var user1Transactions = _walletManager.GetTransactionsByUser(user1.Id);
            var user2Transactions = _walletManager.GetTransactionsByUser(user2.Id);
            var user3Transactions = _walletManager.GetTransactionsByUser(user3.Id);
        }
    }
}