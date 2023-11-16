using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;

namespace MyCoolCompany.MyTestModule.Core.Models
{
    public class Blog : AuditableEntity, ICloneable
    {
        public string Name { get; set; }

        public object Clone() => MemberwiseClone();
        
    }
}
