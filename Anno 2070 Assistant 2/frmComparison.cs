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
    public partial class frmComparison : Form
    {
        #region Fields & Properties

        // User settings
        private Assistant.Settings user;
        // User styled theme color
        private Color themeColor;
        // Production Comparison data set
        private DataSet comparisonDS;
        // Production comparison data path
        private const string comparisonData = @".\res\data\ProductionComparison.xml";
        // Product path
        private const string productPath = @".\res\images\products\";

        #endregion

        #region Constructor

        #region Default Constructor

        public frmComparison(Assistant.Settings user)
        {
            // Setup user settings
            this.user = user;
            // Initialize form components
            InitializeComponent();
            // Alter theme
            AlterTheme();
            // Initialize the data set
            comparisonDS = new DataSet();
            // Fill the data set with data
            comparisonDS.ReadXml(comparisonData);
            // Fill up the list
            for (int i = 0; i < comparisonDS.Tables[0].Rows.Count; i++)
            {
                lstCompare.Items.Add(comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(0).ToString());
            }
        }

        #endregion

        #endregion

        #region Methods

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }

        private void lstCompare_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear picture boxes
            ClearData();
            // Make sure selection is valid
            if (lstCompare.SelectedIndex != -1)
            {
                // Show the equal sign label
                lblCompare.Show();
                // Traverse all rows in the data set
                for (int i = 0; i < comparisonDS.Tables[0].Rows.Count; i++)
                {
                    // Check if the data set item matches our selected item
                    if (lstCompare.SelectedItem.ToString().Equals(comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(0).ToString()))
                    {
                        imgItem1.Image = Image.FromFile(productPath + comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(1).ToString());
                        if(!comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(2).ToString().Equals(""))
                            imgItem2.Image = Image.FromFile(productPath + comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(2).ToString());
                        if (!comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(3).ToString().Equals(""))
                            imgItem3.Image = Image.FromFile(productPath + comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(3).ToString());
                        if (!comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(4).ToString().Equals(""))
                            imgItem4.Image = Image.FromFile(productPath + comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(4).ToString());
                        if (!comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(5).ToString().Equals(""))
                            imgItem5.Image = Image.FromFile(productPath + comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(5).ToString());
                        if (!comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(6).ToString().Equals(""))
                            imgItem6.Image = Image.FromFile(productPath + comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(6).ToString());
                        if (!comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(7).ToString().Equals(""))
                            imgCompareTo1.Image = Image.FromFile(productPath + comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(7).ToString());
                        if (!comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(8).ToString().Equals(""))
                            imgCompareTo2.Image = Image.FromFile(productPath + comparisonDS.Tables[0].Rows[i].ItemArray.GetValue(8).ToString());
                        // Show the picture boxes, we do this in a try statement to suppress errors
                        try
                        {
                                                        
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                        finally
                        { }
                    }
                }
            }
            else
            {
                // Clear picture boxes and hide comparison label
                ClearData();
            }
        }

        /// <summary>
        /// This method clears all the pictures boxes and the hides comparison label
        /// </summary>
        private void ClearData()
        {
            // Hide the comparison label
            lblCompare.Hide();
            // Clear picture boxes
            imgItem1.Image = null;
            imgItem2.Image = null;
            imgItem3.Image = null;
            imgItem4.Image = null;
            imgItem5.Image = null;
            imgItem6.Image = null;
            imgCompareTo1.Image = null;
            imgCompareTo2.Image = null;
        }
    }
}
