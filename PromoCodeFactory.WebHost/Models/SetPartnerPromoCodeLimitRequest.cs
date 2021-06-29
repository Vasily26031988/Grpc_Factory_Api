using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Models
{
    public class SetPartnerPromoCodeLimitRequest
    {
	    public DateTime EndDate { get; set; }
	    public int Limit { get; set; }
    }
}
