/*===============================================================================
 * File Created by Jay Parker
 * 12/8/2011
 * Last Edited: 12/11/2011 By: Jay Parker
 * Summary:
 * More bread and butter of the Assistant program.  This form is the main menu
 * or primary gateway of sorts to all of the Assistant's features.  It is also
 * responsible for saving the user configuration settings when it closes.  It
 * also passes the user configuration settings object around to forms that
 * rely on it's data.
 ===============================================================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Anno_2070_Assistant_2
{
    public partial class frmMainMenu : Form
    {
        #region Fields & Properties

        // Form declarations used by this form
        frmPopulation fPopulation;
        frmSupply fSupply;
        frmChains fChains;
        frmLayouts fLayouts;
        frmComparison fComparison;
        frmConfig fConfig;
        frmCredits fCredits;
        // Location of the configuration file
        private const string fnConfig = @".\user.bin";
        // Holds user configuration data
        private Assistant.Settings user { get; set; }
        // Holds the brush variable for the user theme
        Color themeColor;

        #endregion

        #region Constructor

        #region Default Constructor

        public frmMainMenu()
        {
            InitializeComponent();
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Event handlers for frmMainMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region frmMainMenu

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            // Setup the splash screen where we will check for a configuration file
            // and verify its integrity by loading then saving it.
            frmSplash fSplash = new frmSplash();
            // Show the splash screen (fast computers shouldn't notice it)
            fSplash.ShowDialog();
            // Retrieve the updated user object for reuse
            this.user = fSplash.user;
            // Dispose of the splash screen, releasing resources
            fSplash.Dispose();
            // Setup the theme
            AlterTheme();
        }

        private void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                // Open up the file stream for file creation
                Stream fileStream = File.Create(fnConfig);
                // Instantiate the BinaryFormatter
                BinaryFormatter serializer = new BinaryFormatter();
                // Translate data to binary and save to file
                serializer.Serialize(fileStream, user);
                // Close the file stream
                fileStream.Close();

                // Close the program
                e.Cancel = false;
            }
            else
                e.Cancel = true; // Cancel closing
        }

        #endregion

        /// <summary>
        /// Event handlers for btnPopulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnPopulation

        private void btnPopulation_Click(object sender, EventArgs e)
        {
            // Instantiate the population form
            fPopulation = new frmPopulation(user);
            // Show the population form as a dialogue window
            fPopulation.ShowDialog();
            // Dispose of the population form to free up memory
            fPopulation.Dispose();
        }

        private void btnPopulation_MouseEnter(object sender, EventArgs e)
        {
            ButtonHover(btnPopulation);
        }

        private void btnPopulation_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnPopulation);
        }

        #endregion

        /// <summary>
        /// Event handlers for btnSupply
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnSupply

        private void btnSupply_Click(object sender, EventArgs e)
        {
            // Instantiate the supply form
            fSupply = new frmSupply(user);
            // Show the supply form as a dialogue window
            fSupply.ShowDialog();
            // Dispose of the supply form to free up memory
            fSupply.Dispose();
        }

        private void btnSupply_MouseEnter(object sender, EventArgs e)
        {
            ButtonHover(btnSupply);
        }

        private void btnSupply_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnSupply);
        }

        #endregion

        /// <summary>
        /// Event handlers for btnChains
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnChains

        private void btnChains_Click(object sender, EventArgs e)
        {
            // Instantiate the production chains form
            fChains = new frmChains(user);
            // Show the production chains form as a dialogue window
            fChains.ShowDialog();
            // Dispose of the production chains form to free up memory
            fChains.Dispose();
        }

        private void btnChains_MouseEnter(object sender, EventArgs e)
        {
            ButtonHover(btnChains);
        }

        private void btnChains_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnChains);
        }

        #endregion

        /// <summary>
        /// Event handlers for btnLayouts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnLayouts

        private void btnLayouts_Click(object sender, EventArgs e)
        {
            // Instantiate the building layouts form
            fLayouts = new frmLayouts(user);
            // Show the building layouts form as a dialogue window
            fLayouts.ShowDialog();
            // Dispose of the building layouts form to free up memory
            fLayouts.Dispose();
        }

        private void btnLayouts_MouseEnter(object sender, EventArgs e)
        {
            ButtonHover(btnLayouts);
        }

        private void btnLayouts_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnLayouts);
        }

        #endregion

        /// <summary>
        /// Event handlers for btnConfig
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnConfig

        private void btnConfig_Click(object sender, EventArgs e)
        {
            // Instantiate the configuration form
            fConfig = new frmConfig(user);
            // Show the configuration form as a dialogue window
            fConfig.ShowDialog();
            // Alter theme just in case
            AlterTheme();
            // Dispose of the configuration form to release memory
            fConfig.Dispose();
        }

        private void btnConfig_MouseEnter(object sender, EventArgs e)
        {
            ButtonHover(btnConfig);
        }

        private void btnConfig_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnConfig);
        }

        #endregion

        /// <summary>
        /// Event handlers for btnCredits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnCredits

        private void btnCredits_Click(object sender, EventArgs e)
        {
            // Instantiate the credits form
            fCredits = new frmCredits(user);
            // Show the credits form as a dialogue window
            fCredits.ShowDialog();
            // Dispose of the credits form to free up memory
            fCredits.Dispose();
        }   

        private void btnCredits_MouseEnter(object sender, EventArgs e)
        {
            ButtonHover(btnCredits);
        }

        private void btnCredits_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnCredits);
        }

        #endregion

        /// <summary>
        /// Event handlers for btnQuit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnQuit

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // Proceed to form closing event
            this.Close();
        }

        private void btnQuit_MouseEnter(object sender, EventArgs e)
        {
            ButtonHover(btnQuit);
        }

        private void btnQuit_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnQuit);
        }

        #endregion

        /// <summary>
        /// This button opens the production comparison form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btnComparison

        private void btnComparison_Click(object sender, EventArgs e)
        {
            // Instantiate the form
            fComparison = new frmComparison(user);
            // Show the form as a dialogue window
            fComparison.ShowDialog();
            // Dispose of the form to free up memory
            fComparison.Dispose();
        }

        private void btnComparison_MouseEnter(object sender, EventArgs e)
        {
            ButtonHover(btnComparison);
        }

        private void btnComparison_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnComparison);
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// This method changes the look and feel of the interface based on user
        /// configuration settings.
        /// </summary>
        #region AlterTheme()

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

        /// <summary>
        /// This method changes button colors when the mouse enter's their area.
        /// </summary>
        /// <param name="b"></param>
        #region ButtonHover(Button b)

        private void ButtonHover(Button b)
        {
            if (user.Theme == Assistant.Settings.ColorScheme.Black) // Black theme has special circumstances
            {
                // Change button back color
                b.BackColor = Color.White;
                // Change button forecolor
                b.ForeColor = Color.Black;
            }
            else
            {
                // Change button back color
                b.BackColor = Color.Black;
                // Change button forecolor
                b.ForeColor = Color.White;
            }
        }

        #endregion

        /// <summary>
        /// This method changes button colors when the mouse leaves their area.
        /// </summary>
        /// <param name="b"></param>
        #region ButtonLeave(Button b)

        private void ButtonLeave(Button b)
        {
            // Change button back color
            b.BackColor = themeColor;

            // Change button forecolor
            if (user.Theme == Assistant.Settings.ColorScheme.Black) // Black theme has special circumstances
                b.ForeColor = Color.White;
            else
                b.ForeColor = Color.Black;
        }

        #endregion

        #endregion
    }
}
