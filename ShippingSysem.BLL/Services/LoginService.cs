using Microsoft.EntityFrameworkCore;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
	public class LoginService
	{
		public IGenericRepository<Account> IGenericRepo { get; }
        public LoginService(IGenericRepository<Account> iGenericRepo)
        {
			IGenericRepo = iGenericRepo;
		}

		//public Task<bool> Login(string email,string password)
		//{
		//	var userCheck = CheckAcc(email, password);
		//	if (userCheck == "email isn't exist")
		//	{
		//		return Ok("email isn't exist");
		//	}
		//	else if (userCheck == "password is wrong")
		//	{
		//		return Ok("password is wrong");
		//	}
		//}
		public string CheckAcc(string email,string password)
		{
			var user = IGenericRepo.GetAllWithFilter(x => x.Email == email).Result.FirstOrDefault();
			if (user == null)
			{
				return "email isn't exist";
			}
			else
			{
				var checkPass = IGenericRepo.GetAllWithFilter(x => x.Email == email && x.PasswordHash==password).Result.FirstOrDefault(); 
				if (checkPass == null)
				{
					return "password is wrong";
				}
				else
				{
					return "email & pass correct";
				}
			}
		}

	}
}
