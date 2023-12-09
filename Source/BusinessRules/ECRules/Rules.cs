/*
 * <copyright file = "Rules.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/3/2023 7:23:12 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;
using System.Collections.Generic;
using ProductCatalog;
using ProductCatalogs;


namespace ECRules
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/3/2023 7:23:12 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class Rules
    {
        #region ProductsMethods

        public static bool InsertProduct(Product produto)
        {
            if (produto.Price > 100) return false;
            try
            {
                Products.InsertProduct(produto);
                return true;
            }
            catch (Exception E)
            {
                throw new Exception("Failed to insert a new product!\r\n" + "-" + E.Message);
            }
        }
        
        public static List<Product> ReturnProductsList()
        {
            return Products.ProductsList;
        }

        //public static Product ShowProduct(Product produto)
        //{
        //    try
        //    {
        //        return Products.ReturnProduct(produto);
        //    }
        //    catch (Exception E)
        //    {
        //        throw new Exception("Failed to Show the product!\r\n" + "-" + E.Message);
        //    }
        //}

        //public static bool DeleteProduct(Product produto)
        //{
        //    try
        //    {
        //        Products.InsertProduct(produto);
        //        return true;
        //        // talvez um campo available que passe para 0
        //        // ou uma nova lista que receba apenas os produtos 'eliminados'
        //    }
        //    catch (Exception E)
        //    {
        //        throw new Exception("Failed to insert a new product!\r\n" + "-" + E.Message);
        //    }
        //}

        #endregion
    }
}
