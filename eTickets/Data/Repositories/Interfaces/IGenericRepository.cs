using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eTickets.Data.Repositories.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
		T GetById(int? id);
		public Task<T> GetByIdAsync(int? id);
		IEnumerable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
		public Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties);

		IEnumerable<T> GetAll();
		public Task<IEnumerable<T>> GetAllAsync();

		IEnumerable<T> Find(Expression<Func<T, bool>> criteria, string[] includes = null);
		Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

		int Count();
		int Count(Expression<Func<T, bool>> criteria);
		Task<int> CountAsync();
		Task<int> CountAsync(Expression<Func<T, bool>> criteria);
		T Add(T entity);
		Task<T> AddAsync(T entity);
		IEnumerable<T> AddRange(IEnumerable<T> entities);
		Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
		void Delete(T entity);
		void DeleteRange(IEnumerable<T> entities);
		T Update(T entity);
		IEnumerable<T> UpdateRange(IEnumerable<T> entities);

		void Attach(T entity);
		void AttachRange(IEnumerable<T> entities);

	}
}
