using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    Label1.Text = DateTime.Today.ToString(" dd/MM/yyyy");


        if (!Page.IsPostBack)
        {
            string selectedTheme = Page.Theme;
            HttpCookie preferredTheme = Request.Cookies.Get("PreferredTheme");
            if (preferredTheme != null)
            {
                selectedTheme = preferredTheme.Value;
            }
            if (!string.IsNullOrEmpty(selectedTheme) && ThemeList.Items.FindByValue(selectedTheme) != null)
            {
                ThemeList.Items.FindByValue(selectedTheme).Selected = true;
            }
        }
    }
  
protected void  ThemeList_SelectedIndexChanged(object sender, EventArgs e)
{
    HttpCookie preferredTheme = new HttpCookie("PreferredTheme");
     preferredTheme.Expires = DateTime.Now.AddMonths(3);
     preferredTheme.Value = ThemeList.SelectedValue;
     Response.Cookies.Add(preferredTheme);
     Response.Redirect(Request.Url.ToString());
    }

protected void TextBox1_TextChanged(object sender, EventArgs e)
{

}
protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
{

}
}
