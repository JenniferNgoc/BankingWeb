using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Banking.DAL.Interfaces;
using Banking.Models;

namespace Banking.DAL
{
    public class AccountRepository : IAccountReponsitory
    {
        private BankingDbContext context;

        public AccountRepository(BankingDbContext context)
        {
            this.context = context;
        }
       
        public IEnumerable<Models.Account> GetAll()
        {
            return context.Accounts.ToList();
        }

        public Models.Account GetById(int id)
        {
            return context.Accounts.Find(id);
        }

        public void Insert(Models.Account entity)
        {
            context.Accounts.Add(entity);
        }

        public void Update(Models.Account entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Models.Account student = context.Accounts.Find(id);
            context.Accounts.Remove(student);
        }

        public Models.Account FirstOrDefault(Func<Models.Account, bool> func)
        {
            return context.Accounts.FirstOrDefault(func);
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