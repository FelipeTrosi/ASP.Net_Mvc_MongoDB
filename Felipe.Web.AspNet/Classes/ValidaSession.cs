using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Felipe.Web.AspNet.Classes
{
    public static class ValidaSession
    {
        public static bool Autenticado
        {
            get
            {
                if (HttpContext.Current.Session["Autenticado"] != null)
                    return Convert.ToBoolean(HttpContext.Current.Session["Autenticado"]);
                else
                    return false;
            }
            set
            {
                HttpContext.Current.Session["Autenticado"] = value;
            }
        }

        public static string CodigoUsuario
        {
            get
            {
                if (HttpContext.Current.Session["CodigoUsuario"] != null)
                    return HttpContext.Current.Session["CodigoUsuario"].ToString();
                else
                    return string.Empty;
            }
            set
            {
                HttpContext.Current.Session["CodigoUsuario"] = value;
            }
        }

        public static string NomeUsuario
        {
            get
            {
                if (HttpContext.Current.Session["NomeUsuario"] != null)
                    return HttpContext.Current.Session["NomeUsuario"].ToString();
                else
                    return string.Empty;
            }
            set
            {
                HttpContext.Current.Session["NomeUsuario"] = value;
            }
        }
    }
}