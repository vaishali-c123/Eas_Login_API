using EmployeeAttendanceSystem.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Services.AccountServices
{
    public class AccountService : IAccountService
	{

		public static readonly List<Admin> admins = new List<Admin>()
		{
			new Admin {AdminId="admin",AdminUsername="admin",AdminPassword="admin" }

		};
		public static readonly List<Employee> Employees = new List<Employee>()
		{
			new Employee { EmployeeId="1", EmployeeName="abc" , EmployeeGender="male" , EmployeeEmail="ak@gmail.com" , EmployeeContact=8767772 ,EmployeeUsername="abc", EmployeePassword="123"}

		};

		
		private readonly IConfiguration _configuration;

		public AccountService( IConfiguration configuration)
		{
			
			this._configuration = configuration;
		}
		private void VerifyPasswordHash(string password, out string passwordHash)
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512())
			{

				hmac.Key = System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Encryption:SHAKEY").Value);
				passwordHash = BitConverter.ToString(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
			}
		}
		//private string GenerateToken(Employee employee)
		//{
		//	var claims = new List<Claim>()
		//	{
		//		new Claim(ClaimTypes.NameIdentifier, employee.EmployeeId),
		//		new Claim(ClaimTypes.Name, employee.EmployeeName),

		//	};
  //          var temp=_configuration.GetSection("Encryption:SHAKEY").Value;
		//	var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Encryption:SHAKEY").Value));
		//	var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

		//	var tokenDescriptor = new SecurityTokenDescriptor()
		//	{
		//		Subject = new ClaimsIdentity(claims),
		//		Expires = System.DateTime.Now.AddDays(1),
		//		SigningCredentials = creds

		//	};
		//	var tokenHandler = new JwtSecurityTokenHandler();
		//	var token = tokenHandler.CreateToken(tokenDescriptor);
		//	return tokenHandler.WriteToken(token);
		//}
		public async Task<LoginResponse> Login(Loginrequest user)
		{
			if (user.EmployeeType == EmployeeType.Employee)
			{
				var userInDB = Employees.Where(u => u.EmployeeUsername.Equals(user.Username) && u.EmployeePassword.Equals(user.Password)).FirstOrDefault();


				if (userInDB is null)
				{
					return new LoginResponse() { Token = null, responseMsg = "authentication failed" };
					
				}
				return new LoginResponse { Token = "Employee", responseMsg = "authentication success" };



			}
			else
			{

				var userInDB = admins.Where(x => x.AdminUsername.Equals(user.Username) && x.AdminPassword.Equals(user.Password)).FirstOrDefault();



				if (userInDB is null)
				{
					return new LoginResponse() { Token = null, responseMsg = "authentication failed" };

				}
				return new LoginResponse { Token = "Admin", responseMsg = "authentication success" };

			}
		}
	}
}

