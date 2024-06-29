using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Enums
{
    public enum OrderStatus
    {

        New,
        Canceled,
        RefusedWithPayment,
        RefusedWithoutPayment,
        RefusedWithPartialPayment,
        DeliveredToDelivery,
        Deliverd,
        PartiallyDelivered,
        Suspended,
        NotRechable,
        Waiting
    }
}
