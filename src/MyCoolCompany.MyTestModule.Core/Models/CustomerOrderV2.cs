using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.OrdersModule.Core.Model;

namespace MyCoolCompany.MyTestModule.Core.Models
{
    public class CustomerOrderV2 : CustomerOrder
    {
        public CustomerOrderV2():base()
        {            
        }

        public string NewOrderField { get; set; }

    }
}
