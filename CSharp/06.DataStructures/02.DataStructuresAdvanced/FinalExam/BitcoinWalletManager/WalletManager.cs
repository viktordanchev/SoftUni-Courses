using System.Collections.Generic;

namespace BitcoinWalletManager
{
    public class WalletManager : IWalletManager
    {
        public void AddTransaction(Transaction transaction)
        {
            throw new System.NotImplementedException();
        }

        public Transaction BroadcastTransaction(string txHash)
        {
            throw new System.NotImplementedException();
        }

        public Transaction CancelTransaction(string txHash)
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(string txHash)
        {
            throw new System.NotImplementedException();
        }

        public int GetEarliestNonceByUser(string user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Transaction> GetHistoryTransactionsByUser(string user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Transaction> GetPendingTransactionsByUser(string user)
        {
            throw new System.NotImplementedException();
        }
    }
}
