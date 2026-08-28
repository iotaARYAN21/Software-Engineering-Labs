// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway
{
    public class GPay
    {
        public string MakePayment(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }
            Console.WriteLine($"GPay processing {amount}");
            return "GPAY123";
        }
    }
}
