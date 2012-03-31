using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace chiase
{
    public static class functions
    {

        public static void add_date_to_dropd(DropDownList objday, DropDownList objmonth, DropDownList objyear, int addyear)
        {
            //Day
            int i;
            string val;
            for (i = 1; i <= 31; i++)
            {
              
                val = i.ToString();
                objday.Items.Insert(i - 1, new ListItem(val, val));
            }

            //Month
            for (i = 1; i <= 12; i++)
            {
                val = i.ToString();
                objmonth.Items.Insert(i - 1, new ListItem(val, val));
            }

            //Year
            for (i = 0; i < 90; i++)
            {
                int year = DateTime.Now.Year + addyear;
                objyear.Items.Insert(i, new ListItem((year - i).ToString(), (year - i).ToString()));
            }

        }
        public static void fill_DropdownList(DropDownList obj, DataTable table,int v_Index, int v_Text)
        {

            int i = 0;
            if (table.Rows.Count > 0)
            {
                obj.Items.Clear();
                foreach (DataRow dr in table.Rows)
                {
                    String valValue = dr[v_Index].ToString();
                    String valText = dr[v_Text].ToString();
                    obj.Items.Insert(i, new ListItem(valText,valValue));
                    i++;
                }

            }
        
        
        }
        public static int selectedDropdown(DropDownList obj, String val)
        {
            int indexInt = 0;
            foreach (ListItem lst in obj.Items)
            {
                if (lst.Value == val)
                {
                    return indexInt;
                }
                indexInt++;
            }
            return 0;
        }
    }
}