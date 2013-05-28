/*===============================================================================
 * File Created by Jay Parker
 * 12/8/2011
 * Last Edited: 12/12/2011 By: Jay Parker
 * Summary:
 * This form allows the user to either enter a custom civilization, or use
 * their pre-configured one to find out how many of each production chain is
 * necessary to support the current population.
 ===============================================================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Anno_2070_Assistant_2
{
    public partial class frmSupply : Form
    {
        #region Fields & Properties

        // User settings
        private Assistant.Settings user;
        // User themed style color
        private Color themeColor;
        // Supply data path
        private const string supplyData = @".\res\data\Supply.xml";
        // Population data path
        private const string populationData = @".\res\data\Population.xml";
        // Production Rates data path
        private const string ratesData = @".\res\data\ProductionRates.xml";
        // Supply data set
        private DataSet supplyDS;
        // Population data set
        private DataSet populationDS;
        // Production Rates data set
        private DataSet ratesDS;
        // Product path
        private const string productPath = @".\res\images\products\";

        #endregion

        #region Constructor

        #region Default Constructor

        public frmSupply(Assistant.Settings user)
        {
            // Setup the user settings
            this.user = user;
            // Initialize form components
            InitializeComponent();
            // Alter the theme based on the user's preference
            AlterTheme();
            // Initialize the supply data set
            supplyDS = new DataSet();
            // Fill the supply data set with data
            supplyDS.ReadXml(supplyData);
            // Initialize the population data set
            populationDS = new DataSet();
            // Fill the population data set with data
            populationDS.ReadXml(populationData);
            // Initialize the Production Rates data set
            ratesDS = new DataSet();
            // Fill the Production Rates data set with data
            ratesDS.ReadXml(ratesData);
            // Traverse the data set tables
            for (int tblIndex = 0; tblIndex < supplyDS.Tables.Count; tblIndex++)
            {
                // Traverse the data set rows
                for (int rowIndex = 0; rowIndex < supplyDS.Tables[tblIndex].Rows.Count; rowIndex++)
                {
                    // Finally, traverse the controls on the form searching for a picture box match
                    switch (supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(0).ToString())
                    {
                        case "Fish":
                            // Make sure we don't waste time double assigning the picture since fish is a shared product
                            if (imgFish.Image == null)
                                imgFish.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Tea":
                            imgTea.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Health Food":
                            imgHealthFood.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Communicators":
                            imgCommunicator.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Pasta Dishes":
                            imgPastaDish.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Bio Drinks":
                            imgBioDrink.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "3D Projectors":
                            img3DProjector.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Service Bots":
                            imgServiceBot.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Liquor":
                            imgLiquor.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Convenience Food":
                            imgConvenienceFood.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Plastics":
                            imgPlastic.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Luxury Meals":
                            imgLuxuryMeal.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Champagne":
                            imgChampagne.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Jewelery":
                            imgJewelery.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Pharmaceuticals":
                            imgPharmaceutical.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Functional Food":
                            imgFunctionalFood.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Functional Drinks":
                            imgFunctionalDrink.Image = Image.FromFile(productPath + supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                    }
                }
            }

            // Use user configuration is checked by default, so populate user data if there is any
            PopulateUserData();
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// This button closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnClose

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }

        #endregion

        /// <summary>
        ///  This button preps data for the Calculate method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnCalculate

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // We will convert and store all population data here
            // and this variable will be used to do actual calculations
            int[] civs = new int[10];
            // Reset labels
            ResetLabels();
            // Make data uniform and get actual citizen type numbers
            if (optMyCivilization.Checked)
            {
                // Check whether to calculate by residence or by type
                if (!user.IsByType) // User Civilization
                {
                    // Transform type to residence
                    civs[0] = (user.ecoWorkers * int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(0).ToString()));
                    civs[4] = (user.tycoonWorkers * int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(0).ToString()));

                    civs[1] = (user.ecoEmployees * int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(1).ToString()));
                    civs[5] = (user.tycoonEmployees * int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(1).ToString()));

                    civs[2] = (user.ecoEngineers * int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(2).ToString()));
                    civs[6] = (user.tycoonEngineers * int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(2).ToString()));

                    civs[3] = (user.ecoExecutives * int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(3).ToString()));
                    civs[7] = (user.tycoonExecutives * int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(3).ToString()));

                    civs[8] = (user.labAssistants * int.Parse(populationDS.Tables[1].Rows[0].ItemArray.GetValue(0).ToString()));
                    civs[9] = (user.researchers * int.Parse(populationDS.Tables[1].Rows[0].ItemArray.GetValue(1).ToString()));
                }
                else
                {
                    // Copy user settings to civs array
                    civs[0] = user.ecoWorkers;
                    civs[1] = user.ecoEmployees;
                    civs[2] = user.ecoEngineers;
                    civs[3] = user.ecoExecutives;
                    civs[4] = user.tycoonWorkers;
                    civs[5] = user.tycoonEmployees;
                    civs[6] = user.tycoonEngineers;
                    civs[7] = user.tycoonExecutives;
                    civs[8] = user.labAssistants;
                    civs[9] = user.researchers;
                }

                Calculate(civs);
            }
            else if (optCustomCivilization.Checked) // Custom Civilization
            {
                // If data in the text box is simply empty add a 0
                if (txtEcoWorkers.Text.Equals(""))
                    txtEcoWorkers.Text = "0";
                if (txtEcoEmployees.Text.Equals(""))
                    txtEcoEmployees.Text = "0";
                if (txtEcoEngineers.Text.Equals(""))
                    txtEcoEngineers.Text = "0";
                if (txtEcoExecutives.Text.Equals(""))
                    txtEcoExecutives.Text = "0";
                if (txtTycoonWorkers.Text.Equals(""))
                    txtTycoonWorkers.Text = "0";
                if (txtTycoonEmployees.Text.Equals(""))
                    txtTycoonEmployees.Text = "0";
                if (txtTycoonEngineers.Text.Equals(""))
                    txtTycoonEngineers.Text = "0";
                if (txtTycoonExecutives.Text.Equals(""))
                    txtTycoonExecutives.Text = "0";
                if (txtLabAssistants.Text.Equals(""))
                    txtLabAssistants.Text = "0";
                if (txtResearchers.Text.Equals(""))
                    txtResearchers.Text = "0";

                // This will invalidate the calculation if errors are found
                bool isInvalidated = false;
                // Check & parse text
                if (!int.TryParse(txtEcoWorkers.Text, out civs[0]))
                {
                    PrintError(txtEcoWorkers.Tag.ToString());
                    isInvalidated = true;
                }
                else if (!int.TryParse(txtEcoEmployees.Text, out civs[1]))
                {
                    PrintError(txtEcoEmployees.Tag.ToString());
                    isInvalidated = true;
                }
                else if (!int.TryParse(txtEcoEngineers.Text, out civs[2]))
                {
                    PrintError(txtEcoEngineers.Tag.ToString());
                    isInvalidated = true;
                }
                else if (!int.TryParse(txtEcoExecutives.Text, out civs[3]))
                {
                    PrintError(txtEcoExecutives.Tag.ToString());
                    isInvalidated = true;
                }
                else if (!int.TryParse(txtTycoonWorkers.Text, out civs[4]))
                {
                    PrintError(txtTycoonWorkers.Tag.ToString());
                    isInvalidated = true;
                }
                else if (!int.TryParse(txtTycoonEmployees.Text, out civs[5]))
                {
                    PrintError(txtTycoonEmployees.Tag.ToString());
                    isInvalidated = true;
                }
                else if (!int.TryParse(txtTycoonEngineers.Text, out civs[6]))
                {
                    PrintError(txtTycoonEngineers.Tag.ToString());
                    isInvalidated = true;
                }
                else if (!int.TryParse(txtTycoonExecutives.Text, out civs[7]))
                {
                    PrintError(txtTycoonExecutives.Tag.ToString());
                    isInvalidated = true;
                }
                else if (!int.TryParse(txtLabAssistants.Text, out civs[8]))
                {
                    PrintError(txtLabAssistants.Tag.ToString());
                    isInvalidated = true;
                }
                else if (!int.TryParse(txtResearchers.Text, out civs[9]))
                {
                    PrintError(txtResearchers.Tag.ToString());
                    isInvalidated = true;
                }

                if (!isInvalidated)
                {
                    // Check whether to calculate by residence or by type
                    if (optByResidence.Checked)
                    {
                        // Transform residence to type
                        civs[0] *= (int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(0).ToString()));
                        civs[4] *= (int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(0).ToString()));

                        civs[1] *= (int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(1).ToString()));
                        civs[5] *= (int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(1).ToString()));

                        civs[2] *= (int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(2).ToString()));
                        civs[6] *= (int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(2).ToString()));

                        civs[3] *= (int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(3).ToString()));
                        civs[7] *= (int.Parse(populationDS.Tables[0].Rows[0].ItemArray.GetValue(3).ToString()));

                        civs[8] *= (int.Parse(populationDS.Tables[1].Rows[0].ItemArray.GetValue(0).ToString()));
                        civs[9] *= (int.Parse(populationDS.Tables[1].Rows[0].ItemArray.GetValue(1).ToString()));
                    }

                    Calculate(civs);
                }
            }
        }

        #endregion

        /// <summary>
        /// This option is used to select whether to use the user configuration file or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region optMyCivilization

        private void optMyCivilization_CheckedChanged(object sender, EventArgs e)
        {
            PopulateUserData();
        }

        #endregion

        /// <summary>
        /// This option is used to select a custom civilization option as opposed to the user
        /// configuration file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region optCustomCivilization

        private void optCustomCivilization_CheckedChanged(object sender, EventArgs e)
        {
            // Enable by residence check box
            optByResidence.Enabled = true;
            // Uncheck optByResidence if it is checked
            optByResidence.Checked = false;
            // Reset labels
            ResetLabels();
            // Clear all text boxes
            txtEcoWorkers.Clear();
            txtEcoEmployees.Clear();
            txtEcoEngineers.Clear();
            txtEcoExecutives.Clear();
            txtLabAssistants.Clear();
            txtResearchers.Clear();
            txtTycoonWorkers.Clear();
            txtTycoonEmployees.Clear();
            txtTycoonEngineers.Clear();
            txtTycoonExecutives.Clear();
            // Make text boxes editable
            txtEcoWorkers.ReadOnly = false;
            txtEcoEmployees.ReadOnly = false;
            txtEcoEngineers.ReadOnly = false;
            txtEcoExecutives.ReadOnly = false;
            txtLabAssistants.ReadOnly = false;
            txtResearchers.ReadOnly = false;
            txtTycoonWorkers.ReadOnly = false;
            txtTycoonEmployees.ReadOnly = false;
            txtTycoonEngineers.ReadOnly = false;
            txtTycoonExecutives.ReadOnly = false;
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// This is the actual method that does the calculations
        /// </summary>
        private void Calculate(int[] civs)
        {

            // Traverse the tables in the data set
            for (int tblIndex = 0; tblIndex < supplyDS.Tables.Count; tblIndex++)
            {
                // Traverse the rows in the data set
                for (int rowIndex = 0; rowIndex < supplyDS.Tables[tblIndex].Rows.Count; rowIndex++)
                {
                    // Instantiate variables for all civilization types
                    double ecoWorkerConsumption = 0.0;
                    double ecoEmployeeConsumption = 0.0;
                    double ecoEngineerConsumption = 0.0;
                    double ecoExecutiveConsumption = 0.0;
                    double tycoonWorkerConsumption = 0.0;
                    double tycoonEmployeeConsumption = 0.0;
                    double tycoonEngineerConsumption = 0.0;
                    double tycoonExecutiveConsumption = 0.0;
                    double assistantConsumption = 0.0;
                    double researcherConsumption = 0.0;

                    // Traverse the rates tables looking for this item
                    for (int rateTblIndex = 0; rateTblIndex < ratesDS.Tables.Count; rateTblIndex++)
                    {
                        // Traverse the rates rows looking for this item
                        for (int rateRowIndex = 0; rateRowIndex < ratesDS.Tables[rateTblIndex].Rows.Count; rateRowIndex++)
                        {
                            // Traverse the production rates data set until the item we are dealing with matches
                            if (supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(0).ToString().Equals(
                                ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(0).ToString()))
                            {
                                switch (supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(0).ToString())
                                {
                                    case "Fish":
                                        // Do the calculations
                                        ecoWorkerConsumption = (civs[0] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEmployeeConsumption = (civs[1] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEngineerConsumption = (civs[2] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoExecutiveConsumption = (civs[3] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonWorkerConsumption = (civs[4] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(6).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEmployeeConsumption = (civs[5] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(7).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEngineerConsumption = (civs[6] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(8).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonExecutiveConsumption = (civs[7] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(9).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        assistantConsumption = (civs[8] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(10).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        researcherConsumption = (civs[9] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(11).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblFish.Text = Math.Ceiling(ecoWorkerConsumption + ecoEmployeeConsumption + ecoEngineerConsumption + ecoExecutiveConsumption
                                            + tycoonWorkerConsumption + tycoonEmployeeConsumption + tycoonEngineerConsumption + tycoonExecutiveConsumption
                                            + assistantConsumption + researcherConsumption).ToString();
                                        break;
                                    case "Tea":
                                        // Do the calculations
                                        ecoWorkerConsumption = (civs[0] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEmployeeConsumption = (civs[1] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEngineerConsumption = (civs[2] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoExecutiveConsumption = (civs[3] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblTea.Text = Math.Ceiling(ecoWorkerConsumption + ecoEmployeeConsumption + ecoEngineerConsumption + ecoExecutiveConsumption).ToString();
                                        break;
                                    case "Health Food":
                                        // Do the calculations
                                        ecoWorkerConsumption = (civs[0] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEmployeeConsumption = (civs[1] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEngineerConsumption = (civs[2] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoExecutiveConsumption = (civs[3] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblHealthFood.Text = Math.Ceiling(ecoWorkerConsumption + ecoEmployeeConsumption + ecoEngineerConsumption + ecoExecutiveConsumption).ToString();
                                        break;
                                    case "Communicators":
                                        // Do the calculations
                                        ecoWorkerConsumption = (civs[0] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEmployeeConsumption = (civs[1] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEngineerConsumption = (civs[2] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoExecutiveConsumption = (civs[3] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblCommunicator.Text = Math.Ceiling(ecoWorkerConsumption + ecoEmployeeConsumption + ecoEngineerConsumption + ecoExecutiveConsumption).ToString();
                                        break;
                                    case "Pasta Dishes":
                                        // Do the calculations
                                        ecoWorkerConsumption = (civs[0] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEmployeeConsumption = (civs[1] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEngineerConsumption = (civs[2] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoExecutiveConsumption = (civs[3] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblPastaDish.Text = Math.Ceiling(ecoWorkerConsumption + ecoEmployeeConsumption + ecoEngineerConsumption + ecoExecutiveConsumption).ToString();
                                        break;
                                    case "Bio Drinks":
                                        // Do the calculations
                                        ecoWorkerConsumption = (civs[0] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEmployeeConsumption = (civs[1] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEngineerConsumption = (civs[2] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoExecutiveConsumption = (civs[3] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblBioDrink.Text = Math.Ceiling(ecoWorkerConsumption + ecoEmployeeConsumption + ecoEngineerConsumption + ecoExecutiveConsumption).ToString();
                                        break;
                                    case "3D Projectors":
                                        // Do the calculations
                                        ecoWorkerConsumption = (civs[0] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEmployeeConsumption = (civs[1] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEngineerConsumption = (civs[2] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoExecutiveConsumption = (civs[3] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lbl3DProjector.Text = Math.Ceiling(ecoWorkerConsumption + ecoEmployeeConsumption + ecoEngineerConsumption + ecoExecutiveConsumption).ToString();
                                        break;
                                    case "Service Bots":
                                        // Do the calculations
                                        ecoWorkerConsumption = (civs[0] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEmployeeConsumption = (civs[1] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoEngineerConsumption = (civs[2] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        ecoExecutiveConsumption = (civs[3] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblServiceBot.Text = Math.Ceiling(ecoWorkerConsumption + ecoEmployeeConsumption + ecoEngineerConsumption + ecoExecutiveConsumption).ToString();
                                        break;
                                    case "Liquor":
                                        // Do the calculations
                                        tycoonWorkerConsumption = (civs[4] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEmployeeConsumption = (civs[5] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEngineerConsumption = (civs[6] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonExecutiveConsumption = (civs[7] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblLiquor.Text = Math.Ceiling(tycoonWorkerConsumption + tycoonEmployeeConsumption + tycoonEngineerConsumption + tycoonExecutiveConsumption).ToString();
                                        break;
                                    case "Convenience Food":
                                        // Do the calculations
                                        tycoonWorkerConsumption = (civs[4] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEmployeeConsumption = (civs[5] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEngineerConsumption = (civs[6] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonExecutiveConsumption = (civs[7] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblConvenienceFood.Text = Math.Ceiling(tycoonWorkerConsumption + tycoonEmployeeConsumption + tycoonEngineerConsumption + tycoonExecutiveConsumption).ToString();
                                        break;
                                    case "Plastics":
                                        // Do the calculations
                                        tycoonWorkerConsumption = (civs[4] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEmployeeConsumption = (civs[5] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEngineerConsumption = (civs[6] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonExecutiveConsumption = (civs[7] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblPlastic.Text = Math.Ceiling(tycoonWorkerConsumption + tycoonEmployeeConsumption + tycoonEngineerConsumption + tycoonExecutiveConsumption).ToString();
                                        break;
                                    case "Luxury Meals":
                                        // Do the calculations
                                        tycoonWorkerConsumption = (civs[4] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEmployeeConsumption = (civs[5] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEngineerConsumption = (civs[6] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonExecutiveConsumption = (civs[7] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblLuxuryMeal.Text = Math.Ceiling(tycoonWorkerConsumption + tycoonEmployeeConsumption + tycoonEngineerConsumption + tycoonExecutiveConsumption).ToString();
                                        break;
                                    case "Champagne":
                                        // Do the calculations
                                        tycoonWorkerConsumption = (civs[4] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEmployeeConsumption = (civs[5] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEngineerConsumption = (civs[6] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonExecutiveConsumption = (civs[7] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblChampagne.Text = Math.Ceiling(tycoonWorkerConsumption + tycoonEmployeeConsumption + tycoonEngineerConsumption + tycoonExecutiveConsumption).ToString();
                                        break;
                                    case "Jewelery":
                                        // Do the calculations
                                        tycoonWorkerConsumption = (civs[4] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEmployeeConsumption = (civs[5] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEngineerConsumption = (civs[6] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonExecutiveConsumption = (civs[7] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblJewelery.Text = Math.Ceiling(tycoonWorkerConsumption + tycoonEmployeeConsumption + tycoonEngineerConsumption + tycoonExecutiveConsumption).ToString();
                                        break;
                                    case "Pharmaceuticals":
                                        // Do the calculations
                                        tycoonWorkerConsumption = (civs[4] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEmployeeConsumption = (civs[5] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonEngineerConsumption = (civs[6] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        tycoonExecutiveConsumption = (civs[7] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblPharmaceutical.Text = Math.Ceiling(tycoonWorkerConsumption + tycoonEmployeeConsumption + tycoonEngineerConsumption + tycoonExecutiveConsumption).ToString();
                                        break;
                                    case "Functional Food":
                                        // Do the calculations
                                        assistantConsumption = (civs[8] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        researcherConsumption = (civs[9] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblFunctionalFood.Text = Math.Ceiling(assistantConsumption + researcherConsumption).ToString();
                                        break;
                                    case "Functional Drinks":
                                        // Do the calculations
                                        assistantConsumption = (civs[8] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        researcherConsumption = (civs[9] * double.Parse(supplyDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                            / (double.Parse(ratesDS.Tables[rateTblIndex].Rows[rateRowIndex].ItemArray.GetValue(1).ToString()));
                                        // Write to the label
                                        lblFunctionalDrink.Text = Math.Ceiling(assistantConsumption + researcherConsumption).ToString();
                                        break;
                                }
                            }
                        }
                    }

                    // Reset calculation variables for next calculation
                    ecoWorkerConsumption = 0.0;
                    ecoEmployeeConsumption = 0.0;
                    ecoEngineerConsumption = 0.0;
                    ecoExecutiveConsumption = 0.0;
                    tycoonWorkerConsumption = 0.0;
                    tycoonEmployeeConsumption = 0.0;
                    tycoonEngineerConsumption = 0.0;
                    tycoonExecutiveConsumption = 0.0;
                    assistantConsumption = 0.0;
                    researcherConsumption = 0.0;
                }
            }
        }

        /// <summary>
        /// This method alters the window based on the user's selected them
        /// </summary>
        private void AlterTheme()
        {
            // Changes back color for the form, sets back color of buttons, and font colors
            switch (user.Theme)
            {
                case Assistant.Settings.ColorScheme.Default:
                    this.BackColor = SystemColors.Control; // Change back color of form
                    themeColor = Color.White; // Set back color for buttons
                    this.ForeColor = Color.Black; // Set font colors
                    break;
                case Assistant.Settings.ColorScheme.Blue:
                    this.BackColor = Color.LightBlue;
                    themeColor = Color.CornflowerBlue;
                    this.ForeColor = Color.Black;
                    break;
                case Assistant.Settings.ColorScheme.Black:
                    this.BackColor = Color.LightGray;
                    themeColor = Color.Black;
                    this.ForeColor = Color.White;
                    break;
                case Assistant.Settings.ColorScheme.Green:
                    this.BackColor = Color.LightGreen;
                    themeColor = Color.Green;
                    this.ForeColor = Color.Black;
                    break;
                case Assistant.Settings.ColorScheme.Pink:
                    this.BackColor = Color.LightPink;
                    themeColor = Color.Pink;
                    this.ForeColor = Color.Black;
                    break;
                case Assistant.Settings.ColorScheme.Red:
                    this.BackColor = Color.IndianRed;
                    themeColor = Color.Red;
                    this.ForeColor = Color.Black;
                    break;
            }

            // Since we are using windows forms the button colors get messed up
            // when we change the theme, so we will refresh them here.
            if (user.Theme == Assistant.Settings.ColorScheme.Black) // Black theme is special and must be changed differently
            {
                // Traverse the controls on this form searching for buttons
                foreach (Control c in this.Controls)
                {
                    if (c.Name.StartsWith("btn")) // Button Found?
                    {
                        // Change Button ForeColor & BackColor
                        c.ForeColor = Color.White;
                        c.BackColor = themeColor;
                    }
                }
            }
            else
            {
                // Traverse the controls on this form searching for buttons
                foreach (Control c in this.Controls)
                {
                    if (c.Name.StartsWith("btn")) // Button Found?
                    {
                        // Change Button ForeColor & BackColor
                        c.ForeColor = Color.Black;
                        c.BackColor = themeColor;
                    }
                }

            }
        }

        /// <summary>
        /// This method Populates text boxes with User Data, as well as
        /// making them read only, and disabling the byResidence check box
        /// </summary>
        private void PopulateUserData()
        {
            // Populate text boxes with user data
            txtEcoWorkers.Text = user.ecoWorkers.ToString();
            txtEcoEmployees.Text = user.ecoEmployees.ToString();
            txtEcoEngineers.Text = user.ecoEngineers.ToString();
            txtEcoExecutives.Text = user.ecoExecutives.ToString();
            txtLabAssistants.Text = user.labAssistants.ToString();
            txtResearchers.Text = user.researchers.ToString();
            txtTycoonWorkers.Text = user.tycoonWorkers.ToString();
            txtTycoonEmployees.Text = user.tycoonEmployees.ToString();
            txtTycoonEngineers.Text = user.tycoonEngineers.ToString();
            txtTycoonExecutives.Text = user.tycoonExecutives.ToString();
            // Make text boxes read only
            txtEcoWorkers.ReadOnly = true;
            txtEcoEmployees.ReadOnly = true;
            txtEcoEngineers.ReadOnly = true;
            txtEcoExecutives.ReadOnly = true;
            txtLabAssistants.ReadOnly = true;
            txtResearchers.ReadOnly = true;
            txtTycoonWorkers.ReadOnly = true;
            txtTycoonEmployees.ReadOnly = true;
            txtTycoonEngineers.ReadOnly = true;
            txtTycoonExecutives.ReadOnly = true;
            // Adjust the byResidence checkbox
            optByResidence.Enabled = false;
            optByResidence.Checked = !user.IsByType;
            // Reset labels
            ResetLabels();
        }

        /// <summary>
        /// This method resets label text to 0 value.
        /// </summary>
        private void ResetLabels()
        {
            foreach (Control c in this.Controls)
            {
                if (c.Name.StartsWith("lbl"))
                    c.Text = "0";
            }
        }

        /// <summary>
        /// This method prints error messages to the screen
        /// </summary>
        /// <param name="tag"></param>
        private void PrintError(string tag)
        {
            MessageBox.Show("Error in text box " + tag + ".\nPlease correct before calculating again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}