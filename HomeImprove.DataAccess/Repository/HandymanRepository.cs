using HomeImpr.DataAccess.Data;
using HomeImpr.DataAccess.Repository.IRepository;
using HomeImpr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeImpr.DataAccess.Repository
{
	public class HandymanRepository : Repository<Handyman>, IHandymanRepository
	{
		private ApplicationDbContext _db;
        public HandymanRepository(ApplicationDbContext db) : base(db)
        {
			_db = db;
        }
   
		public void Update(Handyman obj)
		{
			var objFromDb = _db.Handymans.FirstOrDefault(u => u.Id == obj.Id);
			if(objFromDb != null)
			{
				objFromDb.Title = obj.Title;
				objFromDb.Description = obj.Description;
				objFromDb.Name = obj.Name;
				objFromDb.Price = obj.Price;
				objFromDb.CategoryId = obj.CategoryId;
				if(obj.ImageUrl != null)
				{
					objFromDb.ImageUrl = obj.ImageUrl;
				}
			}
		}
	}
}
