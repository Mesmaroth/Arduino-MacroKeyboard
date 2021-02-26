using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroKeypadBinder
{
    public partial class form_about : Form
    {
        public form_about()
        {
            InitializeComponent();
            var version = System.Windows.Forms.Application.ProductVersion;
            version_label.Text = version;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
