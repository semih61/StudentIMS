﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repository
{
	public interface IRepository<T> where T : class //where kontrol yapıyor class değilse geçirme
	{
		IEnumerable<T> GetAll();
		T Get(Expression<Func<T, bool>> filter);
		void Add(T obj);
		void Delete(T obj);
		void DeleteRange(IEnumerable<T> obj);
			
	}
}
