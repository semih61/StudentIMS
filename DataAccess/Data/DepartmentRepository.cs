using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Data.Repository;
using Models.Models;

namespace DataAccess.Data
{
	public class DepartmentRepository : Repository<Department> , IDepartmentRepository
	{
		private readonly StudentDbContext _db;
		public DepartmentRepository(StudentDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Department obj)
		{
			_db.Departments.Update(obj);
		}
	}
}
