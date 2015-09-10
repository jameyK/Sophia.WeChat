/**************************************************************************************************
** 文 件 名： IoBase64Excension.cs
** Copyright (c) 2014 
** 创 建 人： 张京军
** 创建日期： 2014-10-30
** 修 改 人：
** 修改日期：
** 功能描述： Base64数据转换扩展类，用于扩展String和Byte[]的base64互转操作
** 版    本： 1.0.0.0
**************************************************************************************************/
using System;

namespace Sophia.Wechat.Unility
{
    /// <summary>
    /// 用于生成扩展的Base64操作
    /// </summary>
    public static class IOTimespanExcension
    {
        /// <summary>
        /// 将Byte数组数据转换为BASE64编码数据，并生成String
        /// </summary>
        /// <param name="bytes">需要编码的数据源信息</param>
        /// <param name="isSplit">是否换行</param>
        /// <returns></returns>
        public static long ToMillionSeconds(this TimeSpan ts)
        {
            return 0
                + ts.Days * 24 * 60 * 60 * 1000
                + ts.Hours * 60 * 60 * 1000
                + ts.Minutes * 60 * 1000
                + ts.Seconds * 1000
                +ts.Milliseconds;
        }

        /// <summary>
        /// 用于取得时间戳信息，精确到——秒
        /// </summary>
        /// <returns></returns>
        public static long ToTimeStamp(this DateTime time, TimeStampAccuracy accuracy= TimeStampAccuracy.Secound)
        {
            long accuracyNumber = long.Parse((10000000 / Math.Pow(10, (double)accuracy)).ToString());
            return (time.ToUniversalTime().Ticks - 621355968000000000) / accuracyNumber;
        }
 
        /// <summary>
        /// 根据时间戳取得时间点信息
        /// </summary>
        /// <returns></returns>
        public static DateTime ToDatetime(this long time, TimeStampAccuracy accuracy = TimeStampAccuracy.Secound)
        {
            long accuracyNumber = long.Parse((10000000 / Math.Pow(10, (double)accuracy)).ToString());
            long ticks = time * accuracyNumber + 621355968000000000;
            DateTime dt = DateTime.FromFileTime(ticks);
            return dt;
        }
    }

    public enum TimeStampAccuracy:int
    {
        Secound=0,
        MillionSecound=3,
    }
}
