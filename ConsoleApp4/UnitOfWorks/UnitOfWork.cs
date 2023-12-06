using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using UowWithRepository.Repositories.Interfaces;
using UowWithRepository.UnitOfWorks.Interfaces;

namespace UowWithRepository.UnitOfWorks
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private List<IRepository> _repositories = new();

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            if (_connection.State == ConnectionState.Closed ) _connection.Open();
        }

        public UnitOfWork(IDbConnection connection, params IRepository[] repositories): this(connection)
        {
            UpdateRepositories(repositories);
        }

        public IUnitOfWork BeginTransaction(params IRepository[] repositories)
        {
            UpdateRepositories(repositories);
            if (_transaction != null)
            {
                throw new DataException("this unitOfWork has already an open transaction!");
            }
            _transaction = _connection.BeginTransaction();
            return this;
        }

        public IUnitOfWork BeginTransaction(IsolationLevel iso, params IRepository[] repositories)
        {
            UpdateRepositories(repositories);
            if (_transaction != null) 
            {
                throw new DataException("this unitOfWork has already an open transaction!");
            }
            _transaction = _connection.BeginTransaction(iso);
            return this;
        }

        public IUnitOfWork BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new DataException("this unitOfWork has already an open transaction!");
            }
            _transaction = _connection.BeginTransaction();
            return this;
        }

        public IUnitOfWork BeginTransaction(IsolationLevel iso)
        {
            if (_transaction != null)
            {
                throw new DataException("this unitOfWork has already an open transaction!");
            }
            _transaction = _connection.BeginTransaction(iso);
            return this;
        }

        public IUnitOfWork With(IRepository repository)
        {
            repository.SetUnitOfWork(this);
            if (_repositories.Exists(x => x == repository) == false) _repositories.Add(repository);
            return this;
        }

        public void Commit()
        {
            if (_transaction == null)
            {
                throw new DataException("this unitOfWork has no transaction!");
            }
            Console.WriteLine("Commit");
            _transaction?.Commit();
            _transaction = null;
        }

        public void RollBack()
        {
            if (_transaction == null)
            {
                throw new DataException("this unitOfWork has no transaction!");
            }

            Console.WriteLine("RollBack");
            _transaction?.Rollback();
            _transaction = null;
        }
        public void Dispose()
        {
            if (_transaction != null)
            {
                throw new DataException("this unitOfWork has an open transaction!");
            }
            Console.WriteLine("Dispose");
            _connection?.Close();
            _repositories.ToList().ForEach(x => x.RemoveUnitOfWork());
            _repositories.Clear();
        }

        public void ExecuteQuery(string query, object o)
        {
            Console.WriteLine($"execute '{query}'");
            _connection.Query(query, o,_transaction);
        }

        public IEnumerable<T> ExecuteQuery<T>(string query, object o)
        {
            Console.WriteLine($"execute '{query}'");
            return _connection.Query<T>(query, o, _transaction);
        }
        public Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, object o)
        {
            Console.WriteLine($"execute '{query}'");
            return _connection.QueryAsync<T>(query, o, _transaction);
        }

        private void UpdateRepositories(IRepository[] repositories)
        {
            _repositories.ToList().ForEach(x => x.RemoveUnitOfWork());
            _repositories = repositories.ToList();
            _repositories.ForEach(x => x.SetUnitOfWork(this));
        }

    }
}