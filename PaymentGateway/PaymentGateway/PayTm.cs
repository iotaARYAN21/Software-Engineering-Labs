// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using System;
namespace PaymentGateway
{
    public class PayTm : PaymentGatewayInterface
    {
        public void Pay(int id, double amt)
        {
            Console.WriteLine($"Sent {amt} from {id}\n");
        }
    }
};
