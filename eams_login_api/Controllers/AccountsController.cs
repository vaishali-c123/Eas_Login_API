using EmployeeAttendanceSystem.Models;
using EmployeeAttendanceSystem.Services.AccountServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Controllers
{

    [ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public AccountsController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost]
		[Route("api/[controller]/Login")]
		public async Task<ActionResult<LoginResponse>> Login(Loginrequest user)
		{
			return Ok(await _accountService.Login(user));
		}
	}
}
