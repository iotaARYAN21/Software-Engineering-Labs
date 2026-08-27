// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway
{
    internal class GPayAdapter : PaymentGatewayInterface
    {
        GPay _gpay;
        GPayAdapter()
        {
            _gpay = new GPay();
        }
        public void Pay(int id, double amount)
        {
            _gpay.MakePayment(id, amount);
        }
    }
}
