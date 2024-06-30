using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Interfaces.Base
{
    public interface IGenericStatusRepository<T> :IGenericRepository<T> where T : class ,IStatus,IEntity
	{
        public void ChangeStatus(T row);
    }
}
