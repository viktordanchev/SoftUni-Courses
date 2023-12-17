using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Transactions;

namespace BitcoinWalletManager
{
    public class WalletManager : IWalletManager
    {
        private Dictionary<string, Transaction> Transactions;
        private Dictionary<string, Transaction> ExecutedTransactions;
        private SortedDictionary<int, Transaction> SD;

        public WalletManager()
        {
            Transactions = new Dictionary<string, Transaction>();
            ExecutedTransactions = new Dictionary<string, Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction.Hash, transaction);
        }

        public Transaction BroadcastTransaction(string txHash)
        {
            if (!Transactions.ContainsKey(txHash))
            {
                throw new ArgumentException();
            }

            var transaction = Transactions[txHash];
            Transactions.Remove(txHash);
            ExecutedTransactions.Add(txHash, transaction);

            return transaction;
        }

        public Transaction CancelTransaction(string txHash)
        {
            if (!Transactions.ContainsKey(txHash))
            {
                throw new ArgumentException();
            }

            var transaction = Transactions[txHash];
            Transactions.Remove(txHash);

            return transaction;
        }

        public bool Contains(string txHash)
        {
            return Transactions.ContainsKey(txHash);
        }

        public int GetEarliestNonceByUser(string user)
        {
            var earliestNonce = GetPendingTransactionsByUser(user).First().Nonce;

            return earliestNonce;
        }

        public IEnumerable<Transaction> GetHistoryTransactionsByUser(string user)
        {
            return ExecutedTransactions.Values.Where(t => t.From == user);
        }

        public IEnumerable<Transaction> GetPendingTransactionsByUser(string user)
        {
            return Transactions.Values.Where(t => t.From == user).OrderBy(t => t.Nonce);
        }
    }
}