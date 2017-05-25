using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ShoppingCartTest.Models
{

    // ASP.NET [C#] REDIRECT WITH POST DATA
    public static class WebExtensions
    {
        public static void RedirectWithData(string url, NameValueCollection data)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();

            StringBuilder s = new StringBuilder();
            s.Append("<html>");
            s.AppendFormat("<body onload='document.forms[\"form\"].submit()'>");
            s.AppendFormat("<form name='form' action='{0}' method='post'>", url);
            foreach (string key in data)
            {
                s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", key, data[key]);
            }
            s.Append("</form></body></html>");
            response.Write(s.ToString());
            response.End();
        }
    }








    public class MyIdentityDbContext : IdentityDbContext<MyIdentityUser>
    {
        public MyIdentityDbContext() : base("ShoppingTestEntities")
        {

        }
    }

    public class MyIdentityUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
    }

    public class MyIdentityRole : IdentityRole
    {
        public MyIdentityRole()
        {

        }

        public MyIdentityRole(string roleName, string description) : base(roleName)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }





}
