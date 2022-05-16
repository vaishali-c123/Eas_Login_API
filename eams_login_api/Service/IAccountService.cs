using EmployeeAttendanceSystem.Models;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Services.AccountServices
{
	public interface IAccountService
	{
		public  Task<LoginResponse> Login(Loginrequest user);
	}
}
