using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPProject.Utilities
{
    public partial class CommonMessageBox : Form
    {
        public CommonMessageBox()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void SetLabelText(string newText)
        {
            label1.Text = newText;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.Gainsboro;
            label1.Location = new System.Drawing.Point(label1.Location.X, 22);
            
            label1.Size = new System.Drawing.Size(271, 25);
            label1.TabIndex = 5;
            int parentWidth = this.ClientSize.Width; // Width of the parent container
            int labelWidth = label1.Width; // Width of the label
            int leftPosition = (parentWidth - labelWidth) / 2;
            label1.Left = leftPosition;



        }
        
    }
}
