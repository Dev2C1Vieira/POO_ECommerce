/*
 * <copyright file = "PCExceptions.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/13/2023 11:39:53 AM </date>
 * <description></description>
 * 
 * */

using System;
using System.Diagnostics;

namespace ProductCatalogE
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/11/2023 10:38:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ProductException : Exception
    {
        /// <summary>
        /// Construtor padrão sem parâmetros.
        /// Cria uma instância de ProductException sem uma mensagem específica.
        /// </summary>
        public ProductException() { }

        /// <summary>
        /// Construtor que aceita uma mensagem como parâmetro.
        /// Cria uma instância de ProductException com uma mensagem específica.
        /// </summary>
        /// <param name="message">Mensagem de erro ou informação relacionada à exceção.</param>
        public ProductException(string message) : base(message) { }
    }
}
