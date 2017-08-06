using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HaiFeng
{

 //   //public string _broker = "8989", _investor = "99901110", _investorpass = "686868", _sub1 = "SR1709", _sub2 = "M1709";
 //   //public string _tcp_ip_quote = "tcp://101.231.127.56:51213";
 //   //public string _tcp_ip_trade = "tcp://101.231.127.56:51205";

    
 //   public class TestQuote
	//{
 //       //public string _broker = "8989", _investor = "99901110", _investorpass = "686868", _sub1 = "SR709", _sub2 = "m1709";
 //       //public string _tcp_ip_quote = "tcp://101.231.127.56:51213";
 //       //public string _tcp_ip_trade = "tcp://101.231.127.56:51205"; //rb1705 cu1705

 //       //public string _broker = "8899", _investor = "80280018", _investorpass = "117373", _sub1 = "SR709", _sub2 = "m1709";
 //       //public string _tcp_ip_quote = "tcp://101.231.127.51:41213";
 //       //public string _tcp_ip_trade = "tcp://101.231.127.51:41205";pub

 //       public String _NowPrice;
 //       public String NowPrice { get { return _NowPrice; } set { _NowPrice = value; } }

 //       public string _broker = "9999", _investor = "008105", _investorpass = "1", _sub1 = "SR709", _sub2 = "m1709";
 //       public string _tcp_ip_quote = "tcp://180.168.146.187:10010";
 //       public string _tcp_ip_trade = "tcp://180.168.146.187:10000";

 //       CTPQuote _q = null;
      
 //       public TestQuote()
	//	{
	//		_q = new CTPQuote();
	//		_q.OnFrontConnected += _q_OnFrontConnected;
	//		_q.OnRspUserLogin += _q_OnRspUserLogin;
	//		_q.OnRspUserLogout += _q_OnRspUserLogout;
	//		_q.OnRtnTick += _q_OnRtnTick;
 //           _q.OnRtnError += _q_OnRtnError;

 //           //.........new
 //           //  _q.OnRtnQuote += _q_OnRtnQuote;
 //           // _q.OnRspSubMarketData += _q_OnRspSubMarketData;

 //           _q.OnRtnForQuoteRsp += _q_OnRtnForQuoteRsp;
            
 //       }

	//	public void Release()
	//	{
	//		_q.ReqUserLogout();
	//	}

	//	public void Run()
	//	{
	//		_q.ReqConnect(_tcp_ip_quote);
	//	}

	//	void Log(string pMsg)
	//	{
	//		Console.WriteLine(DateTime.Now.TimeOfDay + "\t" + pMsg);
	//	}

	//	private void _q_OnFrontConnected(object sender, EventArgs e)
	//	{
 //           Log($"connecting user:{_investor} pass:{_investorpass} broker:{_broker}");
	//		_q.ReqUserLogin(_investor, _investorpass, _broker);
	//	}

	//	private void _q_OnRspUserLogin(object sender, IntEventArgs e)
	//	{
	//		if (e.Value == 0)
	//		{
	//			Log($"登录成功:{_investor}");
               
 //               _q.ReqSubscribeMarketData(_sub1);
 //               //"rb1705", "cu1705"  "SR709", "m1709", "sr1709"

 //               Log("等待行情数据");
 //              // _q.ReqSubscribeForQuoteRsp("SR1709", "M1709");

 //               // _q.ReqDepthMarketData(_sub1);
 //               // String data = _q.ReqSubscribeMarketData(_sub1).ToString();
 //               //Log($"Start:::::{data}");

 //           }
	//		else
	//		{
	//			//_q.OnFrontConnected -= _q_OnFrontConnected;    //解决登录错误后不断重连导致再不断登录的错误
	//			Log($"登录错误：{e.Value}");
	//			_q.ReqUserLogout();
	//		}
	//	}



 //       private void _q_OnRspRtnDepthMarketData(object sender, IntEventArgs e)
 //       {
 //           Log($"data::::::{e.Value}");
 //       }
 //       private void _q_OnRtnForQuoteRsp(object sender, IntEventArgs e)
 //       {
 //           Log($"data::::::{e.Value}");
 //       }


 //       private void _q_OnRtnTick(object sender, TickEventArgs e)
 //       {
 //           Log($"Tick::::::: {e.Tick.InstrumentID}\t{e.Tick.LastPrice}");
 //           _NowPrice = e.Tick.LastPrice.ToString();
 //       }
 //       //private void _q_OnRtnQuote(object sender, QuotedataEventArgs e)
 //       //{
 //       //    Log($"Tick::::::: {e.Value.TradingDay}\t{e.Value.InstrumentID}");
 //       //}

        
 //       private void _q_OnRspUserLogout(object sender, IntEventArgs e)
	//	{
	//		Log($"Quote logout: {e.Value}");
	//	}

	//	private void _q_OnRtnError(object sender, ErrorEventArgs e)
	//	{
	//		Log(e.ErrorMsg);
	//	}
	//}

	//class TestTrade
	//{
	//	CTPTrade _t = null;
 //       //public string _broker = "8899", _investor = "80280018", _investorpass = "117373", _sub1 = "SR709", _sub2 = "m1709";
 //       //public string _tcp_ip_quote = "tcp://101.231.127.51:41213";
 //       //public string _tcp_ip_trade = "tcp://101.231.127.51:41205";


 //       //public string _broker = "8989", _investor = "99901110", _investorpass = "686868", _sub1 = "SR709", _sub2 = "m1709";
 //       //public string _tcp_ip_quote = "tcp://101.231.127.56:51213";
 //       //public string _tcp_ip_trade = "tcp://101.231.127.56:51205";


 //       public string _broker = "9999", _investor = "008105", _investorpass = "1", _sub1 = "SR709", _sub2 = "m1709";
 //       public string _tcp_ip_quote = "tcp://180.168.146.187:10010";
 //       public string _tcp_ip_trade = "tcp://180.168.146.187:10000";


 //       public TestTrade()
	//	{
	//		_t = new CTPTrade();
	//	}

	//	public void Release()
	//	{
	//		_t.ReqUserLogout();
	//	}

	//	void Log(string pMsg)
	//	{
	//		Console.WriteLine(DateTime.Now.TimeOfDay + "\t" + pMsg);
	//	}

	//	public void Run()
	//	{
	//		_t.OnFrontConnected += _t_OnFrontConnected;
	//		_t.OnRspUserLogout += _t_OnRspUserLogout;
	//		_t.OnRspUserLogin += _t_OnRspUserLogin;
	//		_t.OnRtnOrder += _t_OnRtnOrder;
	//		_t.OnRtnTrade += _t_OnRtnTrade;
	//		_t.OnRtnCancel += _t_OnRtnCancel;
	//		_t.ReqConnect(_tcp_ip_trade);
	//	}

	//	private void _t_OnRtnCancel(object sender, OrderArgs e)
	//	{
	//		Log($"{e.Value.StatusMsg}\t{e.Value.InstrumentID}\t{e.Value.Direction}\t{e.Value.Offset}\t{e.Value.LimitPrice}\t{e.Value.Volume}");
	//	}

	//	private void _t_OnRtnTrade(object sender, TradeArgs e)
	//	{
	//		Log($"{e.Value.InstrumentID}\t{e.Value.Direction}\t{e.Value.Offset}\t{e.Value.Price}\t{e.Value.Volume}");
	//	}

	//	private void _t_OnRtnOrder(object sender, OrderArgs e)
	//	{
	//		Log($"{e.Value.InstrumentID}\t{e.Value.Direction}\t{e.Value.Offset}\t{e.Value.LimitPrice}\t{e.Value.Volume}");

	//		if (e.Value.IsLocal)
	//			_t.ReqOrderAction(e.Value.OrderID);
	//	}

	//	private void _t_OnFrontConnected(object sender, EventArgs e)
	//	{
	//		_t.ReqUserLogin(_investor, _investorpass, _broker);
	//	}

	//	public void ShowInfo()
	//	{
	//		Log("Show Info:"+_t.TradingAccount.ToString());
 //           Log("End Show Info!");

 //           foreach (var posi in _t.DicPositionField.Values)
	//			Log("Show Info data:"+posi.ToString());
	//	}

	//	private void _t_OnRspUserLogin(object sender, IntEventArgs e)
	//	{
	//		if (e.Value == 0)
	//		{
 //               Log("登录成功");

 //               Log("显示结算："+_t.SettleInfo);//显示结算信息

 //               _t.ReqOrderInsert(_sub1, DirectionType.Sell, OffsetType.Open, 3200, 1, 1000);
 //              // _t.ReqForQuoteInsert( ref CThostFtdcInputForQuoteField ss);


	//		}
	//		else
	//		{
	//			Log($"登录错误：{e.Value}");
	//		}
	//	}

	//	private void OnRtnInstrumentStatus(ref CThostFtdcInstrumentStatusField pInstrumentStatus)
	//	{
	//		Log($"{pInstrumentStatus.InstrumentID}:{pInstrumentStatus.InstrumentStatus}");
	//	}

	//	private void _t_OnRspUserLogout(object sender, IntEventArgs e)
	//	{
	//		Log("t: logout:" + e.Value);
	//	}
	//}

}
