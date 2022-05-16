  using System.Text.Json.Serialization;

namespace EmployeeAttendanceSystem.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum EmployeeType
	{
		Admin , 
		Employee 
	}
}
