using HomeImpr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeImpr.DataAccess.Repository.IRepository
{
	public interface IHandymanRepository : IRepository<Handyman>
	{
		void Update(Handyman obj);
	}
}
