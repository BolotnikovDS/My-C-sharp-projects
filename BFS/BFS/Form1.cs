using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BFS
{
    public partial class Form1 : Form, IDisposable
    {
        public Form1()
        {
            InitializeComponent();

            mazeControl.CreateMap();
        }

        private void buttonShortestPath_Click(object sender, EventArgs e)
        {
            mazeControl.FindShortestPath();
        }

        private void buttonCreateMap_Click(object sender, EventArgs e)
        {
            mazeControl.CreateMap();
        }
    }
}
