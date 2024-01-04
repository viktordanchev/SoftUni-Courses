using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BitcoinWalletManager.Tests
{
    public class CorrectnessTests
    {
        private IWalletManager walletManager;

        [SetUp]
        public void Setup()
        {
            this.walletManager = new WalletManager();
        }

        [Test]
        public void AddTransaction_ShouldAddPendingTransaction()
        {
            // Arrange
            var tx = new Transaction
            {
                Hash = GetNextHash(),
                From = "from",
                To = "to",
                Nonce = 1,
                Value = 1
            };

            // Act
            this.walletManager.AddTransaction(tx);

            // Assert
            Assert.True(this.walletManager.Contains(tx.Hash));
        }

        [Test]
        public void CancelTransaction_ShouldReturnTheCanceledTransaction_WhenExists()
        {
            // Arrange
            var tx1 = new Transaction
            {
                Hash = GetNextHash(),
                From = "from",
                To = "to",
                Nonce = 1,
                Value = 1
            };

            var tx2 = new Transaction
            {
                Hash = GetNextHash(),
                From = "from",
                To = "to",
                Nonce = 1,
                Value = 1
            };

            this.walletManager.AddTransaction(tx1);
            this.walletManager.AddTransaction(tx2);

            // Act
            var canceled = this.walletManager.CancelTransaction(tx1.Hash);

            // Assert
            Assert.That(canceled, Is.EqualTo(tx1));
            Assert.False(this.walletManager.Contains(tx1.Hash));
        }

        [Test]
        public void Contains_ShouldReturnFalse_WhenTxHashDoesNotExist()
        {
            // Arrange
            var tx1 = new Transaction
            {
                Hash = GetNextHash(),
                From = "from",
                To = "to",
                Nonce = 1,
                Value = 1
            };

            var tx2 = new Transaction
            {
                Hash = GetNextHash(),
                From = "from",
                To = "to",
                Nonce = 1,
                Value = 1
            };

            this.walletManager.AddTransaction(tx1);
            this.walletManager.AddTransaction(tx2);

            // Act
            var result = this.walletManager.Contains(GetNextHash());

            // Assert
            Assert.False(result);
        }

        [Test]
        public void GetEarliestNonceByUser_ShouldReturnMinNonce()
        {
            // Arrange
            var target = "address1";
            var minNonce = 1;
            var tx1 = new Transaction
            {
                Hash = GetNextHash(),
                From = target,
                To = "address2",
                Nonce = 5,
                Value = 1
            };

            var tx2 = new Transaction
            {
                Hash = GetNextHash(),
                From = "address2",
                To = target,
                Nonce = 1,
                Value = 1
            };

            var tx3 = new Transaction
            {
                Hash = GetNextHash(),
                From = target,
                To = "address3",
                Nonce = minNonce,
                Value = 1
            };

            var tx4 = new Transaction
            {
                Hash = GetNextHash(),
                From = target,
                To = "address3",
                Nonce = 3,
                Value = 1
            };

            this.walletManager.AddTransaction(tx1);
            this.walletManager.AddTransaction(tx2);
            this.walletManager.AddTransaction(tx3);
            this.walletManager.AddTransaction(tx4);

            // Act
            var nonce = this.walletManager.GetEarliestNonceByUser(target);

            // Assert
            Assert.That(nonce, Is.EqualTo(minNonce));
        }

        [Test]
        public void BroadcastTransaction_ShouldReturnAndRemoveTheTransaction_WhenExists()
        {
            // Arrange
            var tx1 = new Transaction
            {
                Hash = GetNextHash(),
                From = "from",
                To = "to",
                Nonce = 1,
                Value = 1
            };

            var tx2 = new Transaction
            {
                Hash = GetNextHash(),
                From = "from",
                To = "to",
                Nonce = 1,
                Value = 1
            };

            this.walletManager.AddTransaction(tx1);
            this.walletManager.AddTransaction(tx2);

            // Act
            var result = this.walletManager.BroadcastTransaction(tx2.Hash);

            // Assert
            Assert.That(result, Is.EqualTo(tx2));
            Assert.False(this.walletManager.Contains(tx2.Hash));
        }

        [Test]
        public void GetPendingTransactionsByUser_ShouldReturnOnlyPendingTxs()
        {
            // Arrange
            var target = "address1";
            var tx1 = new Transaction
            {
                Hash = GetNextHash(),
                From = target,
                To = "address2",
                Nonce = 5,
                Value = 1
            };

            var tx2 = new Transaction
            {
                Hash = GetNextHash(),
                From = "address2",
                To = target,
                Nonce = 1,
                Value = 1
            };

            var tx3 = new Transaction
            {
                Hash = GetNextHash(),
                From = target,
                To = "address3",
                Nonce = 1,
                Value = 1
            };

            var tx4 = new Transaction
            {
                Hash = GetNextHash(),
                From = target,
                To = "address3",
                Nonce = 3,
                Value = 1
            };

            var tx5 = new Transaction
            {
                Hash = GetNextHash(),
                From = target,
                To = "address4",
                Nonce = 30,
                Value = 1
            };

            this.walletManager.AddTransaction(tx1);
            this.walletManager.AddTransaction(tx2);
            this.walletManager.AddTransaction(tx3);
            this.walletManager.AddTransaction(tx4);
            this.walletManager.AddTransaction(tx5);

            this.walletManager.CancelTransaction(tx5.Hash);
            this.walletManager.BroadcastTransaction(tx3.Hash);

            // Act
            var result = this.walletManager.GetPendingTransactionsByUser(target);

            // Assert
            CollectionAssert.AreEqual(
                new List<Transaction> { tx4, tx1 },
                result);
        }

        [Test]
        public void GetHistoryTransactionsByUser_ShouldReturnOnlyExecutedUserTxs()
        {
            // Arrange
            var target = "address1";
            var tx1 = new Transaction
            {
                Hash = GetNextHash(),
                From = target,
                To = "address2",
                Nonce = 5,
                Value = 1
            };

            var tx2 = new Transaction
            {
                Hash = GetNextHash(),
                From = "address2",
                To = target,
                Nonce = 1,
                Value = 1
            };

            var tx3 = new Transaction
            {
                Hash = GetNextHash(),
                From = target,
                To = "address3",
                Nonce = 1,
                Value = 1
            };

            var tx4 = new Transaction
            {
                Hash = GetNextHash(),
                From = target,
                To = "address3",
                Nonce = 3,
                Value = 1
            };

            var tx5 = new Transaction
            {
                Hash = GetNextHash(),
                From = target,
                To = "address4",
                Nonce = 30,
                Value = 1
            };

            this.walletManager.AddTransaction(tx1);
            this.walletManager.AddTransaction(tx2);
            this.walletManager.AddTransaction(tx3);
            this.walletManager.AddTransaction(tx4);
            this.walletManager.AddTransaction(tx5);

            this.walletManager.CancelTransaction(tx5.Hash);
            this.walletManager.BroadcastTransaction(tx3.Hash);

            // Act
            var result = this.walletManager.GetHistoryTransactionsByUser(target);

            // Assert
            CollectionAssert.AreEqual(
                new List<Transaction> { tx3 },
                result);
        }

        private static string GetNextHash()
            => Guid.NewGuid().ToString();
    }
}