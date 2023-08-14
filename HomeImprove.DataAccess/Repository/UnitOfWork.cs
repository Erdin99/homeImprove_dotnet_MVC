using HomeImpr.DataAccess.Data;
using HomeImpr.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeImpr.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _db;
		public ICategoryRepository Category { get; private set; }
		public IHandymanRepository Handyman { get; private set; }
		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Category = new CategoryRepository(_db);
			Handyman = new HandymanRepository(_db);
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
