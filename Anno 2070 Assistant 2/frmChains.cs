/*===============================================================================
 * File Created by Jay Parker
 * 12/10/2011
 * Last Edited: 12/11/2011 By: Jay Parker
 * Summary:
 * This form is where the user can get detailed information on production
 * chains.  This incldues, Eco Balance cost, Balance, Cost & Power consumption
 * information, as well as which production buildings are necessary to
 * complete the chain.
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
    public partial class frmChains : Form
    {
        #region Fields & Properties

        // User settings
        Assistant.Settings user;
        // User style theme color
        Color themeColor;
        // Production chains data
        DataSet chainsDS;
        // Production chains data path
        private const string chainsData = @".\res\data\ProductionChains.xml";
        // Production chains images path
        private const string productPath = @".\res\images\products\";

        #endregion

        #region Constructor

        #region Default Constructor

        public frmChains(Assistant.Settings user)
        {
            // Initialize user settings
            this.user = user;
            // Initialize form components
            InitializeComponent();
            // Setup theme
            AlterTheme();
            // Initialize the data set
            chainsDS = new DataSet();
            // Fill the data set with data
            chainsDS.ReadXml(chainsData);
            // Ecos are selected by default, so load the list with that data
            for (int i = 0; i < chainsDS.Tables[0].Rows.Count; i++)
            {
                cmbChains.Items.Add(chainsDS.Tables[0].Rows[i].ItemArray.GetValue(0).ToString());
            }
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// This method closes the form.
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
        /// This radio button sets the production chains to Ecos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region optEcos

        private void optEcos_CheckedChanged(object sender, EventArgs e)
        {
            // Clear the list box
            cmbChains.Items.Clear();
            // Nullify product images if they aren't already nullified
            ClearProductImages();
            // Hide production data
            HideProductionValues();
            // Populate the list with Ecos production chains
            for (int i = 0; i < chainsDS.Tables[0].Rows.Count; i++)
            {
                cmbChains.Items.Add(chainsDS.Tables[0].Rows[i].ItemArray.GetValue(0).ToString());
            }
        }

        #endregion

        /// <summary>
        /// This radio button sets the production chains to Tycoons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region optTycoons

        private void optTycoons_CheckedChanged(object sender, EventArgs e)
        {
            // Clear the list
            cmbChains.Items.Clear();
            // Nullify product images if they aren't already nullified
            ClearProductImages();
            // Hide production data
            HideProductionValues();
            // Populate the list with Tycoons production chains
            for (int i = 0; i < chainsDS.Tables[1].Rows.Count; i++)
            {
                cmbChains.Items.Add(chainsDS.Tables[1].Rows[i].ItemArray.GetValue(0).ToString());
            }
        }

        #endregion

        /// <summary>
        /// This radio button sets the production chains to Techs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region optTechs

        private void optTechs_CheckedChanged(object sender, EventArgs e)
        {
            // Clear the list
            cmbChains.Items.Clear();
            // Nullify product images if they aren't already nullified
            ClearProductImages();
            // Hide production data
            HideProductionValues();
            // Populate the list with Techs production chains
            for (int i = 0; i < chainsDS.Tables[2].Rows.Count; i++)
            {
                cmbChains.Items.Add(chainsDS.Tables[2].Rows[i].ItemArray.GetValue(0).ToString());
            }
        }

        #endregion

        /// <summary>
        /// This combox box holds the list of production chains.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region cmbChains

        private void cmbChains_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the current product items
            ClearProductImages();
            // Show production data
            ShowProductionValues();
            // Table index string used to figure out who we are calculating for
            string tblIndex = "";

            // Figure which faction we are dealing with
            if (optEcos.Checked)
                tblIndex = "Ecos";
            else if (optTycoons.Checked)
                tblIndex = "Tycoons";
            else if (optTechs.Checked)
                tblIndex = "Techs";

            // Find our selected item within the faction's production chains
            for (int row = 0; row < chainsDS.Tables[tblIndex].Rows.Count; row++)
            {
                // Is this the selected item?
                if (chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(0).ToString().Equals(cmbChains.SelectedItem.ToString()))
                {
                    // Display the data associated with this chain, using a try statement to suppress errors
                    try
                    {
                        imgItem1.Image = Image.FromFile(productPath + chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(1).ToString());
                        if(!chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(2).ToString().Equals(""))
                            imgItem2.Image = Image.FromFile(productPath + chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(2).ToString());
                        if (!chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(3).ToString().Equals(""))
                            imgItem3.Image = Image.FromFile(productPath + chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(3).ToString());
                        if (!chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(4).ToString().Equals(""))
                            imgItem4.Image = Image.FromFile(productPath + chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(4).ToString());
                        if (!chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(5).ToString().Equals(""))
                            imgItem5.Image = Image.FromFile(productPath + chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(5).ToString());
                        if (!chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(6).ToString().Equals(""))
                            imgItem6.Image = Image.FromFile(productPath + chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(6).ToString());
                        if (!chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(7).ToString().Equals(""))
                            imgItem7.Image = Image.FromFile(productPath + chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(7).ToString());
                        if (!chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(8).ToString().Equals(""))
                            imgItem8.Image = Image.FromFile(productPath + chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(8).ToString());
                        if (!chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(9).ToString().Equals(""))
                            imgItem9.Image = Image.FromFile(productPath + chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(9).ToString());
                        if (!chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(10).ToString().Equals(""))
                            imgItem10.Image = Image.FromFile(productPath + chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(10).ToString());
                        if (!chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(11).ToString().Equals(""))
                            imgItem11.Image = Image.FromFile(productPath + chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(11).ToString());
                        if (!chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(12).ToString().Equals(""))
                            imgItem12.Image = Image.FromFile(productPath + chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(12).ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        lblCost.Text = chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(13).ToString();
                        lblBalance.Text = chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(14).ToString();
                        lblPower.Text = chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(15).ToString();
                        lblEcoBalance.Text = chainsDS.Tables[tblIndex].Rows[row].ItemArray.GetValue(16).ToString();
                    }
                }
            }
        }

        #endregion

        #endregion

        #region Methods

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
        /// This method hides product images
        /// </summary>
        private void ClearProductImages()
        {
            // Hides product images
            imgItem1.Image = null;
            imgItem2.Image = null;
            imgItem3.Image = null;
            imgItem4.Image = null;
            imgItem5.Image = null;
            imgItem6.Image = null;
            imgItem7.Image = null;
            imgItem8.Image = null;
            imgItem9.Image = null;
            imgItem10.Image = null;
            imgItem11.Image = null;
            imgItem12.Image = null;
        }

        /// <summary>
        /// This method hides the production pictures & text (i.e.
        /// Power, Eco Balance, Balance & Cost.
        /// </summary>
        private void HideProductionValues()
        {
            imgCost.Hide();
            lblCost.Hide();
            imgBalance.Hide();
            lblBalance.Hide();
            imgEcoBalance.Hide();
            lblEcoBalance.Hide();
            imgPower.Hide();
            lblPower.Hide();
        }

        /// <summary>
        /// This method shows the production pictures & text (i.e.
        /// Power, Eco Balance, Balance & Cost.
        /// </summary>
        private void ShowProductionValues()
        {
            imgCost.Show();
            lblCost.Show();
            imgBalance.Show();
            lblBalance.Show();
            imgEcoBalance.Show();
            lblEcoBalance.Show();
            imgPower.Show();
            lblPower.Show();
        }

        #endregion
    }
}
