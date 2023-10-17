using System;
using System.Collections.Generic;
using System.Linq;

namespace BitcoinWalletManagementSystem
{
    public class BitcoinWalletManager : IBitcoinWalletManager
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();
        private Dictionary<string, Wallet> wallets = new Dictionary<string, Wallet>();

        public void CreateUser(User user)
        {
            users.Add(user.Id, user);
        }

        public void CreateWallet(Wallet wallet)
        {
            wallet.Transactions = new List<Transaction>();
            users[wallet.UserId].Balance += wallet.Balance;
            wallets.Add(wallet.Id, wallet);
        }

        public bool ContainsUser(User user)
        {
            return users.ContainsKey(user.Id);
        }

        public bool ContainsWallet(Wallet wallet)
        {
            return wallets.ContainsKey(wallet.Id);
        }

        public IEnumerable<Wallet> GetWalletsByUser(string userId)
        {
            return wallets.Values
                .Where(w => w.UserId == userId);
        }

        public void PerformTransaction(Transaction transaction)
        {
            if (!wallets.ContainsKey(transaction.SenderWalletId) || 
                !wallets.ContainsKey(transaction.ReceiverWalletId) ||
                wallets[transaction.SenderWalletId].Balance < transaction.Amount)
            {
                throw new ArgumentException();
            }

            var sender = wallets[transaction.SenderWalletId];
            var receiver = wallets[transaction.ReceiverWalletId];

            sender.Transactions.Add(transaction);
            receiver.Transactions.Add(transaction);

            users[sender.UserId].TransactionsCount++;
            users[receiver.UserId].TransactionsCount++;

            sender.Balance -= transaction.Amount;
            receiver.Balance += transaction.Amount;
        }

        public IEnumerable<Transaction> GetTransactionsByUser(string userId)
        {
            return wallets.Values.First(w => w.UserId == userId).Transactions;
        }

        public IEnumerable<Wallet> GetWalletsSortedByBalanceDescending()
        {
            return wallets.Values
                .OrderByDescending(w => w.Balance);
        }

        public IEnumerable<User> GetUsersSortedByBalanceDescending()
        {
            return users.Values
                .OrderByDescending(u => u.Balance);
        }

        public IEnumerable<User> GetUsersByTransactionCount()
        {
            return users.Values
                .OrderByDescending(u => u.TransactionsCount);
        }
    }
}