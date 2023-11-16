using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCoolCompany.MyTestModule.Core.Models;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Domain;

namespace MyCoolCompany.MyTestModule.Data.Models
{
    public class BlogEntity : AuditableEntity, IDataEntity<BlogEntity, Blog>
    {
        public string Name { get; set; }
        public BlogEntity FromModel(Blog model, PrimaryKeyResolvingMap pkMap)
        {
            pkMap.AddPair(model, this);
            Id = model.Id;
            Name = model.Name;
            return this;
        }

        public void Patch(BlogEntity target)
        {
            target.Name = Name;
        }

        public Blog ToModel(Blog model)
        {
            model.Id = Id;
            model.Name = Name;

            return model;
        }
    }
}
