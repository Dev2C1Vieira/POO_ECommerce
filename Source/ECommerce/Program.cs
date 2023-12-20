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
            #region FilePaths

            #region ProductCatalog

            string productsFN = "C:\\Users\\pedro\\OneDrive\\Ambiente de Trabalho\\Projeto_POO_25626\\Source\\Files\\ProductCatalog\\ProductsList.bin";
            //string productsFN = "C:\\Users\\pedro\\Desktop\\Projeto_POO_25626\\Source\\Files\\ProductCatalog\\ProductsList.bin";

            string categoriesFN = "C:\\Users\\pedro\\OneDrive\\Ambiente de Trabalho\\Projeto_POO_25626\\Source\\Files\\ProductCatalog\\CategoriesList.bin";
            //string categoriesFN = "C:\\Users\\pedro\\Desktop\\Projeto_POO_25626\\Source\\Files\\ProductCatalog\\CategoriesList.bin";

            string brandsFN = "C:\\Users\\pedro\\OneDrive\\Ambiente de Trabalho\\Projeto_POO_25626\\Source\\Files\\ProductCatalog\\BrandsList.bin";
            //string brandsFN = "C:\\Users\\pedro\\Desktop\\Projeto_POO_25626\\Source\\Files\\ProductCatalog\\BrandsList.bin";

            #endregion

            #region StaffClientSystem

            string clientsFN = "C:\\Users\\pedro\\OneDrive\\Ambiente de Trabalho\\Projeto_POO_25626\\Source\\Files\\StaffClientSystem\\ClientsList.bin";
            //string clientsFN = "C:\\Users\\pedro\\Desktop\\Projeto_POO_25626\\Source\\Files\\StaffClientSystem\\ClientsList.bin";

            string employeesFN = "C:\\Users\\pedro\\OneDrive\\Ambiente de Trabalho\\Projeto_POO_25626\\Source\\Files\\StaffClientSystem\\EmployeesList.bin";
            //string clientsFN = "C:\\Users\\pedro\\Desktop\\Projeto_POO_25626\\Source\\Files\\StaffClientSystem\\EmployeesList.bin";

            string managersFN = "C:\\Users\\pedro\\OneDrive\\Ambiente de Trabalho\\Projeto_POO_25626\\Source\\Files\\StaffClientSystem\\ManagersList.bin";
            //string clientsFN = "C:\\Users\\pedro\\Desktop\\Projeto_POO_25626\\Source\\Files\\StaffClientSystem\\ManagersList.bin";

            #endregion

            #region RevenueEngines
            #endregion

            #endregion

            #region LoadData

            #region LoadDataProductCatalog

            ProductsRules.LoadProductsDataBin(productsFN);
            CategoriesRules.LoadCategoriesDataBin(categoriesFN);
            BrandsRules.LoadBrandsDataBin(brandsFN);

            #endregion

            #region LoadDataStaffClientSystem

            ClientsRules.LoadClientsDataBin(clientsFN);
            EmployeesRules.LoadEmployeesDataBin(employeesFN);

            #endregion

            #endregion

            MainMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN);
        }
    }
}