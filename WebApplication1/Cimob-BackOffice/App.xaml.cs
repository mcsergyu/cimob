using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Cimob_BackOffice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static BdApplication bdApplication = new BdApplication();

        public static BdApplication BdApplication
        {
            get
            {
                return bdApplication;
            }
        }
    }
}
