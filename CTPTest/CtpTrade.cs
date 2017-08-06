using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HaiFeng
{
    class CtpTrade
    {
        CTPTrade _t = null;


        public string _broker = "9999", _investor = "099364", _investorpass = "868686", _sub1 = "m1801";
        public string _tcp_ip_quote = "tcp://180.168.146.187:10010";
        public string _tcp_ip_trade = "tcp://180.168.146.187:10000";

        public string _tcp_trade_direction = null;
        public string _tcp_trade_offset = null;
        public string _tcp_trade_price = null;

        public List<OrderField> _lt_trade = new List<OrderField>();
        public List<TradeField> _lt_trade_success = new List<TradeField>();



        //public string _broker = "8899", _investor = "99901110", _investorpass = "686868", _sub1 = "m1801", _sub2 = "m1709";
        //public string _tcp_ip_quote = "tcp://101.231.127.56:51213";
        //public string _tcp_ip_trade = "tcp://101.231.127.56:51205";



        //public string _broker = "8899", _investor = "80280018", _investorpass = "117373", _sub1 = "SR801", _sub2 = "m1709";
        //public string _tcp_ip_quote = "tcp://101.231.127.51:41213";
        //public string _tcp_ip_trade = "tcp://101.231.127.51:41205";


        //public string _broker = "9999", _investor = "008105", _investorpass = "1", _sub1 = "SR801";
        //public string _tcp_ip_quote = "tcp://180.168.146.187:10010";
        //public string _tcp_ip_trade = "tcp://180.168.146.187:10000";


        public CtpTrade(String tcp_ip_quote, String tcp_ip_trade, String investor, String investorpass, String broker, String price_first, String sub1)
        {
            _broker = broker;
            _investor = investor;
            _investorpass = investorpass;
            _sub1 = sub1;
            _tcp_ip_quote = tcp_ip_quote;
            _tcp_ip_trade = tcp_ip_trade;
            //_lt_trade = lt_trade;
            //_lt_trade_success = lt_trade_success;
            _t = new CTPTrade();
            
        }

        public void Release()
        {
            _t.ReqUserLogout();
        }

        void Log(string pMsg)
        {
            Console.WriteLine(DateTime.Now.TimeOfDay + "\t" + pMsg);
        }

        public void Run()
        {
            _t.OnFrontConnected += _t_OnFrontConnected;
            _t.OnRspUserLogout += _t_OnRspUserLogout;
            _t.OnRspUserLogin += _t_OnRspUserLogin;
            _t.OnRtnOrder += _t_OnRtnOrder;
            _t.OnRtnTrade += _t_OnRtnTrade;
            _t.OnRtnCancel += _t_OnRtnCancel;
            _t.ReqConnect(_tcp_ip_trade);
        }

        private void _t_OnRtnCancel(object sender, OrderArgs e)
        {
            Log($"_t_OnRtnCancel{e.Value.StatusMsg}\t{e.Value.InstrumentID}\t{e.Value.Direction}\t{e.Value.Offset}\t{e.Value.LimitPrice}\t{e.Value.Volume}");
        }

        private void _t_OnRtnTrade(object sender, TradeArgs e)
        {
           // 11:03:27.6670057        _t_OnRtnOrderm1801 Buy     Open    2889    1       1089408166 | 1 | 000030001000           10043369    全部成交
           // 11:03:27.6689683        _t_OnRtnTrade: m1801 Buy     Open    2879    1
            Log($"_t_OnRtnTrade 成交:{e.Value.InstrumentID}\t{e.Value.Direction}\t{e.Value.Offset}\t{e.Value.Price}\t{e.Value.Volume}");
            _lt_trade_success.Add((TradeField)e.Value);
        }

        private void _t_OnRtnOrder(object sender, OrderArgs e)
        {
            Log($"_t_OnRtnOrder 挂单：{e.Value.InstrumentID}\t{e.Value.Direction}\t{e.Value.Offset}\t{e.Value.LimitPrice}\t{e.Value.Volume}\t{e.Value.OrderID}\t{e.Value.SysID}\t{e.Value.StatusMsg}");
            Log(e.Value.StatusMsg);
            if (e.Value.StatusMsg == "全部成交") {
                _lt_trade.Add((OrderField)e.Value);
            }
            
            
            //if (e.Value.IsLocal)
            //    _t.ReqOrderAction(e.Value.OrderID);
        }

        private void _t_OnFrontConnected(object sender, EventArgs e)
        {
            _t.ReqUserLogin(_investor, _investorpass, _broker);
        }

        public void ShowInfo()
        {
            Log("Show Info:" + _t.TradingAccount.ToString());
            Log("End Show Info!");

            foreach (var posi in _t.DicPositionField.Values)
                Log("Show Info data:" + posi.ToString());
        }

        private void _t_OnRspUserLogin(object sender, IntEventArgs e)
        {
            if (e.Value == 0)
            {
                Log("登录成功");

                Log("显示结算：" + _t.SettleInfo);//显示结算信息

                //_t.ReqOrderInsert(_sub1, DirectionType.Sell, OffsetType.Open, 3200, 1, 1000);
                //_t.ReqForQuoteInsert( ref CThostFtdcInputForQuoteField ss);


            }
            else
            {
                Log($"登录错误：{e.Value}");
            }
        }
       
        private void OnRtnInstrumentStatus(ref CThostFtdcInstrumentStatusField pInstrumentStatus)
        {
            Log($"{pInstrumentStatus.InstrumentID}:{pInstrumentStatus.InstrumentStatus}");
        }

        private void _t_OnRspUserLogout(object sender, IntEventArgs e)
        {
            Log("t: logout:" + e.Value);
        }


        //买开
        public void buy_btn_Open(double price) {
            _t.ReqOrderInsert(_sub1, DirectionType.Buy, OffsetType.Open, price, 1, 1000);
        }
        //买平
        public void buy_btn_Close(double price)
        {
            _t.ReqOrderInsert(_sub1, DirectionType.Buy, OffsetType.Close, price, 1, 1000);
        }



        //卖开
        public void sell_btn_Open(double price)
        {
            _t.ReqOrderInsert(_sub1, DirectionType.Sell, OffsetType.Open, price, 1, 1000);
        }
        //卖平
        public void sell_btn_Close(double price)
        {
            _t.ReqOrderInsert(_sub1, DirectionType.Sell, OffsetType.Close, price, 1, 1000);
            
        }
        
    }
}