using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum OrderStatus
    {
        Принят=0,
        Выполняется=1,
        Готов=2,
        Оплачен=3,
        Доставлен=4,
        Отменен=5
    }
}
