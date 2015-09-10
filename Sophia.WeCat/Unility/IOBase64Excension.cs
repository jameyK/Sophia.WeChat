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
using System.Text;
 
namespace Tuna.Utility.Format
{
    /// <summary>
    /// 用于生成扩展的Base64操作
    /// </summary>
    public static class IoToHexExcension
    {
        /// <summary>
        /// 将Byte数组数据转换为BASE64编码数据，并生成String
        /// </summary>
        /// <param name="bytes">需要编码的数据源信息</param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes)
        {
            if (bytes == null) return default(string);
            StringBuilder ret = new StringBuilder();
            foreach (byte b in bytes)
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        /// <summary>
        /// 将BASE64编码数据进行解析为Byte数组
        /// </summary>
        /// <param name="source">需要解析的数据源信息</param>
        /// <param name="isCompress">是否对数据进行压缩。默认为true</param>
        /// <returns></returns>
        public static byte[] FromHexString(this string source, bool isCompress = true)
        {
            if (source == null) return default(byte[]);
            try
            {
                if (!string.IsNullOrEmpty(source))
                {
                    byte[] inputByteArray = new byte[source.Length / 2];
                    for (int x = 0; x < source.Length / 2; x++)
                    {
                        int i = (Convert.ToInt32(source.Substring(x * 2, 2), 16));
                        inputByteArray[x] = (byte)i;
                    }
                    return inputByteArray;
                }
                else
                    return null;
            }
            catch { return null; }
        }
    }
 
}
