﻿using ESD6NL.DriverSystem.BLL.Implementations;
using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace ESD6.NL.DriverSystem.UnitTests
{
    [TestClass]
    class InvoiceServiceTests
    {
        private InvoiceService _invoiceService;

        public InvoiceServiceTests()
        {
            var mock = new Mock<IInvoiceRepository>();
            mock.Setup(garage => garage.GetSpecificInvoice(1)).Returns(new Invoice()
            {
                invoiceID = 1,
                invoiceNumber = 1,
                paymentStatus = PaymentStatus.Open,
                period = new System.DateTime(),
                totalKm = 1,
                totalAmount = 1,
                filePath = "fakefilepath.file"
            });
            mock.Setup(garage => garage.Add(It.IsAny<Invoice>())).Returns((Invoice i) => i);
            _invoiceService = new InvoiceService(mock.Object);
        }

        [TestMethod]
        public void getSpecificInvoice_ExcistingInvoice_InvoiceDetail()
        {
            Assert.AreEqual(1, _invoiceService.GetInvoice(1).invoiceID);
            Assert.AreEqual(1, _invoiceService.GetInvoice(1).invoiceNumber);
            Assert.AreEqual(PaymentStatus.Open, _invoiceService.GetInvoice(1).paymentStatus);
            Assert.AreEqual(1, _invoiceService.GetInvoice(1).totalKm);
            Assert.AreEqual(1, _invoiceService.GetInvoice(1).totalAmount);
            Assert.AreEqual("fakefilepath.file", _invoiceService.GetInvoice(1).filePath);
        }

        [TestMethod]
        public void getSoecificInvoice_FakeInvoice_ErrorMessage()
        {
            Assert.AreNotEqual(2, _invoiceService.GetInvoice(2).invoiceNumber);
        }
    }
}
