using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models.Shared
{
    public class BaseSearchModel<T1, T2>
    {
        public T1 Search { get; set; }
        public T2 DataModel { get; set; }
    }
}
