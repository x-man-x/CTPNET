using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiFeng
{
    public class PlatformInfo : BindableBase
    {

       // private string Tcp_ip_quote = null;
       // private string Tcp_ip_trade = null;
        //private string Sub = null;

        //private string buy_nums = null;
       // private string first_price = null;
        //private string sell_nums = null;

        //private string investor = null;
        //private string investorpass = null;
        //private string broker = null;

       
        [DisplayName("Tcp_ip_quote")]
        public string Tcp_ip_quote { get { return _Tcp_ip_quote; } set { if (value != null) SetProperty(ref _Tcp_ip_quote, value); } }
        private string _Tcp_ip_quote = string.Empty;


        [DisplayName("Tcp_ip_trade")]
        public string Tcp_ip_trade { get { return _Tcp_ip_trade; } set { if (value != null) SetProperty(ref _Tcp_ip_trade, value); } }
        private string _Tcp_ip_trade = string.Empty;



        [DisplayName("Sub")]
        public string Sub { get { return _Sub; } set { if (value != null) SetProperty(ref _Sub, value); } }
        private string _Sub = string.Empty;



        [DisplayName("Buy_nums")]
        public string Buy_nums { get { return _Buy_nums; } set { if (value != null) SetProperty(ref _Buy_nums, value); } }
        private string _Buy_nums = string.Empty;


        [DisplayName("First_price")]
        public string First_price { get { return _First_pricee; } set { if (value != null) SetProperty(ref _First_pricee, value); } }
        private string _First_pricee = string.Empty;


        [DisplayName("Sell_nums")]
        public string Sell_nums { get { return _Sell_numse; } set { if (value != null) SetProperty(ref _Sell_numse, value); } }
        private string _Sell_numse = string.Empty;


        [DisplayName("Investor")]
        public string Investor { get { return _Investor; } set { if (value != null) SetProperty(ref _Investor, value); } }
        private string _Investor = string.Empty;


        [DisplayName("Investorpass")]
        public string Investorpass { get { return _Investorpass; } set { if (value != null) SetProperty(ref _Investorpass, value); } }
        private string _Investorpass = string.Empty;


        [DisplayName("Broker")]
        public string Broker { get { return _Broker; } set { if (value != null) SetProperty(ref _Broker, value); } }
        private string _Broker = string.Empty;

    }
}
