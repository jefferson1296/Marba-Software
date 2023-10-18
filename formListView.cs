using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formListView : Form
    {
        public formListView()
        {
            InitializeComponent();
        }

        private void formListView_Load(object sender, EventArgs e)
        {
            Font bold = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
            listView1.View = View.Details;
            listView1.Columns.Add("Descrição", 200);
            listView1.Columns.Add("Valor", 100);
            listView1.Groups.Add("Tipo1", "Tipo 1");
            listView1.Items.Add(new ListViewItem(new string[] { "aaaa", "10" })).Group = listView1.Groups["Tipo1"];
            listView1.Items.Add(new ListViewItem(new string[] { "bbbb", "10" })).Group = listView1.Groups["Tipo1"];
            listView1.Items.Add(new ListViewItem(new string[] { "cccc", "30" })).Group = listView1.Groups["Tipo1"];
            ListViewItem lvi = listView1.Items.Add(new ListViewItem(new string[] { "Total", "50" }));
            lvi.Group = listView1.Groups["Tipo1"];
            lvi.Font = bold;

            listView1.Groups.Add("Tipo2", "Tipo 2");
            listView1.Items.Add(new ListViewItem(new string[] { "eeee", "15" })).Group = listView1.Groups["Tipo2"];
            listView1.Items.Add(new ListViewItem(new string[] { "ffff", "15" })).Group = listView1.Groups["Tipo2"];
            listView1.Items.Add(new ListViewItem(new string[] { "gggg", "10" })).Group = listView1.Groups["Tipo2"];
            lvi = listView1.Items.Add(new ListViewItem(new string[] { "Total", "40" }));
            lvi.Group = listView1.Groups["Tipo2"];
            lvi.Font = bold;
        }
    }
}
