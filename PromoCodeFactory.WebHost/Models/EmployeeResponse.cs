using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Models
{
    public class EmployeeResponse
    {
	    public Guid Id { get; set; }
	    public string FullName { get; set; }

	    public string Email { get; set; }

	    public RoleItemResponse Role { get; set; }

	    public int AppliedPromocodesCount { get; set; }
    }
}
