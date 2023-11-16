using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.NotificationsModule.Core.Model;

namespace MyCoolCompany.MyTestModule.Core.Type
{
    public class CustomEmailNotification : EmailNotification
    {

        public CustomEmailNotification() : base(nameof(CustomEmailNotification))
        {
        }

        public CustomEmailNotification(string type) : base(type)
        {
            Templates = new List<NotificationTemplate>();
        }
    }
}
