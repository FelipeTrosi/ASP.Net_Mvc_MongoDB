using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Felipe.Web.AspNet.Classes
{
    public class Teste
    {
        static void Main(string[] args)
        {

            DateTime data1 = DateTime.Now.AddDays(1);
            DateTime data2 = DateTime.Now.AddDays(-1);

            Console.WriteLine(data1);
            Console.WriteLine(data2);

        }

    }
}