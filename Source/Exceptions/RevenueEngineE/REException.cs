/*
 * <copyright file = "REException.cs" company="IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/19/2023 10:59:01 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;

namespace RevenueEngineE
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/19/2023 10:59:01 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class StockException : Exception
    {
        /// <summary>
        /// Construtor padrão sem parâmetros.
        /// Cria uma instância de StockException sem uma mensagem específica.
        /// </summary>
        public StockException() { }

        /// <summary>
        /// Construtor que aceita uma mensagem como parâmetro.
        /// Cria uma instância de StockException com uma mensagem específica.
        /// </summary>
        /// <param name="message">Mensagem de erro ou informação relacionada à exceção.</param>
        public StockException(string message) : base(message) { }
    }
}
