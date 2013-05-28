/*===============================================================================
 * File Created by Jay Parker
 * 12/8/2011
 * Last Edited: 12/10/2011 By: Jay Parker
 * Summary:
 * This is a simple credits form giving credit to myself for the creation
 * of this lovely app.  Additional credits are given as necessary including
 * to the game's developers, who without we would not need this app.
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
    public partial class frmCredits : Form
    {
        #region Fields & Properties

        // User settings object
        Assistant.Settings user;
        // User style theme color
        Color themeColor;

        #endregion

        #region Constructor

        #region Default Constructor

        public frmCredits(Assistant.Settings user)
        {
            // Setup user settings
            this.user = user;
            // Initialize form components
            InitializeComponent();
            // Alter theme
            AlterTheme();
            // Add links to the link labels
            lblAnnoFans.Links.Add(0, 30, lblAnnoFans.Text);
            lblAnno2070Wikia.Links.Add(0, 30, lblAnno2070Wikia.Text);
            lblEMail.Links.Add(0, 50, "mailto:bluemanafox@gmail.com");
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// The button used to close the form, and it's associated
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
        /// The label used to quick access my e-mail, and it's associated
        /// event handlers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region lblEMail

        private void lblEMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        #endregion

        /// <summary>
        /// The label used to reach the AnnoFans website, and it's associated
        /// event handlers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region lblAnnoFans

        private void lblAnnoFans_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        #endregion

        /// <summary>
        /// The label used to reach the Anno Wiki website, and it's associated
        /// event handlers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region lblAnno2070Wikia

        private void lblAnno2070Wikia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
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
