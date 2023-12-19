/*
 * <copyright file = "SCSException.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/19/2023 10:10:28 AM </date>
 * <description></description>
 * 
 * */

using System;
using System.Diagnostics;

namespace StaffClientSystemsE
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/11/2023 10:38:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ClientException : Exception
    {
        /// <summary>
        /// Construtor padrão sem parâmetros.
        /// Cria uma instância de ClientException sem uma mensagem específica.
        /// </summary>
        public ClientException() { }

        /// <summary>
        /// Construtor que aceita uma mensagem como parâmetro.
        /// Cria uma instância de ClientException com uma mensagem específica.
        /// </summary>
        /// <param name="message">Mensagem de erro ou informação relacionada à exceção.</param>
        public ClientException(string message) : base(message) { }
    }

    public class EmployeeException : Exception
    {
        /// <summary>
        /// Construtor padrão sem parâmetros.
        /// Cria uma instância de EmployeeException sem uma mensagem específica.
        /// </summary>
        public EmployeeException() { }

        /// <summary>
        /// Construtor que aceita uma mensagem como parâmetro.
        /// Cria uma instância de EmployeeException com uma mensagem específica.
        /// </summary>
        /// <param name="message">Mensagem de erro ou informação relacionada à exceção.</param>
        public EmployeeException(string message) : base(message) { }
    }
}
