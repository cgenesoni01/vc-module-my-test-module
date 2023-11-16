using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCoolCompany.MyTestModule.Core.Models;
using StackExchange.Redis;
using VirtoCommerce.OrdersModule.Core.Model;
using VirtoCommerce.OrdersModule.Data.Model;
using VirtoCommerce.Platform.Core.Common;

namespace MyCoolCompany.MyTestModule.Data.Models
{
    public class CustomerOrderV2Entity: CustomerOrderEntity
    {
        public CustomerOrderV2Entity() { }

        public string NewOrderField { get; set; }

        public override CustomerOrderEntity FromModel(CustomerOrder order, PrimaryKeyResolvingMap pkMap)
        {
            if (order is CustomerOrderV2 order2)
            {
                this.NewOrderField = order2.NewOrderField;
            }
            
            return base.FromModel(order, pkMap);
        }

        public override OperationEntity FromModel(OrderOperation operation, PrimaryKeyResolvingMap pkMap)
        {
            if (operation is CustomerOrderV2 order2)
            {
                this.NewOrderField = order2.NewOrderField;
            }

            base.FromModel(operation,pkMap);
            return this;
        }

        public override CustomerOrder ToModel(CustomerOrder order)
        {
            if (order is CustomerOrderV2 order2)
            {
                order2.NewOrderField = this.NewOrderField;
            }

            base.ToModel(order);
            return order;
        }

        public override OrderOperation ToModel(OrderOperation operation)
        {
            if (operation is CustomerOrderV2 order2)
            {
                order2.NewOrderField = this.NewOrderField;
            }
            base.ToModel(operation);
            return operation;
        }

        public override void Patch(OperationEntity operation)
        {
            if (operation is CustomerOrderV2Entity order2)
            {
                order2.NewOrderField = this.NewOrderField;
            }

            base.Patch(operation);
        }

        public override void Patch(CustomerOrderEntity order)
        {
            if (order is CustomerOrderV2Entity order2)
            {
                order2.NewOrderField = this.NewOrderField;
            }

            base.Patch(order);
        }
    }
}
