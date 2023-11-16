using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.NotificationsModule.Core.Model;

namespace MyCoolCompany.MyTestModule.Core.Services
{
    public interface ICustomNotificationService
    {
        Task<NotificationSendResult> SendNotification();
    }
}
