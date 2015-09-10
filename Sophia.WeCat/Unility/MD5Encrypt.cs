/**************************************************************************************************
** 文 件 名： MD5Encrypt.cs
** Copyright (c) 2014 
** 创 建 人： 张京军
** 创建日期： 2014-10-29
** 修 改 人：
** 修改日期：
** 功能描述： 标准MD5加密方式，
** 版    本： 1.0.0.0
**************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Sophia.Wechat.Unility
{
    /// <summary>
    /// 自己实现MD5数据加密
    /// </summary>
    public class MD5Encrypt
    {
        /// <summary>
        /// MD5加密 返回纯字节
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public static byte[] MD5Bytes(string sourceString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] keyBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(sourceString));
            md5.Clear();
            return keyBytes;
        }
    }
}
