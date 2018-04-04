using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace HaiFeng
{
    class FileAction
    {
        JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
        string openOrdersFileName = "open-orders.json";
        // private string Tcp_ip_quote = null;
        // private string Tcp_ip_trade = null;
        //private string Sub = null;

        //private string buy_nums = null;
        // private string first_price = null;
        //private string sell_nums = null;

        //private string investor = null;
        //private string investorpass = null;
        //private string broker = null;


        public PlatformInfo Read(string path)
        {
            StreamReader sr = new StreamReader(path + "/info.txt", Encoding.Default);
            String line;

            PlatformInfo PI = new PlatformInfo();
            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (i == 0)
                {
                    PI.Tcp_ip_quote = line.ToString();
                }
                else if (i == 1)
                {
                    PI.Tcp_ip_trade = line.ToString();
                }
                else if (i == 2) {
                    PI.Sub = line.ToString();
                }
                else if (i == 3)
                {
                    PI.Sell_nums = line.ToString();
                }
                else if (i == 4)
                {
                    PI.First_price = line.ToString();
                }
                else if (i == 5)
                {
                    PI.Buy_nums = line.ToString();
                }
                else if (i == 6)
                {
                    PI.Investor = line.ToString();
                }
                else if (i == 7)
                {
                    PI.Investorpass = line.ToString();
                }
                else if (i == 8)
                {
                    PI.Broker = line.ToString();
                }
                i++;
            }

            return PI;

        }

        public Boolean Write(string path, PlatformInfo PI)
        {
            
            FileStream fs = new FileStream(path+"/info.txt", FileMode.Create);
            //获得字节数组

            byte[] data = System.Text.Encoding.Default.GetBytes(PI.Tcp_ip_quote+"\r\n");
            byte[] data1 = System.Text.Encoding.Default.GetBytes(PI.Tcp_ip_trade + "\r\n");
            byte[] data2 = System.Text.Encoding.Default.GetBytes(PI.Sub + "\r\n");
            byte[] data3 = System.Text.Encoding.Default.GetBytes(PI.Sell_nums + "\r\n");
            byte[] data4 = System.Text.Encoding.Default.GetBytes(PI.First_price + "\r\n");
            byte[] data5 = System.Text.Encoding.Default.GetBytes(PI.Buy_nums + "\r\n");
            byte[] data6 = System.Text.Encoding.Default.GetBytes(PI.Investor + "\r\n");
            byte[] data7 = System.Text.Encoding.Default.GetBytes(PI.Investorpass + "\r\n");
            byte[] data8 = System.Text.Encoding.Default.GetBytes(PI.Broker + "\r\n");
            //开始写入
            fs.Write(data, 0, data.Length);
            fs.Write(data1, 0, data1.Length);
            fs.Write(data2, 0, data2.Length);
            fs.Write(data3, 0, data3.Length);
            fs.Write(data4, 0, data4.Length);
            fs.Write(data5, 0, data5.Length);
            fs.Write(data6, 0, data6.Length);
            fs.Write(data7, 0, data7.Length);
            fs.Write(data8, 0, data8.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
            return true;
        }

        public Boolean WriteOpenOrders(string path, IList<OrderField> openOrderList)
        {
            string filePath = path + this.openOrdersFileName;
            string openOrderString = this.javaScriptSerializer.Serialize(openOrderList);
            //FileStream fs = new FileStream(path + this.openOrdersFileName, FileMode.Create);
            ////获得字节数组

            //byte[] data = System.Text.Encoding.Default.GetBytes(openOrderString);
            ////开始写入
            //fs.Write(data, 0, data.Length);

            ////清空缓冲区、关闭流
            //fs.Flush();
            //fs.Close();
            using (StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                streamWriter.Write(openOrderString);
            }
            return true;
        }

        public IList<OrderField> ReadOpenOrders(string path)
        {
            string filePath = path + this.openOrdersFileName;
            if (!File.Exists(filePath))
            {
                return new List<OrderField>(0);
            }
            using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
            {
                string openOrdersString = sr.ReadToEnd();
                if (openOrdersString == null || openOrdersString.Trim().Length > 0)
                {
                    IList<OrderField> openOrderList = this.javaScriptSerializer.Deserialize<IList<OrderField>>(openOrdersString);
                    return openOrderList;
                }
                else
                {
                    return new List<OrderField>(0);
                }
            }

        }


    }
}
