/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/8/2023 11:56:43 AM </date>
 * <description></description>
 * 
 * */

using System;
using ProductCatalog;

namespace RevenueEngine
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/8/2023 11:56:43 AM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Campaigns
    {
        #region Attributes

        /// <summary>
        /// Creation of the Brands class atributes
        /// </summary>
        private int campaignID; // A unique identifier for each campaign.
        private string campaignName; // The descriptive name of the campaign.
        //private string campaignDescription; // A brief description of the campaign and its objectives.
        private DateTime startCampaingn; // The dates the campaign starts.
        private DateTime endCampaingn; // The dates the campaign ends.
        //private Products[] productsList; // A list of products associated with the campaign.
        private bool visibilityStatus; // An indicator of whether the campaign is visible to users.
        private int campaignType; // Indicator whether it is a promotion, seasonal discount, etc.
        private float campaingBudget; // The budget assigned to the campaign.

        private static int qtdCampaigns = 1; // 

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Campaigns()
        {
            campaignID = qtdCampaigns;
            qtdCampaigns++;
            campaignName = string.Empty;
            startCampaingn = DateTime.Now;
            endCampaingn = DateTime.Now;
            visibilityStatus = false;
            campaignType = -1;
            campaingBudget = -1;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="campaignName"></param>
        /// <param name="beginCampaingn"></param>
        /// <param name="endCampaingn"></param>
        /// <param name="campaignType"></param>
        /// <param name="campaingBudget"></param>
        public Campaigns(string campaignName, DateTime startCampaingn, DateTime endCampaingn, bool visibilityStatus, int campaignType, float campaingBudget)
        {
            campaignID = qtdCampaigns;
            qtdCampaigns++;
            this.campaignName = campaignName;
            this.startCampaingn = startCampaingn;
            this.endCampaingn = endCampaingn;
            this.visibilityStatus = visibilityStatus;
            this.campaignType = campaignType;
            this.campaingBudget = campaingBudget;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the campaignID attribute
        /// </summary>
        public int CampaignID
        {
            get { return campaignID; } 
            set { campaignID = value; }
        }

        /// <summary>
        /// Property related to the campaignName attribute
        /// </summary>
        public string CampaignName
        {
            get { return campaignName; }
            set { campaignName = value; }
        }

        /// <summary>
        /// Property related to the brandID attribute
        /// </summary>
        public DateTime StartCampaingn
        {
            get { return startCampaingn; }
            set { startCampaingn = value; }
        }

        /// <summary>
        /// Property related to the brandID attribute
        /// </summary>
        public DateTime EndCampaingn
        {
            get { return endCampaingn; }
            set { endCampaingn = value; }
        }

        /// <summary>
        /// Property related to the visibilityStatus attribute
        /// </summary>
        public bool VisibilityStatus
        {
            get { return visibilityStatus; }
            set { visibilityStatus = value; }
        }

        /// <summary>
        /// Property related to the campaignType attribute
        /// </summary>
        public int CampaignType
        {
            get { return campaignType; }
            set { campaignType = value; }
        }

        /// <summary>
        /// Property related to the campaingBudget attribute
        /// </summary>
        public float CampaingBudget
        {
            get { return campaingBudget; }
            set { campaingBudget = value;}
        }

        #endregion

        #region Operators

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Campaigns are the same.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Campaigns left, Campaigns right)
        {
            if ((left.CampaignID == right.CampaignID) && (left.CampaignName == right.CampaignName)
                && (left.StartCampaingn == right.StartCampaingn) && (left.EndCampaingn == right.EndCampaingn)
                && (left.CampaignType == right.CampaignType) && (left.CampaingBudget == right.CampaingBudget))
                return (true);
            return (false);
        }

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Campaigns are different.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Campaigns left, Campaigns right)
        {
            if (!(left == right)) return (true);
            return (false);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Rewriting the ToString method, to be able to write on the console.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (String.Format("Campaign ID: {0} - Campaign Name: {1} - Campaign Start Date: {2} - Campaign End Date: {3}" +
                " - Visibility Status {4} - Campaign Type: {5} - Campaign Budget: {6}", CampaignID.ToString(), CampaignName, 
                StartCampaingn.ToString(), EndCampaingn.ToString(), VisibilityStatus.ToString(), CampaignType.ToString(), CampaingBudget.ToString()));
        }

        /// <summary>
        /// Rewriting the Equals method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Campaigns)
            {
                Campaigns campaign = (Campaigns)obj;
                if (this == campaign)
                    return (true);
            }
            return (false);
        }

        /// <summary>
        /// Rewriting the GetHashCode method, to ensure efficient access to elements.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region OtherMethods
        #endregion

        #region Destructor
        #endregion

        #endregion
    }
}
