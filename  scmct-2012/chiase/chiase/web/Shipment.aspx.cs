 using System;
 using System.Data;
 using System.Configuration;
 using System.Collections;
 using System.Web;
 using System.Web.Security;
 using System.Web.UI;
 using System.Web.UI.WebControls;
 using System.Web.UI.WebControls.WebParts;
 using System.Web.UI.HtmlControls;
 
 namespace chiase {
 public partial class Shipment : System.Web.UI.Page
 {
     protected void Page_Load(object sender, EventArgs e)
     {
     }
     protected string GetCaption(string dictionaryID)
     {
        return DictionaryDB.sGetValueLanguage(dictionaryID);
     }
 }
 }
 
