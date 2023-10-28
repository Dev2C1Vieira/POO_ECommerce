/*
 * <copyright file = "Program.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 26/10/2023 - 20:26:37 </date>
 * <description></description>
 * 
 * */

using System;
using BrandsDLL;
using CampaignsDLL;
using CategoriesDLL;
using ClientsDLL;
using GuaranteesDLL;
using ProductsDLL;
using SalesDLL;
using StocksDLL;

namespace ECommerce
{
    /// <summary>
    /// Purpose: [Write the purpose of the class
    /// Project Name: Projeto_POO_25626
    /// Created By: Pedro Vieira
    /// Created On: 26/10/2023
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    internal class Program
    {
        static void Main(string[] args)
        {
            Clients clients = new Clients();
            clients.Name = "Ola";
            Console.WriteLine("Welcome to ECommerce Application!");
            Console.WriteLine("Client Name: {0}", clients.Name);
        }
    }
}
