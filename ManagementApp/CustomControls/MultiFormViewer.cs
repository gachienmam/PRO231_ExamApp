﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp.CustomControls
{
    class MultiFormViewer : Panel
    {
        private int _currentPageIndex;
        public int CurrentPageIndex
        {
            get { return _currentPageIndex; }
            set
            {
                if (value >= 0 && value < Controls.Count)
                {
                    Controls[value].BringToFront();
                    _currentPageIndex = value;
                }
            }
        }

        public void AddPage(Control page)
        {
            Controls.Add(page);
            page.Dock = DockStyle.Fill;
        }
    }
}
