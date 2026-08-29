// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.DependencyModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentGateway;

namespace PaymentGatewayUnitTests
{
    [TestClass]
    public class PaymentGatewayUnitTests
    {
        [TestMethod]
        public void TestGPaySuccessfulPayment()
        {
            IPaymentGateway paymentGateway = new GPayAdapter();
            CheckoutService checkout = new CheckoutService(paymentGateway);
            PaymentResult result = checkout.Checkout(500m);
            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual("GPAY123", result.Reference);
        }

        [TestMethod]
        public void TestGPayNegativePayment()
        {
            IPaymentGateway paymentGateway = new GPayAdapter();
            CheckoutService checkout = new CheckoutService(paymentGateway);
            PaymentResult result = checkout.Checkout(-500m);
            Assert.IsFalse(result.Succeeded);
            Assert.AreEqual("", result.Reference);
        }

        [TestMethod]
        public void TestGPayZeroAmount()
        {
            IPaymentGateway paymentGateway = new GPayAdapter();
            CheckoutService checkout = new CheckoutService(paymentGateway);
            PaymentResult result = checkout.Checkout(0m);
            Assert.IsFalse(result.Succeeded);
            Assert.AreEqual("", result.Reference);
        }

        [TestMethod]
        public void TestPayTmSuccessfulPayment()
        {
            IPaymentGateway paymentGateway = new PayTmAdapter();
            CheckoutService checkout = new CheckoutService(paymentGateway);
            PaymentResult result = checkout.Checkout(500m);
            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual("PAYTM123", result.Reference);
        }

        [TestMethod]
        public void TestPayTmNegativePayment()
        {
            IPaymentGateway paymentGateway = new PayTmAdapter();
            CheckoutService checkout = new CheckoutService(paymentGateway);
            PaymentResult result = checkout.Checkout(-300m);
            Assert.IsFalse(result.Succeeded);
            Assert.AreEqual("", result.Reference);
        }

        [TestMethod]
        public void TestPayTmZeroAmount()
        {
            IPaymentGateway paymentGateway = new PayTmAdapter();
            CheckoutService checkout = new CheckoutService(paymentGateway);
            PaymentResult result = checkout.Checkout(0m);
            Assert.IsFalse(result.Succeeded);
            Assert.AreEqual("", result.Reference);
        }

        [TestMethod]
        public void TestCheckoutWithDifferentAdapter()
        {
            IPaymentGateway gpay = new GPayAdapter();
            CheckoutService gpayCheckout = new CheckoutService(gpay);
            PaymentResult gpayResult = gpayCheckout.Checkout(300m);


            IPaymentGateway paytm = new PayTmAdapter();
            CheckoutService paytmCheckout = new CheckoutService(paytm);
            PaymentResult paytmResult = paytmCheckout.Checkout(300m);

            Assert.IsTrue(gpayResult.Succeeded);
            Assert.IsTrue(paytmResult.Succeeded);

            Assert.AreEqual("GPAY123", gpayResult.Reference);
            Assert.AreEqual("PAYTM123", paytmResult.Reference);
        }
    }
}
