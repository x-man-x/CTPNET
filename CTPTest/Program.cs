using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaiFeng
{
	class Program
	{
		static void Main(string[] args)
		{

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Trade());
            
       //     int i = 1;
       //     if (false) {
       //         CtpQuote tq = new CtpQuote();
       //         tq.Run();
       //         Console.WriteLine("Press any key to continue . . . ");
       //         Console.ReadKey(true);

       //         CtpTrade tt = new CtpTrade();
			    //tt.Run();
			    //Console.WriteLine("Press any key to continue 1. . . ");
		     //   Console.ReadKey(true);
			    //tt.ShowInfo();
			    //Console.ReadKey(true);
       //         tt.Release();
       //         //tq.Release();

       //        Console.ReadKey(true);
       //     }

           
		}
	}
}
