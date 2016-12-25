using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Banking.DAL.Interfaces;
using Banking.Models;

namespace Banking.DAL
{
    public class TransactionRepository : ITransactionRepository
    {
        private BankingDbContext context;

        public TransactionRepository(BankingDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Models.UserTransaction> GetAll()
        {
            return context.UserTransactions.ToList();
        }

        public Models.UserTransaction GetById(int id)
        {
            return context.UserTransactions.Find(id);
        }

        public void Insert(Models.UserTransaction entity)
        {
            context.UserTransactions.Add(entity);
        }

        public void Update(Models.UserTransaction entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Models.UserTransaction student = context.UserTransactions.Find(id);
            context.UserTransactions.Remove(student);
        }

        public Models.UserTransaction FirstOrDefault(Func<Models.UserTransaction, bool> func)
        {
            return context.UserTransactions.FirstOrDefault(func);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}