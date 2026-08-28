// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using System;
using System.Transactions;
namespace PaymentGateway
{
    public class PayTm
    {
        public string SendMoney(decimal amt)
        {
            if (amt < 0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }
            Console.WriteLine($"PayTm processing {amt}");

            return "PAYTM123";
        }
    }
};
