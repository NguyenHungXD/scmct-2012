using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chiase
{
    public static class globalVariable
    {
        static string _vSelected = "1";
        public static string vSelected
        {
            get
            {
                return _vSelected;
            }
            set
            {
                _vSelected = value;
            }
        }
    }
}