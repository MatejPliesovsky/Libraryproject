using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace Library___Login
{
    [RunInstaller(true)]
    public partial class ReBooks_Installer : System.Configuration.Install.Installer
    {
        public ReBooks_Installer()
        {
            InitializeComponent();
        }
    }
}
