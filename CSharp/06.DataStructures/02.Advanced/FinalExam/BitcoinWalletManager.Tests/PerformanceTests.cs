using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BitcoinWalletManager.Tests
{
    public class PerformanceTests
    {
        private IWalletManager walletManager;

        [SetUp]
        public void Setup()
        {
            this.walletManager = new WalletManager();
        }

        [Test]
        public void AddTransaction_ShouldPassQuickly_With1000000Txs()
        {
            // Arrange
            var count = 1_000_000;
            for (int i = 0; i < count; i++)
            {
                var tx = new Transaction
                {
                    Hash = GetNextHash(),
                    From = "from",
                    To = "to",
                    Nonce = 1,
                    Value = 1
                };

                this.walletManager.AddTransaction(tx);
            }

            // Act

            var sw = Stopwatch.StartNew();

            var newTx = new Transaction
            {
                Hash = GetNextHash(),
                From = GetNextHash(),
                To = GetNextHash(),
                Nonce = 1,
                Value = 1
            };

            this.walletManager.AddTransaction(newTx);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.True(this.walletManager.Contains(newTx.Hash));
        }

        [Test]
        public void Contaisn_ShouldReturnTrueQuickly_WhenExists()
        {
            // Arrange
            var count = 1_000_000;
            var target = string.Empty;
            for (int i = 0; i < count; i++)
            {
                var tx = new Transaction
                {
                    Hash = GetNextHash(),
                    From = "from",
                    To = "to",
                    Nonce = 1,
                    Value = 1
                };

                this.walletManager.AddTransaction(tx);

                if (i == 654_000)
                {
                    target = tx.Hash;
                }
            }

            // Act
            var sw = Stopwatch.StartNew();

            var result = this.walletManager.Contains(target);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.True(result);
        }

        [Test]
        public void GetEarliestNonceByUser_ShouldPassQuickly_With1000000Txs()
        {
            // Arrange
            var count = 1_000_000;
            var user = "from";
            var rdm = new Random();
            var minNonce = int.MaxValue;
            for (int i = 0; i < count; i++)
            {
                var nonce = rdm.Next(0, count);
                var tx = new Transaction
                {
                    Hash = GetNextHash(),
                    From = user,
                    To = GetNextHash(),
                    Nonce = nonce,
                    Value = 1
                };

                if (nonce < minNonce)
                {
                    minNonce = nonce;
                }

                this.walletManager.AddTransaction(tx);
            }

            // Act
            var sw = Stopwatch.StartNew();

            var result = this.walletManager.GetEarliestNonceByUser(user);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(result, Is.EqualTo(minNonce));
        }

        [Test]
        public void GetPendingTransactionsByUser_ShouldPassQuickly_With10000Txs()
        {
            // Arrange
            var count = 10_000;
            var user = "from";
            var rdm = new Random();
            var expectedResult = new SortedSet<Transaction>(
                Comparer<Transaction>.Create((f, s) => f.Nonce.CompareTo(s.Nonce)));

            for (int i = 0; i < count; i++)
            {
                var nonce = rdm.Next(0, count);
                var isEven = i % 2 == 0;
                var from = isEven ? user : GetNextHash();
                var to = isEven ? GetNextHash() : user;
                var tx = new Transaction
                {
                    Hash = GetNextHash(),
                    From = from,
                    To = to,
                    Nonce = nonce,
                    Value = 1
                };

                this.walletManager.AddTransaction(tx);

                if (isEven)
                {
                    expectedResult.Add(tx);
                }
            }

            // Act
            var sw = Stopwatch.StartNew();

            var result = this.walletManager.GetPendingTransactionsByUser(user);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [Test]
        public void GetHistoryTransactionsByUser_ShouldPassQuickly_With1000000Txs()
        {
            // Arrange
            var count = 1_000_000;
            var user = "from";
            var rdm = new Random();
            var expectedResult = new List<Transaction>();
            for (int i = 0; i < count; i++)
            {
                var nonce = rdm.Next(0, count);
                var tx = new Transaction
                {
                    Hash = GetNextHash(),
                    From = user,
                    To = GetNextHash(),
                    Nonce = nonce,
                    Value = 1
                };

                expectedResult.Add(tx);

                this.walletManager.AddTransaction(tx);
                this.walletManager.BroadcastTransaction(tx.Hash);
            }

            // Act
            var sw = Stopwatch.StartNew();

            var result = this.walletManager.GetHistoryTransactionsByUser(user);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CancelTransaction_ShouldPassQuickly_With1000000Txs()
        {
            // Arrange
            var count = 1_000_000;
            var rdm = new Random();
            var target = null as Transaction;
            for (int i = 0; i < count; i++)
            {
                var nonce = rdm.Next(0, count);
                var tx = new Transaction
                {
                    Hash = GetNextHash(),
                    From = GetNextHash(),
                    To = GetNextHash(),
                    Nonce = nonce,
                    Value = 1
                };

                if (i == 650_000)
                {
                    target = tx;
                }

                this.walletManager.AddTransaction(tx);
            }

            // Act
            var sw = Stopwatch.StartNew();

            var result = this.walletManager.CancelTransaction(target.Hash);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(result, Is.EqualTo(target));
            Assert.False(this.walletManager.Contains(target.Hash));
        }

        [Test]
        public void BroadcastTransaction_ShouldPassQuickly_With1000000Txs()
        {
            // Arrange
            var count = 1_000_000;
            var rdm = new Random();
            var target = null as Transaction;
            for (int i = 0; i < count; i++)
            {
                var nonce = rdm.Next(0, count);
                var tx = new Transaction
                {
                    Hash = GetNextHash(),
                    From = GetNextHash(),
                    To = GetNextHash(),
                    Nonce = nonce,
                    Value = 1
                };

                if (i == 650_000)
                {
                    target = tx;
                }

                this.walletManager.AddTransaction(tx);
            }

            // Act
            var sw = Stopwatch.StartNew();

            var result = this.walletManager.BroadcastTransaction(target.Hash);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(result, Is.EqualTo(target));
            Assert.False(this.walletManager.Contains(target.Hash));
        }

        private static string GetNextHash()
            => Guid.NewGuid().ToString();
    }
}