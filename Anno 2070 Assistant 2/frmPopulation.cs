/*===============================================================================
 * File Created by Jay Parker
 * 12/10/2011
 * Last Edited: 12/12/2011 By: Jay Parker
 * Summary:
 * This form calculates population by Type or Residence.  By Residence will
 * calculate how many people inhabit those residences.  By Type will calculate
 * how many residences are supplied to those types.
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
    public partial class frmPopulation : Form
    {
        #region Fields & Properties

        // User settings
        private Assistant.Settings user;
        // Data file paths
        private const string populationData = @".\res\data\Population.xml";
        private const string demandData = @".\res\data\Demand.xml";
        private const string productPath = @".\res\images\products\";
        // XML Data Sets
        private DataSet populationDS;
        private DataSet demandDS;
        // User themed style color
        Color themeColor;

        #endregion

        #region Constructor

        #region Default Constructor

        public frmPopulation(Assistant.Settings user)
        {
            // User configuration initialization
            this.user = user;
            // Initialize components
            InitializeComponent();
            // Setup user theme
            AlterTheme();
            // Defaults to user settings so adjust the form accordingly
            PopulateUserData();
            // Initialize the data sets
            populationDS = new DataSet();
            demandDS = new DataSet();
            // Read XML Data into the data sets
            populationDS.ReadXml(populationData);
            demandDS.ReadXml(demandData);
            // Fill the picture boxes with pictures
            // Iterate through XML tables
            for (int tblIndex = 0; tblIndex < demandDS.Tables.Count; tblIndex++)
            {
                // Iterate through XML rows
                for (int rowIndex = 0; rowIndex < demandDS.Tables[tblIndex].Rows.Count; rowIndex++)
                {
                    // Find which picture box we are dealing with
                    switch (demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(0).ToString())
                    {
                        case "Fish": // Fish
                            if (imgFish.Image == null) // Makes sure it doesn't get double assigned
                                imgFish.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Tea": // Tea
                            imgTea.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Activity": // Activity
                            if (imgActivity.Image == null) // Makes sure it doesn't get double assigned
                                imgActivity.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Health Food": // Health Food
                            imgHealthFood.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Communicator": // Communicator
                            imgCommunicator.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Information": // Information
                            if (imgInformation.Image == null) // Makes sure it doesn't get double assigned
                                imgInformation.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Pasta Dishes": // Pasta Dishes
                            imgPastaDish.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Bio Drinks": // Bio Drinks
                            imgBioDrink.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Participation": // Participation
                            if (imgParticipation.Image == null) // Makes sure it doesn't get double assigned
                                imgParticipation.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "3D Projector": // 3D Projector
                            img3DProjector.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Service Bot": // Service Bot
                            imgServiceBot.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Liquor": // Liquor
                            imgLiquor.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Convenience Food": // Convenience Food
                            imgConvenienceFood.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Plastics": // Plastic
                            imgPlastic.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Luxury Meal": // Luxury Meal
                            imgLuxuryMeal.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Champagne": // Champagne
                            imgChampagne.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Jewelery": // Jewelery
                            imgJewelery.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Pharmaceuticals": // Pharmaceutical
                            imgPharmaceutical.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Functional Food": // Functional Food
                            imgFunctionalFood.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                        case "Functional Drinks": // Functional Drink
                            imgFunctionalDrink.Image = Image.FromFile(productPath + demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(1).ToString());
                            break;
                    }
                }
            }

            // Hide all images now :P
            HideAllImages();
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// This is the button that closes the form and it's associated
        /// event handlers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnClose

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        /// <summary>
        /// The option to use the user set population for calculations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region optMyCivilization

        private void optMyCivilization_CheckedChanged(object sender, EventArgs e)
        {
            // Disable the by residence check box
            optByResidence.Enabled = false;
            if (optMyCivilization.Checked)
                PopulateUserData();
        }

        #endregion

        /// <summary>
        /// The option to use a custom civilization for population calculations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region optCustomCivilization

        private void optCustomCivilization_CheckedChanged(object sender, EventArgs e)
        {
            if (optCustomCivilization.Checked)
            {
                // Enable by residence check box
                optByResidence.Enabled = true;
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
                // Adjust the byResidence check box
                optByResidence.Enabled = true;
                optByResidence.Checked = false;
                // Hide picture boxes
                HideAllImages();
            }
        }

        #endregion

        /// <summary>
        /// This button will calculate what demands the population has based on
        /// the numbers input to the calculator.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnCalculate

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int[] civs = new int[10];
            // Hide all images
            HideAllImages();

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
            }
            else if (optCustomCivilization.Checked) // Custom Civilization
            {
                // If data in the text box is simply empty, add a 0
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
                }
            }

            // Display what demands will be necessary
            for (int tblIndex = 0; tblIndex < demandDS.Tables.Count; tblIndex++)
            {
                for (int rowIndex = 0; rowIndex < demandDS.Tables[tblIndex].Rows.Count; rowIndex++)
                {
                    switch (demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(0).ToString())
                    {
                        case "Fish": // Fish
                            // Fish is special and needs a special calculation because it is shared
                            if (civs[0] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString())
                                || civs[4] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString())
                                || civs[8] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                            {
                                // Show fish
                                imgFish.Show();
                            }
                            break;
                        case "Tea": // Tea
                            if (civs[0] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                imgTea.Show(); // Show Tea
                            break;
                        case "Activity": // Activity is special and needs a special calculation because it is shared
                            if (civs[0] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString())
                                || civs[4] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString())
                                || civs[8] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                imgActivity.Show(); // Show Activity
                            break;
                        case "Health Food": // Health Food
                            if (civs[1] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                imgHealthFood.Show(); // Show Health Food
                            break;
                        case "Communicator": // Communicator
                            if (civs[1] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                imgCommunicator.Show(); // Show Communicator
                            break;
                        case "Information": 
                            // Information is special and needs a special calculation because it is shared and shares a similar
                            // value comparison
                            if (civs[1] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString())
                                && tblIndex == 0)
                            {
                                imgInformation.Show();
                            }
                            else if(civs[5] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString())
                                && tblIndex == 1)
                            {
                                imgInformation.Show();
                            }
                            else if (civs[9] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString())
                                && tblIndex == 2)
                            {
                                imgInformation.Show();
                            }
                            break;
                        case "Pasta Dishes": // Pasta Dishes
                            if (civs[2] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                imgPastaDish.Show(); // Show Pasta Dish
                            break;
                        case "Bio Drinks": // Bio Drinks
                            if (civs[2] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                imgBioDrink.Show(); // Show Bio Drink
                            break;
                        case "Participation": // Participation is special and needs a special calculation because it is shared
                            if (civs[2] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString())
                                || civs[6] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                imgParticipation.Show(); // Show Participation
                            break;
                        case "3D Projector": // 3D Projector
                            if (civs[3] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                img3DProjector.Show(); // Show 3D Projector
                            break;
                        case "Service Bot": // Service Bot
                            if (civs[3] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                imgServiceBot.Show(); // Show Service Bot
                            break;
                        case "Liquor": // Liquor
                            if (civs[4] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                imgLiquor.Show();
                            break;
                        case "Convenience Food": // Convenience Food
                            if (civs[5] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                imgConvenienceFood.Show();
                            break;
                        case "Plastics": // Plastics
                            if (civs[5] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(3).ToString()))
                                imgPlastic.Show();
                            break;
                        case "Luxury Meal": // Luxury Meal
                            if (civs[6] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                imgLuxuryMeal.Show();
                            break;
                        case "Champagne": // Champagne
                            if (civs[6] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(4).ToString()))
                                imgChampagne.Show();
                            break;
                        case "Jewelery": // Jewelery
                            if (civs[7] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                imgJewelery.Show();
                            break;
                        case "Pharmaceuticals": // Pharmaceuticals
                            if (civs[7] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(5).ToString()))
                                imgPharmaceutical.Show();
                            break;
                        case "Functional Food": // Functional Food
                            if (civs[8] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                imgFunctionalFood.Show();
                            break;
                        case "Functional Drinks": // Functional Drinks
                            if (civs[8] >= int.Parse(demandDS.Tables[tblIndex].Rows[rowIndex].ItemArray.GetValue(2).ToString()))
                                imgFunctionalDrink.Show();
                            break;
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// This option is selected when the user wants to calculate by residence
        /// rather than by type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region optbyResidence

        private void optByResidence_CheckedChanged(object sender, EventArgs e)
        {
            // Hide picture boxes, to hint to user that they need to click calculate again
            // this is because the data has now completely changed
            HideAllImages();
        }

        #endregion

        #endregion

        #region Methods

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
            // Hide all picture boxes
            HideAllImages();
        }

        /// <summary>
        /// This method prints error messages to the screen
        /// </summary>
        /// <param name="tag"></param>
        private void PrintError(string tag)
        {
            MessageBox.Show("Error in text box " + tag + ".\nPlease correct before calculating again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// This method hides all demands picture boxes
        /// </summary>
        private void HideAllImages()
        {
            // Hide all demands picture boxes
            imgFish.Hide();
            imgTea.Hide();
            imgActivity.Hide();
            imgHealthFood.Hide();
            imgCommunicator.Hide();
            imgInformation.Hide();
            imgPastaDish.Hide();
            imgBioDrink.Hide();
            imgParticipation.Hide();
            img3DProjector.Hide();
            imgServiceBot.Hide();
            imgLiquor.Hide();
            imgConvenienceFood.Hide();
            imgPlastic.Hide();
            imgLuxuryMeal.Hide();
            imgChampagne.Hide();
            imgJewelery.Hide();
            imgPharmaceutical.Hide();
            imgFunctionalFood.Hide();
            imgFunctionalDrink.Hide();
        }

        /// <summary>
        /// This method alters the window to use the user's theme
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

        #endregion
    }
}
