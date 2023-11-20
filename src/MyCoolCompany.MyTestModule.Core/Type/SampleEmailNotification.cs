using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.NotificationsModule.Core.Model;

namespace MyCoolCompany.MyTestModule.Core.Type
{
    public class SampleEmailNotification : EmailNotification
    {
        public SampleEmailNotification() : base(nameof(SampleEmailNotification))
        {
        }

        public SampleEmailNotification(string type) : base(type)
        {

        }

        public string ClientName { get; set; }

        public int ProductCount { get; set; }
    }
}
