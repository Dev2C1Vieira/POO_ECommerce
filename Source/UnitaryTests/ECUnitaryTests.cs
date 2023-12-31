/*
 * <copyright file = "ECUnitaryTests.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/31/2023 12:36:11 AM </date>
 * <description></description>
 * 
 * */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// External
using RevenueEngine;
using RevenueEngines;
using ProductCatalog;
using ProductCatalogs;
using StaffClientSystem;
using StaffClientSystems;

namespace UnitaryTests
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/11/2023 10:38:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>

    [TestClass]
    public class ECUnitaryTests
    {
        /// <summary>
        /// Some unit tests performed.
        /// </summary>

        [TestMethod]
        public void InsertProduct()
        {
            Product product1 = new Product(1, "Product1", "Testar1", 123.45, new DateTime(2021, 09, 11), 4, true);
            Product product2 = new Product(2, "Product2", "Testar2", 321.45, new DateTime(2022, 11, 17), 6, true);
            Product product3 = new Product(3, "Product3", "Testar3", 456.45, new DateTime(2020, 03, 21), 5, true);
            Product product4 = new Product(4, "Product4", "Testar4", 654.45, new DateTime(2023, 06, 03), 8, true);
            Product copyProduct1 = product1;

            try
            {
                bool result1 = Products.InsertProduct(product1);
                bool result2 = Products.InsertProduct(product2);
                bool result3 = Products.InsertProduct(product3);
                bool result4 = Products.InsertProduct(product4);
                bool copyResult = Products.InsertProduct(copyProduct1);

                Assert.IsTrue(result1);
                Assert.IsTrue(result2);
                Assert.IsTrue(result3);
                Assert.IsTrue(result4);
                Assert.IsFalse(copyResult);

                bool remove1 = Products.RemoveProduct(product1.ProductID);
                bool remove2 = Products.RemoveProduct(product2.ProductID);
                bool remove3 = Products.RemoveProduct(product3.ProductID);
                bool remove4 = Products.RemoveProduct(product4.ProductID);
                bool removeCopy = Products.RemoveProduct(copyProduct1.ProductID);

                bool delete1 = Products.DeleteProduct(product1.ProductID);
                bool delete2 = Products.DeleteProduct(product2.ProductID);
                bool delete3 = Products.DeleteProduct(product3.ProductID);
                bool delete4 = Products.DeleteProduct(product4.ProductID);
                bool deleteCopy = Products.DeleteProduct(copyProduct1.ProductID);

                Assert.IsTrue(delete1);
                Assert.IsTrue(delete2);
                Assert.IsTrue(delete3);
                Assert.IsTrue(delete4);
                Assert.IsTrue(deleteCopy);
            }
            catch (Exception)
            {
                Assert.Fail("ERROR!!!");
            }
        }

        [TestMethod]
        public void InsertClient()
        {
            Client client1 = new Client(1, "Client1", "Testar1", new DateTime(2021, 09, 11), "1234-567", "Rua 1", 123456789, "Email1", true);
            Client client2 = new Client(2, "Client2", "Testar2", new DateTime(2022, 11, 17), "4321-765", "Rua 2", 987654321, "Email2", true);
            Client client3 = new Client(3, "Client3", "Testar3", new DateTime(2020, 03, 21), "5678-123", "Rua 3", 123498765, "Email3", true);
            Client client4 = new Client(4, "Client4", "Testar4", new DateTime(2023, 06, 03), "8765-321", "Rua 4", 987612345, "Email4", true);
            Client copyClient1 = client1;

            try
            {
                bool result1 = Clients.InsertClient(client1);
                bool result2 = Clients.InsertClient(client2);
                bool result3 = Clients.InsertClient(client3);
                bool result4 = Clients.InsertClient(client4);
                bool copyResult = Clients.InsertClient(copyClient1);

                Assert.IsTrue(result1);
                Assert.IsTrue(result2);
                Assert.IsTrue(result3);
                Assert.IsTrue(result4);
                Assert.IsFalse(copyResult);

                bool remove1 = Clients.RemoveClient(client1.ClientID);
                bool remove2 = Clients.RemoveClient(client2.ClientID);
                bool remove3 = Clients.RemoveClient(client3.ClientID);
                bool remove4 = Clients.RemoveClient(client4.ClientID);
                bool removeCopy = Clients.RemoveClient(copyClient1.ClientID);

                bool delete1 = Clients.DeleteClient(client1.ClientID);
                bool delete2 = Clients.DeleteClient(client2.ClientID);
                bool delete3 = Clients.DeleteClient(client3.ClientID);
                bool delete4 = Clients.DeleteClient(client4.ClientID);
                bool deleteCopy = Clients.DeleteClient(copyClient1.ClientID);

                Assert.IsTrue(delete1);
                Assert.IsTrue(delete2);
                Assert.IsTrue(delete3);
                Assert.IsTrue(delete4);
                Assert.IsTrue(deleteCopy);
            }
            catch (Exception)
            {
                Assert.Fail("ERROR!!!");
            }
        }

        [TestMethod]
        public void InsertSale()
        {
            string stockFN = "C:\\Users\\pedro\\OneDrive\\Ambiente de Trabalho\\Projeto_POO_25626\\Source\\Files\\RevenueEngine\\StockList.bin";

            Sale sale1 = new Sale(1, new DateTime(2022, 11, 17), 1, 1, 3, true);
            Sale sale2 = new Sale(2, new DateTime(2022, 11, 17), 2, 2, 5, true);
            Sale sale3 = new Sale(3, new DateTime(2020, 03, 21), 3, 3, 7, true);
            Sale sale4 = new Sale(4, new DateTime(2023, 06, 03), 4, 4, 9, true);
            Sale copySale1 = sale1;

            try
            {
                bool result1 = Sales.InsertSale(sale1, stockFN);
                bool result2 = Sales.InsertSale(sale2, stockFN);
                bool result3 = Sales.InsertSale(sale3, stockFN);
                bool result4 = Sales.InsertSale(sale4, stockFN);
                bool copyResult = Sales.InsertSale(copySale1, stockFN);

                Assert.IsTrue(result1);
                Assert.IsTrue(result2);
                Assert.IsTrue(result3);
                Assert.IsTrue(result4);
                Assert.IsFalse(copyResult);

                bool remove1 = Sales.RemoveSale(sale1.SaleID);
                bool remove2 = Sales.RemoveSale(sale2.SaleID);
                bool remove3 = Sales.RemoveSale(sale3.SaleID);
                bool remove4 = Sales.RemoveSale(sale4.SaleID);
                bool removeCopy = Sales.RemoveSale(copySale1.SaleID);

                bool delete1 = Sales.DeleteSale(sale1.SaleID);
                bool delete2 = Sales.DeleteSale(sale2.SaleID);
                bool delete3 = Sales.DeleteSale(sale3.SaleID);
                bool delete4 = Sales.DeleteSale(sale4.SaleID);
                bool deleteCopy = Sales.DeleteSale(copySale1.SaleID);

                Assert.IsTrue(delete1);
                Assert.IsTrue(delete2);
                Assert.IsTrue(delete3);
                Assert.IsTrue(delete4);
                Assert.IsTrue(deleteCopy);
            }
            catch (Exception)
            {
                Assert.Fail("ERROR!!!");
            }
        }
    }
}
