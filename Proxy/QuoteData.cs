using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HaiFeng
{
    public class QuoteData : BindableBase
    {
        
            /// <summary>
            /// 交易日
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
            public string TradingDay;
            /// <summary>
            /// 合约代码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
            public string InstrumentID;
            /// <summary>
            /// 询价编号
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
            public string ForQuoteSysID;
            /// <summary>
            /// 询价时间
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
            public string ForQuoteTime;
            /// <summary>
            /// 业务日期
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
            public string ActionDay;
            /// <summary>
            /// 交易所代码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
            public string ExchangeID;
      


    }
}