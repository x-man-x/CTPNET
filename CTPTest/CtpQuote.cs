using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiFeng
{
    public class CtpQuote
    {

        public string _broker = "9999", _investor = "099364", _investorpass = "868686", _sub1 = "m1801", _sub2 = "m1709";
        public string _tcp_ip_quote = "tcp://180.168.146.187:10010000";
        public string _tcp_ip_trade = "tcp://180.168.146.187:1000000000";
        
        //public string _tcp_ip_quote = "tcp://218.202.237.33:10012";
        //public string _tcp_ip_trade = "tcp://218.202.237.33:10002";


        //public string _broker = "8899", _investor = "99901110", _investorpass = "686868", _sub1 = "m1801", _sub2 = "m1709";
        //public string _tcp_ip_quote = "tcp://101.231.127.56:51213";
        //public string _tcp_ip_trade = "tcp://101.231.127.56:51205";

        //public string _broker = "8899", _investor = "80280018", _investorpass = "117373", _sub1 = "SR801", _sub2 = "m1709";
        //public string _tcp_ip_quote = "tcp://101.231.127.51:41213";
        //public string _tcp_ip_trade = "tcp://101.231.127.51:41205";

        //public string _broker = "9999", _investor = "008105", _investorpass = "1", _sub1 = "SR801";
        //public string _tcp_ip_quote = "tcp://180.168.146.187:10010";
        //public string _tcp_ip_trade = "tcp://180.168.146.187:10000";

        public String _NowPrice;
        public String NowPrice { get { return _NowPrice; } set { _NowPrice = value; } }

        

        CTPQuote _q = null;

        public CtpQuote(String tcp_ip_quote, String tcp_ip_trade, String investor, String investorpass, String broker, String price_first, String sub1)
        {

            _broker = broker;
            _investor = investor;
            _investorpass = investorpass;
            _sub1 = sub1;
            _tcp_ip_quote = tcp_ip_quote;
            _tcp_ip_trade = tcp_ip_trade;

            _q = new CTPQuote();
            _q.OnFrontConnected += _q_OnFrontConnected;
            _q.OnRspUserLogin += _q_OnRspUserLogin;
            _q.OnRspUserLogout += _q_OnRspUserLogout;
            _q.OnRtnTick += _q_OnRtnTick;
            _q.OnRtnError += _q_OnRtnError;

            //.........new
            //  _q.OnRtnQuote += _q_OnRtnQuote;
            // _q.OnRspSubMarketData += _q_OnRspSubMarketData;

            _q.OnRtnForQuoteRsp += _q_OnRtnForQuoteRsp;

        }

        public void Release()
        {
            _q.ReqUserLogout();
        }

        public void Run()
        {
            _q.ReqConnect(_tcp_ip_quote);
        }

        void Log(string pMsg)
        {
            Console.WriteLine(DateTime.Now.TimeOfDay + "\t" + pMsg);
        }

        private void _q_OnFrontConnected(object sender, EventArgs e)
        {
            Log($"connecting user:{_investor} pass:{_investorpass} broker:{_broker}");
            _q.ReqUserLogin(_investor, _investorpass, _broker);
        }

        private void _q_OnRspUserLogin(object sender, IntEventArgs e)
        {
            if (e.Value == 0)
            {
                Log($"登录成功:{_investor}");

                _q.ReqSubscribeMarketData(_sub1);
                //"rb1705", "cu1705"  "SR709", "m1709", "sr1709"

                Log("等待行情数据");
                // _q.ReqSubscribeForQuoteRsp("SR1709", "M1709");

                // _q.ReqDepthMarketData(_sub1);
                // String data = _q.ReqSubscribeMarketData(_sub1).ToString();
                //Log($"Start:::::{data}");

            }
            else
            {
                //_q.OnFrontConnected -= _q_OnFrontConnected;    //解决登录错误后不断重连导致再不断登录的错误
                Log($"登录错误：{e.Value}");
                _q.ReqUserLogout();
            }
        }



        private void _q_OnRspRtnDepthMarketData(object sender, IntEventArgs e)
        {
            Log($"data::::::{e.Value}");
        }
        private void _q_OnRtnForQuoteRsp(object sender, IntEventArgs e)
        {
            Log($"data::::::{e.Value}");
        }


        private void _q_OnRtnTick(object sender, TickEventArgs e)
        {
            Log($"Tick::::::: {e.Tick.InstrumentID}\t{e.Tick.LastPrice}");
            _NowPrice = e.Tick.LastPrice.ToString();
        }
        //private void _q_OnRtnQuote(object sender, QuotedataEventArgs e)
        //{
        //    Log($"Tick::::::: {e.Value.TradingDay}\t{e.Value.InstrumentID}");
        //}


        private void _q_OnRspUserLogout(object sender, IntEventArgs e)
        {
            Log($"Quote logout: {e.Value}");
        }

        private void _q_OnRtnError(object sender, ErrorEventArgs e)
        {
            Log(e.ErrorMsg);
        }
    }

}
