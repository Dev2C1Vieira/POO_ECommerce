﻿/*
 * <copyright file = "Program.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 26/10/2023 - 20:26:37 PM </date>
 * <description></description>
 * 
 * */

using System;
using ClientsDLL;
using ProductCatalog;
using InputConsoleOutput;

namespace ECommerce
{
    /// <summary>
    /// Purpose: [Write the purpose of the class
    /// Project Name: Projeto_POO_25626
    /// Created By: Pedro Vieira
    /// Created On: 26/10/2023 - 20:26:37 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Inicial_Trial

            #region Clients

            Clients client1 = new Clients();
            Clients client2 = new Clients();

            client1.Name = "Pedro Vieira";
            client1.Gender = 1;
            client1.Address = "Rua das Flores, 123";
            client1.PhoneNumber = 916735615;
            client1.EmailAddress = "a25626@alunos.ipca.pt";

            client2.Name = "Albina Soares";
            client2.Gender = 0;
            client2.Address = "Rua das Crostacios, 231";
            client2.PhoneNumber = 914826352;
            client2.EmailAddress = "a28514@alunos.ipca.pt";

            Console.WriteLine("Welcome to ECommerce Application!");
            IO.ShowClientInformation(client1);
            IO.ShowClientInformation(client1);

            if (IO.CompareClients(client1, client2) == true)//not working properly
                Console.WriteLine("\nThe clientes are equal!\n");
            else
                Console.WriteLine("\nThe clientes are not equal!\n");

            #endregion

            #region Products

            Products product1 = new Products();
            Products product2 = new Products();

            product1.ProductName = "Rato Logitech Pro X Superlight";
            product1.Price = 120.39;
            product1.LauchDate = new DateTime(2022, 12, 3);

            product2.ProductName = "Auscultadores Logitech Pro X Wireless";
            product2.Price = 189.99;
            product2.LauchDate = new DateTime(2022, 9, 17);

            IO.ShowProductInformation(product1);
            IO.ShowProductInformation(product2);

            if (IO.CompareProducts(product1, product2) == true)
                Console.WriteLine("\nThe products are equal!\n");
            else
                Console.WriteLine("\nThe products are not equal!\n");

            #endregion

            #endregion

        }
    }
}