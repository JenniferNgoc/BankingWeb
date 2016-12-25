using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Banking.Bussiness;
using Banking.DAL;
using Banking.DAL.Interfaces;
using Banking.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Banking.UnitTest
{
    [TestClass]
    public class ServiceUnitTest
    {
        private static List<string> listAccountSetup;
        private static List<Models.Account> _accountDataTest;

        [ClassInitialize]
        public static void TestSetup(TestContext testContext)
        {
            _accountDataTest = new List<Models.Account>()
            {
                new Models.Account {AccountNumber = "123", Balance = 100000},
                new Models.Account {AccountNumber = "1234", Balance = 200000},
                new Models.Account {AccountNumber = "12345", Balance = 500000},
                new Models.Account {AccountNumber = "123456", Balance = 0}
            };
        }

        [TestMethod]
        public void TransferConcurencyTest1()
        {
            var _accountReponsitory = new Mock<IAccountReponsitory>();
            var _transactionReponsitory = new Mock<ITransactionRepository>();

            _accountReponsitory.Setup(r => r.FirstOrDefault(It.IsAny<Func<Models.Account, bool>>()))
                .Returns((Func<Models.Account, bool> expr) => _accountDataTest.FirstOrDefault(expr));

            _accountReponsitory.Setup(mr => mr.Update(It.IsAny<Models.Account>())).Verifiable();

            TransactionService transactionService = new TransactionService(_accountReponsitory.Object, _transactionReponsitory.Object);

            decimal totalBalWithdraw = 0;

            Task task1 = Task.Run(() =>
            {
                Parallel.For(0, 25,
                                index =>
                                {
                                    totalBalWithdraw += index;
                                    //test concurrency with multiple instance of Service object
                                    new TransactionService(_accountReponsitory.Object, _transactionReponsitory.Object)
                                        .Transfer("123", "123456", index);
                                });
            });

            Task task2 = Task.Run(() =>
            {
                Parallel.For(0, 40,
                                index =>
                                {
                                    new TransactionService(_accountReponsitory.Object, _transactionReponsitory.Object)
                                        .Transfer("1234", "123456", index);
                                });
            });

            Task task3 = Task.Run(() =>
            {
                Parallel.For(0, 40,
                                index =>
                                {
                                    new TransactionService(_accountReponsitory.Object, _transactionReponsitory.Object)
                                        .Transfer("12345", "123456", index);
                                });
            });
            transactionService.Transfer("12345", "123456", 10000);

            Task.WaitAll(task1,task2,task3);

            var sumTotal = _accountDataTest.Sum(x => x.Balance);
            var sumSourceBalaceAcc = _accountDataTest.Where(a => a.AccountNumber != "123456").Sum(x => x.Balance);

            Assert.AreEqual(sumTotal, 800000);

            //assert total transfer amount is equal received amount
            Assert.AreEqual(800000 - sumSourceBalaceAcc, _accountDataTest.Find(_ => _.AccountNumber == "123456").Balance);

            //assert total amount transfer of Account Number 123
            Assert.AreEqual(totalBalWithdraw, 100000 - _accountDataTest.Find(_ => _.AccountNumber == "123").Balance);
        }
    }
}
