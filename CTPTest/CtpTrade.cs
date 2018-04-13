using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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

        private List<OrderField> _lt_submit_order = new List<OrderField>();
        private List<OrderField> _lt_submit_order_success = new List<OrderField>();
        private List<TradeField> _lt_trade_success = new List<TradeField>();
        private Dictionary<string, OrderField> idToOrderMap = new Dictionary<string, OrderField>();
        private ReaderWriterLock submittedOrderReadWriteLock = new ReaderWriterLock();
        private ReaderWriterLock filledOrderReadWriteLock = new ReaderWriterLock();
        private ReaderWriterLock executionOrderReadWriteLock = new ReaderWriterLock();
        private ReaderWriterLock orderMapReadWriteLock = new ReaderWriterLock();


        public IList<OrderField> getOpenOrders()
        {
            this.orderMapReadWriteLock.AcquireReaderLock(1000);
            IList<OrderField> returnValue;
            try
            {
                returnValue = this.idToOrderMap.Values
                    .Where(orderField => orderField.Status == OrderStatus.Normal)
               .OrderBy(orderField => orderField.InsertTime)
               .ToList();
            }
            finally
            {
                this.orderMapReadWriteLock.ReleaseReaderLock();
            }
            return returnValue;
        }


        public IList<OrderField> getFilledOrders2()
        {
            this.orderMapReadWriteLock.AcquireReaderLock(1000);
            IList<OrderField> returnValue;
            try
            {
                returnValue = this.idToOrderMap.Values
                    .Where(orderField => orderField.Status == OrderStatus.Filled)
               .OrderBy(orderField => orderField.InsertTime)
               .ToList();
            }
            finally
            {
                this.orderMapReadWriteLock.ReleaseReaderLock();
            }
            return returnValue;
        }
        public IList<OrderField> getAllOrders()
        {
            this.orderMapReadWriteLock.AcquireReaderLock(1000);
            IList<OrderField> returnValue;
            try
            {
                returnValue = this.idToOrderMap.Values.ToList();
            }
            finally
            {
                this.orderMapReadWriteLock.ReleaseReaderLock();
            }
            return returnValue;
        }

        public void updateAllOrders(OrderField orderField)
        {
            this.orderMapReadWriteLock.AcquireWriterLock(1000);
            try
            {
                this.idToOrderMap[orderField.OrderID] = orderField;
            }
            finally
            {
                this.orderMapReadWriteLock.ReleaseWriterLock();
            }
           
        }

        public IList<OrderField> getSubbmittedOrders()
        {
            this.submittedOrderReadWriteLock.AcquireReaderLock(1000);
            IList<OrderField> returnValue;
            try {
                returnValue = new List<OrderField>(this._lt_submit_order);
            }
            finally
            {
                //减少锁计数,释放锁  
                this.submittedOrderReadWriteLock.ReleaseReaderLock();
            }
            return returnValue;
        }

        public void removeSubmittedOrder(string orderId)
        {
            this.submittedOrderReadWriteLock.AcquireWriterLock(1000);
            try
            {
                this._lt_submit_order.RemoveAll(order=>order.OrderID==orderId);
            }
            finally
            {
                //减少锁计数,释放锁  
                this.submittedOrderReadWriteLock.ReleaseWriterLock();
            }
        }

        public void AddSubmittedOrder(OrderField order)
        {
            this.submittedOrderReadWriteLock.AcquireWriterLock(1000);
            try
            {
                this._lt_submit_order.Add(order);
            }
            finally
            {
                //减少锁计数,释放锁  
                this.submittedOrderReadWriteLock.ReleaseWriterLock();
            }
        }

        public IList<OrderField> getFilledOrders()
        {
            this.filledOrderReadWriteLock.AcquireReaderLock(1000);
            IList<OrderField> returnValue;
            try
            {
                returnValue = new List<OrderField>(this._lt_submit_order_success);
            }
            finally
            {
                //减少锁计数,释放锁  
                this.filledOrderReadWriteLock.ReleaseReaderLock();
            }
            return returnValue;
        }
        public void removeFilledOrder(string orderId)
        {
            this.filledOrderReadWriteLock.AcquireWriterLock(1000);
            try
            {
                this._lt_submit_order_success.RemoveAll(order => order.OrderID == orderId);
            }
            finally
            {
                //减少锁计数,释放锁  
                this.filledOrderReadWriteLock.ReleaseWriterLock();
            }
        }
        public void addFilledOrder(OrderField order)
        {
            this.filledOrderReadWriteLock.AcquireWriterLock(1000);
            try
            {
                this._lt_submit_order_success.Add(order);
            }
            finally
            {
                //减少锁计数,释放锁  
                this.filledOrderReadWriteLock.ReleaseWriterLock();
            }
        }


        public IList<TradeField> getExecutioins()
        {
            this.executionOrderReadWriteLock.AcquireReaderLock(1000);
            IList<TradeField> returnValue;
            try
            {
                returnValue = new List<TradeField>(this._lt_trade_success);
            }
            finally
            {
                //减少锁计数,释放锁  
                this.executionOrderReadWriteLock.ReleaseReaderLock();
            }
            return returnValue;
        }


        public void addExecutioins(TradeField execution)
        {
            this.executionOrderReadWriteLock.AcquireWriterLock(1000);
            try
            {
                this._lt_trade_success.Add(execution);
            }
            finally
            {
                //减少锁计数,释放锁  
                this.executionOrderReadWriteLock.ReleaseWriterLock();
            }
        }


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
            Log($"OnRtnTrade 交易成交:{e.Value.InstrumentID}\t{e.Value.Direction}\t{e.Value.Offset}\t{e.Value.Price}\t{e.Value.Volume}");
            this.addExecutioins((TradeField)e.Value);
        }

        private void _t_OnRtnOrder(object sender, OrderArgs e)
        {
            Log($"OnRtnOrder 挂单回报：{e.Value.InstrumentID}\t{e.Value.Direction}\t{e.Value.Offset}\t{e.Value.LimitPrice}\t{e.Value.Volume}\t{e.Value.OrderID}\t{e.Value.SysID}\t{e.Value.StatusMsg}");
            OrderField orderField = e.Value;
            this.updateAllOrders(orderField);
            if (e.Value.Status == OrderStatus.Filled)
            {
                this.placeReverseOrder(orderField);
            }
           
            
            //if (e.Value.IsLocal)
            //    _t.ReqOrderAction(e.Value.OrderID);
        }

        private void placeReverseOrder(OrderField filledOrder)
        {
            string tempOrderId = filledOrder.OrderID;
            String str ="定单成交："+ filledOrder.InstrumentID + "..." + filledOrder.Direction + "..." + filledOrder.Offset + "..." + filledOrder.LimitPrice + "\n";

            if (filledOrder.Direction == DirectionType.Sell)
            {
                if (filledOrder.Offset == OffsetType.Open)
                {
                    this.buy_btn_Close(filledOrder.LimitPrice - 1);
                }
                else if (filledOrder.Offset == OffsetType.Close)
                {
                    this.buy_btn_Open(filledOrder.LimitPrice - 1);
                }
            }
            else if (filledOrder.Direction == DirectionType.Buy)
            {
                if (filledOrder.Offset == OffsetType.Open)
                {
                    this.sell_btn_Close(filledOrder.LimitPrice + 1);
                }
                else if (filledOrder.Offset == OffsetType.Close)
                {
                    this.sell_btn_Open(filledOrder.LimitPrice + 1);
                }
            }
            Log(str);
            //Console.WriteLine(str + "\n");

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

        public void getList() {
            
        }
        
    }
}