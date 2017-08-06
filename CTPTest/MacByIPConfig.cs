using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiFeng
{

    public class  MacByIPConfig
    {
       public List<String> lt = null;
        public  MacByIPConfig() {
            lt = GetMacByIPConfig();
        }
        public List<string> GetMacByIPConfig()
        {
            List<string> macs = new List<string>();
            ProcessStartInfo startInfo = new ProcessStartInfo("ipconfig", "/all");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            Process p = Process.Start(startInfo);
            //截取输出流
            StreamReader reader = p.StandardOutput;
            string line = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    line = line.Trim();

                    if (line.StartsWith("Physical Address"))
                    {
                        macs.Add(line);
                    }
                    if (line.StartsWith("物理地址"))
                    {
                        macs.Add(line);
                    }
                }

                line = reader.ReadLine();
            }

            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();
            reader.Close();

                return macs;
            }


    }

    
}
