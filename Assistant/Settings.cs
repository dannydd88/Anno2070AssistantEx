/*===============================================================================
 * File Created by Jay Parker
 * 12/8/2011
 * Last Edited: 12/8/2011 By: Jay Parker
 * Summary:
 * This is the bread and butter of the Assistant.dll.  It is a serialized object
 * that has it's data read/written to file for use by the Anno 2070 Assistant.
 * Almost every form in the program will use this object.
 ===============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistant
{
    [Serializable()]
    public class Settings
    {
        #region Fields & Properties

        public enum ColorScheme { Default, Blue, Red, Green, Pink, Black };
        protected ColorScheme theme;

        public ColorScheme Theme
        {
            get { return theme; }
            set { theme = value; }
        }

        protected bool isByType;

        public bool IsByType
        {
            get { return isByType; }
            set { isByType = value; }
        }

        public int ecoWorkers, ecoEmployees, ecoEngineers, ecoExecutives;
        public int labAssistants, researchers;
        public int tycoonWorkers, tycoonEmployees, tycoonEngineers, tycoonExecutives;

        #endregion

        #region Constructor

        public Settings()
        {
            theme = ColorScheme.Default;
            isByType = true;
        }

        #endregion
    }
}
