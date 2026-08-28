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
    public class Program
    {
        public static void Main()
        {
            GPay gpay = new GPay();

            IPaymentGateway gpayAdapter =
                new GPayAdapter();

            CheckoutService checkout =
                new CheckoutService(gpayAdapter);

            PaymentResult result =
                checkout.Checkout(500.0);

            Console.WriteLine(
                $"Success: {result.Succeeded}, " +
                $"Reference: {result.Reference}"
            );
        }
    }
}
