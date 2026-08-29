// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway
{
    public sealed class PayTmAdapter : IPaymentGateway
    {
        private PayTm _paytm;
        public PayTmAdapter()
        {
            _paytm = new PayTm();
        }
        public PaymentResult Pay(decimal amt)
        {
            try
            {
                string reference = _paytm.SendMoney(amt);
                return new PaymentResult(true, reference);
            }
            catch
            (ArgumentException)
            {
                return new PaymentResult(false, "");
            }
        }
    }
}
