using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UowWithRepository.Repositories.Interfaces;

namespace UowWithRepository.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUnitOfWork BeginTransaction(IsolationLevel iso, params IRepository[] repositories);
        IUnitOfWork BeginTransaction(params IRepository[] repositories);
        IUnitOfWork BeginTransaction();
        IUnitOfWork BeginTransaction(IsolationLevel iso);
        IUnitOfWork With(IRepository repository);
        void ExecuteQuery(string query, object o);
        IEnumerable<T> ExecuteQuery<T>(string query, object o);
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, object o);
        void RollBack();
        void Commit();
    }
}