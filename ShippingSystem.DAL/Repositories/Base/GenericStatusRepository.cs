using Microsoft.EntityFrameworkCore;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Repositories.Base
{
	public class GenericStatusRepository<T> : GenericRepository<T> , IGenericStatusRepository<T> where T : class,IEntity,IStatus
	{
		private readonly ShippingDBContext context;
		private readonly DbSet<T> dbSet;

		public GenericStatusRepository(ShippingDBContext context) : base(context)
		{
			this.context = context;
			dbSet = this.context.Set<T>();
		}
		public async void ChangeStatus(T row)
		{
			row.Status = !row.Status;
		}
		public async void Delete(T row)
		{
			row.IsDeleted = true;
			//row.IsDeleted = !row.IsDeleted;
		}
	}
}
