using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.BusinessLayer.Abstract
{
	public interface IGenericService<T>	where T : class
	{
		void BInsert(T t);
		void BUpdate(T t);
		void BDelete(T t);
		T BGetById(int id);
		List<T> BGetList();

		//added 'B' to make it different from IGenericDAL methods
	}
}
