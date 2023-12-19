/*
 * <copyright file = "Program.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 26/10/2023 - 20:26:37 PM </date>
 * <description></description>
 * 
 * */

using System;

//External
using ECMenus;
using ProductCatalogR;
using StaffClientSystemR;

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
        static void Main()
        {
            #region LoadDataProductCatalog
            
            ProductsRules.LoadProductsDataBin();
            CategoriesRules.LoadCategoriesDataBin();
            BrandsRules.LoadBrandsDataBin();

            #endregion

            #region LoadDataStaffClientSystem

            ClientsRules.LoadClientsDataBin();

            #endregion

            MainMenu.Menu();
        }
    }
}