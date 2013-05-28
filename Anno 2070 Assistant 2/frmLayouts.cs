/*===============================================================================
 * File Created by Jay Parker
 * 12/9/2011
 * Last Edited: 12/9/2011 By: Jay Parker
 * Summary:
 * On this form the user can select building layouts to optimize their space
 * usage, while maximizing production.  They can sort between Ecos, Tycoons,
 * and Techs layouts, as well as view general housing layouts.
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
    public partial class frmLayouts : Form
    {
        #region Fields & Properties

        // User settings object
        Assistant.Settings user;
        // User styled theme color
        Color themeColor;

        private const string buildingData = @".\res\data\BuildingLayouts.xml";
        private const string housingData = @".\res\data\HousingLayouts.xml";
        private const string imagePath = @".\res\images\layouts\";
        private const string housingPath = imagePath + @"housing\";
        private string buildingPath;
        private DataSet buildingDS;
        private DataSet housingDS;

        #endregion

        #region Constructor

        #region Default Constructor

        public frmLayouts(Assistant.Settings user)
        {
            // Setup user settings
            this.user = user;
            // Initialize form components
            InitializeComponent();
            // Alter the theme
            AlterTheme();
            // Initialize the data sets
            buildingDS = new DataSet();
            housingDS = new DataSet();
            // Read the XML file into the datasets
            buildingDS.ReadXml(buildingData);
            housingDS.ReadXml(housingData);
            // The form loads with Ecos selected, so populate the listbox
            // with eco layouts.
            for (int i = 0; i < buildingDS.Tables["EcoLayouts"].Rows.Count; i++)
            {
                // Populate the list with eco layouts
                cmbBuilding.Items.Add(buildingDS.Tables["EcoLayouts"].Rows[i].ItemArray.GetValue(0).ToString());
                // Set the image path
                buildingPath = imagePath + @".\ecos\";
            }
            // Setup the housing layouts list
            for (int i = 0; i < housingDS.Tables["Layout"].Rows.Count; i++)
            {
                // Populate the list with housing layouts
                cmbHousing.Items.Add(housingDS.Tables["Layout"].Rows[i].ItemArray.GetValue(0).ToString());
            }
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// This button closes the form.
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
        /// This option chooses Eco layouts.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region optEcos

        private void optEcos_CheckedChanged(object sender, EventArgs e)
        {
            if (optEcos.Checked)
            {
                // Clear the list
                cmbBuilding.Items.Clear();
                // Populate the list with eco layouts
                for (int i = 0; i < buildingDS.Tables["EcoLayouts"].Rows.Count; i++)
                    cmbBuilding.Items.Add(buildingDS.Tables["EcoLayouts"].Rows[i].ItemArray.GetValue(0).ToString());
                // Set the image path
                buildingPath = imagePath + @".\ecos\";
            }
        }

        #endregion

        /// <summary>
        /// This option chooses Tycoon layouts.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region optTycoons

        private void optTycoons_CheckedChanged(object sender, EventArgs e)
        {
            if (optTycoons.Checked)
            {
                // Clear the list
                cmbBuilding.Items.Clear();
                // Populate the list with eco layouts
                for (int i = 0; i < buildingDS.Tables["TycoonLayouts"].Rows.Count; i++)
                    cmbBuilding.Items.Add(buildingDS.Tables["TycoonLayouts"].Rows[i].ItemArray.GetValue(0).ToString());
                // Set the image path
                buildingPath = imagePath + @".\tycoons\";
            }
        }

        #endregion

        /// <summary>
        /// This option chooses Tech layouts.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region optTechs

        private void optTechs_CheckedChanged(object sender, EventArgs e)
        {
            if (optTechs.Checked)
            {
                // Clear the list
                cmbBuilding.Items.Clear();
                // Populate the list with eco layouts
                for (int i = 0; i < buildingDS.Tables["TechLayouts"].Rows.Count; i++)
                    cmbBuilding.Items.Add(buildingDS.Tables["TechLayouts"].Rows[i].ItemArray.GetValue(0).ToString());
                // Set the image path
                buildingPath = imagePath + @".\techs\";
            }
        }

        #endregion

        /// <summary>
        /// This list displays building layouts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region cmbBuilding

        private void cmbBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            // We will set the index by string rather than iterate through the tables
            // which will take more time and resources, this is just faster.
            string index = "";

            // Find the proper index string to use
            if (optEcos.Checked)
                index = "EcoLayouts";
            else if (optTycoons.Checked)
                index = "TycoonLayouts";
            else if (optTechs.Checked)
                index = "TechLayouts";

            // Iterate through the rows matching our index, searching for the item
            for (int i = 0; i < buildingDS.Tables[index].Rows.Count; i++)
            {
                // Check if this row matches our selected item
                if (buildingDS.Tables[index].Rows[i].ItemArray.GetValue(0).ToString() == cmbBuilding.SelectedItem.ToString())
                {
                    // Use index string and result index to show the image
                    imgLayout.Image = Image.FromFile(buildingPath + @buildingDS.Tables[index].Rows[i].ItemArray.GetValue(1).ToString());
                    break;
                }
            }
        }

        #endregion

        /// <summary>
        /// This list displays housing layouts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region cmbHousing

        private void cmbHousing_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Iterate through the rows matching our index, searching for the item
            for (int i = 0; i < housingDS.Tables["Layout"].Rows.Count; i++)
            {
                // Check if this row matches our selected item
                if (housingDS.Tables["Layout"].Rows[i].ItemArray.GetValue(0).ToString() == cmbHousing.SelectedItem.ToString())
                {
                    imgLayout.Image = Image.FromFile(housingPath + @housingDS.Tables["Layout"].Rows[i].ItemArray.GetValue(1).ToString());
                    break;
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

        #endregion
    }
}
