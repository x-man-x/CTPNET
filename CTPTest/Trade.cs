using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaiFeng
{
    public partial class Trade : Form
    {
        //合约价格
        private int price = 0;
        private String price_first = null;//中间价 后面设置  6163
        private String sell_nums = null;//中间价 后面设置  6163
        private String buy_nums = null;//中间价 后面设置  6163
        private String quote_url = null;
        private String trade_url = null;
        private String username = null;
        private String password = null;
        private String broker = null;
        private String sub1 = null;
        public String root_dir = null;
        private FileAction fileAction = new FileAction(); 
        public PlatformInfo platformInfo = null;

        public Log LogSave = new Log(AppDomain.CurrentDomain.BaseDirectory);
        //public string c = "8899", _investor = "99901110", _investorpass = "686868", _sub1 = "SR801", _sub2 = "m1709";
        //private System.Windows.Forms.Timer Form_Timer;
        private CtpQuote ctpQuote = null;//初始化行情进程
        private CtpTrade ctpTrade = null;//初始化交易进程

        public  IList<OrderField> submit_order_list = null;
        public  IList<OrderField> submit_order_success_list = null;
        public  IList<TradeField> trade_success_list = null;
        

        public Trade()
        {
            // C:\Users\wkjy\Desktop\CTPNET\CTPTest\Debug\
            root_dir = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
           
             String mac = "3C-F8-62-E9-A5-3A";//Bx
            //String mac = "9C-5C-8E-2E-60-7C";//Yu 9C-5C-8E-2E-60-7C
            //String mac = "9C-5C-8E-2E-60-7C";//Yu Office
            Boolean flag = false;
            MacByIPConfig mbc = new MacByIPConfig();

            List<String> lt = mbc.GetMacByIPConfig();
            string[] stringSeparators = new string[] { ": " };
            for (int i = 0; i < lt.Count; i++) {
                String mac_temp = lt[i].ToString().Split(stringSeparators, StringSplitOptions.None)[1];
                //Console.WriteLine(mac_temp);
                if (mac_temp == mac) {
                    flag = true;
                }
            }


            if (flag)
            {
                InitializeComponent();
                
                platformInfo = fileAction.Read(root_dir);

                textBox1.Text = platformInfo.Tcp_ip_quote;
                textBox2.Text = platformInfo.Tcp_ip_trade;
                textBox5.Text = platformInfo.Sub;
                textBox10.Text = platformInfo.Sell_nums;
                textBox7.Text = platformInfo.First_price;
                textBox8.Text = platformInfo.Buy_nums;
                textBox3.Text = platformInfo.Investor;
                textBox4.Text = platformInfo.Investorpass;
                textBox9.Text = platformInfo.Broker;
                this.Refresh();

            }
            else {
                LogSave.log("小子你没注册呢？请不要轻易使用，谢谢！");
                Console.WriteLine("小子你没注册呢？请不要轻易使用，谢谢！");
            }

            


        }

       



        private void loginButton_Click(object sender, EventArgs e)
        {
            this.initOrderButton.Visible = true;
            this.loginButton.Visible = false;
            this.logoutButton.Visible = true;

            price_first = textBox7.Text;
            sell_nums = textBox10.Text;
            buy_nums = textBox8.Text; 

            quote_url = textBox1.Text;
            trade_url = textBox2.Text;

            username = textBox3.Text;
            password = textBox4.Text;

            broker = textBox9.Text;
            sub1 = textBox5.Text;

            LogSave.log("程序启动............. ");
            Console.WriteLine("程序启动............. ");
            LogSave.log("quote_url： " + quote_url + "\n trade_url" + trade_url + "\n username" + username + "\n password" + password + "\n investorpass" + broker + "\n price_first" + price_first + "\n sub1" + sub1);
            Console.WriteLine("quote_url： "+ quote_url+ "\n trade_url" + trade_url+ "\n username"+ username + "\n password"+ password+ "\n investorpass"+ broker + "\n price_first" + price_first + "\n sub1"+ sub1);

           
            ctpQuote = new CtpQuote(quote_url, trade_url, username, password, broker, price_first, sub1);
            ctpTrade = new CtpTrade(quote_url, trade_url, username, password, broker, price_first, sub1);


            int i = 1; 
            if (i ==1)
            {
                ctpQuote.Run();
                ctpTrade.Run();
            }

            IList<OrderField> openOrderList = this.fileAction.ReadOpenOrders(root_dir);
            String Title1 = "隔夜定单\n";
            String List_submit_order = "";
            for (int m = 0; m < openOrderList.Count; m++)
            {
                List_submit_order = List_submit_order + (m + 1).ToString("D3") + " " + openOrderList[m].ToShortString() + "\n";
            }//for
            this.richTextBox1.Text = Title1 + List_submit_order;

        }

        private void closeTQ() {
            ctpQuote.Release();
            ctpTrade.Release();
        }
        

        private void Trade_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
          

        }

        String List_all_trade = null;

        private void timer1_Tick(object sender, EventArgs e)
        {
            string logMessage = "timer1:" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
            //LogSave.log(logMessage);
            //Console.WriteLine(logMessage);
            //Thread.Sleep(1000);
            // todo: revert when trading.
            //price = 1;
            if(ctpQuote.NowPrice==null)
            {
                logMessage = "[" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff")+"]尚未收到最新价格，略过。";
                LogSave.log(logMessage);
                Console.WriteLine(logMessage);
                return;
            }
            price = int.Parse(ctpQuote.NowPrice);
            
            this.textBox6.Text = price.ToString();
            this.Refresh();

            // Console.WriteLine("................开始...................");

            //lt_trade = tt._lt_trade;
            //lt_trade_success = tt._lt_trade_success;
            //lt_submit_success = tt._lt_submit_success;

            IList<OrderField> openOrderEnumerable = this.ctpTrade.getOpenOrders();

            this.fileAction.WriteOpenOrders(root_dir, openOrderEnumerable);
           

            String Title1 = "Part I 提交定单\n";
            String List_submit_order = "";
            int ordinal = 1;
            foreach (OrderField openOrder in openOrderEnumerable)
            {
                List_submit_order = List_submit_order + ordinal.ToString("D3")+" " +openOrder.ToShortString()+ "\n";
                ordinal++;
            }//for

            String Title2 = "Part II 成交定单\n";
            IEnumerable<OrderField> filledOrderEnumerable = this.ctpTrade.getFilledOrders2();
            String List_submit_order_success = "";
             ordinal = 1;
            foreach (OrderField filledOrder in filledOrderEnumerable)
            {
                List_submit_order_success = List_submit_order_success + ordinal.ToString("D3") + " " + filledOrder.ToShortString() + "\n";
                ordinal++;
            }

            String Title3 = "Part III 成交记录\n";
            trade_success_list = ctpTrade.getExecutioins();
            String List_trade_success = null;
            ordinal = 1;
            foreach (TradeField tradeField in trade_success_list)
            {
                List_trade_success = List_trade_success + ordinal + " " + tradeField.OrderID + "---" + tradeField.Price + "\n";
                ordinal++;
            }

            richTextBox1.Text = Title1 + List_submit_order + Title2 + List_submit_order_success + Title3 + List_trade_success;
            //lt_trade;
            //lt_trade_success = tt._lt_trade_success;

            // Console.WriteLine("................结束...................");

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            closeTQ();
            timer1.Stop();
            timer2.Stop();
            this.initOrderButton.Visible = false;
            this.loginButton.Visible = true;
            this.logoutButton.Visible = false;
            //Console.ReadKey(true);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ctpTrade.buy_btn_Open(double.Parse(price.ToString())+1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ctpTrade.sell_btn_Open(double.Parse(price.ToString()) - 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            price_first = textBox7.Text;
            timer2.Start();
            
        }
        int i = 1;
        int j = 1;
        int flag = 1;
        private void timer2_Tick(object sender, EventArgs e)
        {
            int sell_nums_ar = int.Parse(sell_nums);//卖单挂单数
            int buy_nums_ar = int.Parse(buy_nums);//买单挂单数

            int price_first_int = int.Parse(price_first); //设定中间价

            //卖单下单
            if (sell_nums_ar >= i) {
                LogSave.log("卖单" + i + "..." + (price_first_int + i));
                Console.WriteLine("卖单" + i + "..." + (price_first_int + i));
                ctpTrade.sell_btn_Open(price_first_int + i);
            }

            //卖单下单
            if (buy_nums_ar >= i) {
                LogSave.log("卖单" + i + "..." + (price_first_int + i));
                Console.WriteLine("买单" + i + "..." + (price_first_int - i));
                ctpTrade.buy_btn_Open(price_first_int - i);
            }

            i++;

            if (i > sell_nums_ar && i > buy_nums_ar) {
                timer2.Stop();
            }
            
        }

        private void initOrderButton_Click(object sender, EventArgs e)
        {
            //保存设置数据
            platformInfo = new PlatformInfo();
            platformInfo.Tcp_ip_quote = textBox1.Text.ToString();
            platformInfo.Tcp_ip_trade = textBox2.Text.ToString();
            platformInfo.Sub = textBox5.Text.ToString();

            platformInfo.Sell_nums = textBox10.Text.ToString();
            platformInfo.First_price = textBox7.Text.ToString();
            platformInfo.Buy_nums = textBox8.Text.ToString();

            platformInfo.Investor = textBox3.Text.ToString();
            platformInfo.Investorpass = textBox4.Text.ToString();
            platformInfo.Broker = textBox9.Text.ToString();

            Boolean task = fileAction.Write(root_dir, platformInfo);

            if (task)
            {
                LogSave.log("数据保存成功！");
                Console.WriteLine("数据保存成功！");
            }
            price_first = textBox7.Text;
            int price_first_int = int.Parse(price_first); //设定中间价

            sell_nums = textBox10.Text;
            buy_nums = textBox8.Text;

            int sell_nums_ar = int.Parse(sell_nums);//卖单挂单数
            int buy_nums_ar = int.Parse(buy_nums);//买单挂单数

            IList<OrderField> openOrderList = this.fileAction.ReadOpenOrders(root_dir);
            if (openOrderList != null && openOrderList.Count > 0)
            {
                IEnumerator<OrderField> openOrderEnumerator = openOrderList.GetEnumerator();
                string logMessage;
                while (openOrderEnumerator.MoveNext())
                {
                    OrderField tempOrderField = openOrderEnumerator.Current;
                    if (tempOrderField.Direction == DirectionType.Buy)
                    {
                        if (tempOrderField.Offset == OffsetType.Close)
                        {
                            logMessage = "恢复定单：买平@" + tempOrderField.LimitPrice;
                            LogSave.log(logMessage);
                            Console.WriteLine(logMessage);
                            ctpTrade.buy_btn_Close(tempOrderField.LimitPrice);
                        }
                        else if (tempOrderField.Offset == OffsetType.Open)
                        {
                            logMessage = "恢复定单：买开@" + tempOrderField.LimitPrice;
                            LogSave.log(logMessage);
                            Console.WriteLine(logMessage);
                            ctpTrade.buy_btn_Open(tempOrderField.LimitPrice);
                        }
                        else
                        {
                            logMessage = "未知定单：" + tempOrderField.Offset + ",价格：" + tempOrderField.LimitPrice;
                            LogSave.log(logMessage);
                            Console.WriteLine(logMessage);
                        }
                    }
                    else
                    {
                        if (tempOrderField.Offset == OffsetType.Close)
                        {
                            logMessage = "恢复定单：卖平@" + tempOrderField.LimitPrice;
                            LogSave.log(logMessage);
                            Console.WriteLine(logMessage);
                            ctpTrade.sell_btn_Close(tempOrderField.LimitPrice);
                        }
                        else if (tempOrderField.Offset == OffsetType.Open)
                        {
                            logMessage = "恢复定单：卖开@" + tempOrderField.LimitPrice;
                            LogSave.log(logMessage);
                            Console.WriteLine(logMessage);
                            ctpTrade.sell_btn_Open(tempOrderField.LimitPrice);
                        }
                        else
                        {
                            logMessage = "未知定单：" + tempOrderField.Offset + ",价格：" + tempOrderField.LimitPrice;
                            LogSave.log(logMessage);
                            Console.WriteLine(logMessage);
                        }
                    }

                }//while

            }//if
            else
            {
                for (int i = 0; i < sell_nums_ar; i++)
                {
                    LogSave.log("卖单" + i + "..." + (price_first_int + i));
                    Console.WriteLine("卖单" + i + "..." + (price_first_int + i));
                    ctpTrade.sell_btn_Open(price_first_int + i + 1);
                }

                for (int j = 0; j < buy_nums_ar; j++)
                {
                    LogSave.log("买单" + j + "..." + (price_first_int - j));
                    Console.WriteLine("买单" + j + "..." + (price_first_int - j));
                    ctpTrade.buy_btn_Open(price_first_int - j - 1);
                    //  Thread.Sleep(20);
                }
            }
            timer1.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int price_first_int = int.Parse(price_first);
            ctpTrade.sell_btn_Open(price_first_int+1);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void testSaveOpenOrdersButton_Click(object sender, EventArgs e)
        {
            OrderField orderField1 = new OrderField() {
                OrderID="1",
                Direction= DirectionType.Buy,
                Offset = OffsetType.Open
            };
            OrderField orderField2 = new OrderField()
            {
                OrderID = "2",
                Direction = DirectionType.Sell,
                Offset = OffsetType.Close
            };
            string path = "d:\\temp\\";
            IList<OrderField> orderList = new List<OrderField>();
            orderList.Add(orderField1);
            orderList.Add(orderField2);

            this.fileAction.WriteOpenOrders(path,orderList);

            IList<OrderField> observedOrderList = this.fileAction.ReadOpenOrders(path);
            Console.Write(observedOrderList);

        }

        private void cleanOvernightOrderButton_Click(object sender, EventArgs e)
        {
            IList<OrderField> openOrderList = new List<OrderField>();
            this.fileAction.WriteOpenOrders(root_dir, openOrderList);
            this.richTextBox1.Text = "隔夜定单\n已清空";

        }
    } // class
}//namespace


//循环方法
 //while (true)
 //           {
 //               price = tq.NowPrice;
 //               this.textBox6.Text = price;
 //               // Console.WriteLine("现价：" + price);
 //               this.Refresh();

 //           }