using ManagementApp.CustomControls;
using ReaLTaiizor.Child.Crown;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Docking.Crown;
using ReaLTaiizor.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementApp
{
    public partial class QuanLyDeThiForm : Form
    {
        private readonly List<CrownDockContent> _tools = new();

        private readonly TreeViewControl _dockTreeView;

        public QuanLyDeThiForm()
        {
            InitializeComponent();

            // Add the control scroll message filter to re-route all mousewheel events
            // to the control the user is currently hovering over with their cursor.
            Application.AddMessageFilter(new ControlScrollFilter());
        }

        private void QuanLyDeThiForm_Load(object sender, EventArgs e)
        {
            int childCount = 0;
            for (int i = 0; i < 9; i++)
            {
                CrownTreeNode node = new($"SD180{i}")
                {
                    ExpandedIcon = Properties.Resources.folder_16x,
                    Icon = Properties.Resources.folder_Closed_16xLG
                };

                for (int x = 0; x < 10; x++)
                {
                    CrownTreeNode childNode = new($"SD180{i}-De{childCount}")
                    {
                        Icon = Properties.Resources.document_16xLG
                    };
                    childCount++;
                    node.Nodes.Add(childNode);
                }

                examTreeView.Nodes.Add(node);
            }
        }
    }
}
