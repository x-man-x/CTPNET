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
        private String quote_url = null;
        private String trade_url = null;
        private String username = null;
        private String password = null;
        private String broker = null;
        private String sub1 = null;

        //public string c = "8899", _investor = "99901110", _investorpass = "686868", _sub1 = "SR801", _sub2 = "m1709";
        //private System.Windows.Forms.Timer Form_Timer;
        private CtpQuote tq = null;//初始化行情进程
        private CtpTrade tt = null;//初始化交易进程

        public  IList<OrderField> lt_trade =null;
        public  IList<TradeField> lt_trade_success = null;


        public Trade()
        {
            InitializeComponent();
           
        }

       



        private void button1_Click(object sender, EventArgs e)
        {
           

            price_first = textBox7.Text;
            sell_nums = textBox8.Text;

            quote_url = textBox1.Text;
            trade_url = textBox2.Text;

            username = textBox3.Text;
            password = textBox4.Text;

            broker = textBox9.Text;
            sub1 = textBox5.Text;


            Console.WriteLine("程序启动............. ");
            Console.WriteLine("quote_url： "+ quote_url+ "\n trade_url" + trade_url+ "\n username"+ username + "\n password"+ password+ "\n investorpass"+ broker + "\n price_first" + price_first + "\n sub1"+ sub1);

           
            tq = new CtpQuote(quote_url, trade_url, username, password, broker, price_first, sub1);
            tt = new CtpTrade(quote_url, trade_url, username, password, broker, price_first, sub1);


            int i = 1; 
            if (i ==1)
            {
                tq.Run();
                //Console.WriteLine("Press any key to continue . . . ");
                //Console.ReadKey(true);
                tt.Run();
                //Console.WriteLine("Press any key to continue 2. . . ");
                //Console.ReadKey(true);
                //tt.ShowInfo();
                // Console.WriteLine("Press 111111");
                //Console.ReadKey(true);
                timer1.Start();
            }

          

           


        }

        private void closeTQ() {
            tq.Release();
            tt.Release();
        }
        

        private void Trade_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            price = int.Parse(tq.NowPrice);
            this.textBox6.Text = price.ToString();
            this.Refresh();
            
           // Console.WriteLine("................开始...................");

            lt_trade = tt._lt_trade;
            lt_trade_success = tt._lt_trade_success;

            String str = null;
            if (lt_trade != null)
            {
                for (int m = 0; m < lt_trade.Count; m++)
                {
                    str = str + lt_trade[m].InstrumentID + "..." + lt_trade[m].Direction + "..." + lt_trade[m].Offset + "..." + lt_trade[m].LimitPrice+"\n";

                    if (lt_trade[m].Direction == DirectionType.Sell)
                    {
                        if (lt_trade[m].Offset == OffsetType.Open)
                        {
                            tt.buy_btn_Close(lt_trade[m].LimitPrice - 1);
                        }
                        else if (lt_trade[m].Offset == OffsetType.Close)
                        {
                            tt.buy_btn_Open(lt_trade[m].LimitPrice - 1);
                        }
                    }else if (lt_trade[m].Direction == DirectionType.Buy)
                    {
                        if (lt_trade[m].Offset == OffsetType.Open)
                        {
                            tt.sell_btn_Close(lt_trade[m].LimitPrice + 1);
                        }
                        else if (lt_trade[m].Offset == OffsetType.Close)
                        {
                            tt.sell_btn_Open(lt_trade[m].LimitPrice + 1);
                        }
                    }

                    tt._lt_trade.RemoveAt(m);
                   
                }

                Console.WriteLine(str + "\n");
            }
           

           // Console.WriteLine("................结束...................");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            closeTQ();
            timer1.Stop();
            timer2.Stop();
           
            //Console.ReadKey(true);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tt.buy_btn_Open(double.Parse(price.ToString())+1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tt.sell_btn_Open(double.Parse(price.ToString()) - 1);
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
            int sell_nums_ar = int.Parse(sell_nums);//正负挂单数
            int price_first_int = int.Parse(price_first);


            if (flag==1) {
                Console.WriteLine(flag+ ":sell_btn_Open" + (price_first_int + i));
                tt.sell_btn_Open(price_first_int+i);
                i++;

                if (i > sell_nums_ar)
                {
                    flag = 2;
                }
            }
            else if(flag==2)
            {
                Console.WriteLine(flag + ":buy_btn_Open" + (price_first_int - j));
                tt.buy_btn_Open(price_first_int-j);
                j++;
               

            }else
            {
                timer2.Stop();
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {

            price_first = textBox7.Text;
            sell_nums = textBox8.Text;

            int sell_nums_ar = int.Parse(sell_nums);//正负挂单数
            int price_first_int = int.Parse(price_first);



            for (int i = 0; i <sell_nums_ar; i++)
            {
                tt.sell_btn_Open(price_first_int + i+1);  //2000 buy_close 1999  sell_open 2000
              //  Thread.Sleep(20);

            }

            for (int i = 0; i < sell_nums_ar; i++)
            {

                tt.buy_btn_Open(price_first_int - i-1);
              //  Thread.Sleep(20);

            }




        }

        private void button7_Click(object sender, EventArgs e)
        {
            int price_first_int = int.Parse(price_first);
            tt.sell_btn_Open(price_first_int+1);
        }
    }
}


//循环方法
 //while (true)
 //           {
 //               price = tq.NowPrice;
 //               this.textBox6.Text = price;
 //               // Console.WriteLine("现价：" + price);
 //               this.Refresh();

 //           }