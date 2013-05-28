/*===============================================================================
 * File Created by Jay Parker
 * 12/8/2011
 * Last Edited: 12/11/2011 By: Jay Parker
 * Summary:
 * This is the only form in the program that actually modifies the Settings
 * object.  The user can change their settings here at will, including the
 * look and feel of some of the Assistant's features.
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
    public partial class frmConfig : Form
    {
        #region Fields & Properties

        // User configuration object used by this form
        public Assistant.Settings user;
        // User Configuration Settings
        private Assistant.Settings.ColorScheme userTheme;
        // Variable that detects whether calculations are made by type or residence
        private bool isByType;
        // User style color
        Color themeColor;

        #endregion

        #region Constructor

        #region Default Constructor

        public frmConfig(Assistant.Settings user)
        {
            // User configuration initialization
            this.user = user;
            // Instantiate user settings
            userTheme = user.Theme;
            isByType = user.IsByType;
            // Initialize form components
            InitializeComponent();

            // Setup form based on some of these settings
            if (isByType)
            {
                optByType.Checked = true;
                optByResidence.Checked = false;
            }
            else
            {
                optByResidence.Checked = true;
                optByType.Checked = false;
            }

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

            // Use the user's selected theme for now
            AlterTheme();
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// The combo box used to change user specified visual themes
        /// for the Assistant, and it's associated event handlers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region cmbThemes

        private void cmbThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Change the color theme based on selection
            switch (cmbThemes.SelectedItem.ToString())
            {
                case "Default": // Default
                    userTheme = Assistant.Settings.ColorScheme.Default;
                    break;
                case "Red": // Red
                    userTheme = Assistant.Settings.ColorScheme.Red;
                    break;
                case "Green": // Green
                    userTheme = Assistant.Settings.ColorScheme.Green;
                    break;
                case "Blue": // Blue
                    userTheme = Assistant.Settings.ColorScheme.Blue;
                    break;
                case "Pink": // Pink
                    userTheme = Assistant.Settings.ColorScheme.Pink;
                    break;
                case "Black": // Black
                    userTheme = Assistant.Settings.ColorScheme.Black;
                    break;
            }

            // Allow the user to preview the theme
            AlterTheme();
        }

        #endregion

        /// <summary>
        /// The button used to cancel changes and return to the Main Menu
        /// screen, and it's associated event handlers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnCancel

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close this form
            this.Close();
        }

        #endregion

        /// <summary>
        /// The button used to save changes and return to the Main Menu
        /// screen, and it's associated event handlers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnSave

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Bool used to invalidate the save attempt
            bool isInvalidated = false;
            // Save user settings
            user.Theme = userTheme;
            user.IsByType = isByType;
            // Convert text box variables to ints for tabPopulation
            foreach (Control c in tabPopulation.Controls)
            {
                if (c.Name.StartsWith("txt"))
                {
                    if (ParseTag(c) == -1)
                    {
                        isInvalidated = true;
                        break;
                    }
                }
            }

            if (!isInvalidated)
            {
                // Close the form
                this.Close();
            }
        }

        #endregion

        /// <summary>
        /// The option used to determine that calculations should be
        /// based on Residence, and it's associated event handlers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region optByResidence

        private void optByResidence_CheckedChanged(object sender, EventArgs e)
        {
            if (optByResidence.Checked)
                isByType = false;
            else
                isByType = true;
        }

        #endregion

        /// <summary>
        /// The option used to determine that calculations should be
        /// based on Type, and it's associated event handlers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region optByType

        private void optByType_CheckedChanged(object sender, EventArgs e)
        {
            if (optByType.Checked)
                isByType = true;
            else
                isByType = false;
        }

        #endregion

        #endregion

        #region Methods

        private int ParseTag(Control c)
        {
            switch (c.Tag.ToString())
            {
                case "Eco Workers":
                    if (!int.TryParse(c.Text, out user.ecoWorkers))
                    {
                        ParseError(c.Tag.ToString());
                        return -1;
                    }
                    else
                        return 1;

                case "Eco Employees":
                    if (!int.TryParse(c.Text, out user.ecoEmployees))
                    {
                        ParseError(c.Tag.ToString());
                        return -1;
                    }
                    else
                        return 1;
                case "Eco Engineers":
                    if (!int.TryParse(c.Text, out user.ecoEngineers))
                    {
                        ParseError(c.Tag.ToString());
                        return -1;
                    }
                    else
                        return 1;
                case "Eco Executives":
                    if (!int.TryParse(c.Text, out user.ecoExecutives))
                    {
                        ParseError(c.Tag.ToString());
                        return -1;
                    }
                    else
                        return 1;
                case "Tech Lab Assistants":
                    if (!int.TryParse(c.Text, out user.labAssistants))
                    {
                        ParseError(c.Tag.ToString());
                        return -1;
                    }
                    else
                        return 1;
                case "Tech Researchers":
                    if (!int.TryParse(c.Text, out user.researchers))
                    {
                        ParseError(c.Tag.ToString());
                        return -1;
                    }
                    else
                        return 1;
                case "Tycoon Workers":
                    if (!int.TryParse(c.Text, out user.tycoonWorkers))
                    {
                        ParseError(c.Tag.ToString());
                        return -1;
                    }
                    else
                        return 1;
                case "Tycoon Employees":
                    if (!int.TryParse(c.Text, out user.tycoonEmployees))
                    {
                        ParseError(c.Tag.ToString());
                        return -1;
                    }
                    else
                        return 1;
                case "Tycoon Engineers":
                    if (!int.TryParse(c.Text, out user.tycoonEngineers))
                    {
                        ParseError(c.Tag.ToString());
                        return -1;
                    }
                    else
                        return 1;
                case "Tycoon Executives":
                    if (!int.TryParse(c.Text, out user.tycoonExecutives))
                    {
                        ParseError(c.Tag.ToString());
                        return -1;
                    }
                    else
                        return 1;
                default:
                    return -1;
            }
        }

        private void ParseError(string tag)
        {
            Console.WriteLine("THIS RAN");
            MessageBox.Show("Invalid value in text box " + tag + ".\nPlease correct this before trying to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AlterTheme()
        {
            // Changes back color for the form, sets back color of buttons, and font colors
            switch (userTheme)
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
