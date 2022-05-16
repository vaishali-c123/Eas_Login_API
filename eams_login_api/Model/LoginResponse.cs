using System.Net.Http;
namespace EmployeeAttendanceSystem.Models
{
	public class LoginResponse
	{
        public LoginResponse()
        {

            this.Token = "";
            //this.responseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }

        public string Token { get; set; }
        public string responseMsg { get; set; }
    }
}
