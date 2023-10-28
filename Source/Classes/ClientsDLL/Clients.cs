/*
 * <copyright file = "Clients.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 26/10/2023 - 20:30:13 </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;

namespace ClientsDLL
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 26/10/2023 - 20:30:13
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class Clients
    {
        /// <summary>
        /// 
        /// </summary>
        #region Attributes

        private string name;
        private DateTime birth_date;
        private bool gender;
        private string address;
        private int ph_number;
        private string email_address;

        private static int Qtd_Clients;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public Clients()
        {
            name = "";
            gender = true;
            address = "";
            ph_number = -1;
            email_address = "";
            Qtd_Clients = 0;
        }

        public Clients()
        {

        }

        #endregion

        #region Properties
        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        #endregion

        #region Destructor
        #endregion

        #endregion
    }
}
