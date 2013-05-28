/*===============================================================================
 * File Created by Jay Parker
 * 12/8/2011
 * Last Edited: 12/8/2011 By: Jay Parker
 * Summary:
 * This form is loaded by the Main menu form before anything else gets loaded.
 * It's purpose is to Find, Open, Read, Close & Write to the user.bin settings
 * file.  The reason for this is to verify that it is there, if not rebuild it
 * and either way verify that it is valid.  The loaded object is then
 * retrieved by the Main Menu form to be passed to other forms.
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
    public partial class frmSplash : Form
    {
        #region Fields & Properties

        private const string FileName = @".\user.bin";
        public Assistant.Settings user = new Assistant.Settings();

        #endregion

        #region Constructor

        #region Default Constructor

        public frmSplash()
        {
            InitializeComponent();
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Event handlers for the frmSplash object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region frmSplash

        private void frmSplash_Load(object sender, EventArgs e)
        {
            if (File.Exists(FileName))
            {
                // Update the label & progress bar
                progressBar1.PerformStep();
                lblStatus.Text = "Verifying Configuration Integrity";
                // Instantiate, open and read the binary file
                Stream fileStream = File.OpenRead(FileName);
                // Instantiate the BinaryFormatter
                BinaryFormatter deserializer = new BinaryFormatter();
                // Recreate the saved object after translating the binary file
                user = (Assistant.Settings)deserializer.Deserialize(fileStream);
                // Close the file stream
                fileStream.Close();
            }
            else
            {
                // Update the label & progress bar
                progressBar1.PerformStep();
                lblStatus.Text = "Building Configuration File";
                // Open up the file stream for file creation
                Stream fileStream = File.Create(FileName);
                // Instantiate the BinaryFormatter
                BinaryFormatter serializer = new BinaryFormatter();
                // Translate data to binary and save to file
                serializer.Serialize(fileStream, user);
                // Close the file stream
                fileStream.Close();
            }

            // Update the label & progress bar
            progressBar1.PerformStep();
            lblStatus.Text = "Starting Assistant...";
            this.Close();
        }

        #endregion

        #endregion
    }
}
