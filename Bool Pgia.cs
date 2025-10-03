﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05
{
    public partial class Bool_Pgia : Form
    {
        private int m_NumOfChances = 4; 
        public Bool_Pgia()
        {
            InitializeComponent();
            buttonNumberOfChances.Text = $"Number of chances : {m_NumOfChances}"; 
        }

        private void buttonGetNumberOfChancesOnClick (object sender, EventArgs e)
        {
            if (m_NumOfChances < 10) m_NumOfChances++;
        
            else
            {
                m_NumOfChances = 4;
            }
            buttonNumberOfChances.Text = $"Number of chances : {m_NumOfChances}";
        }

        private void buttonStartOnClick(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm(m_NumOfChances);
            this.Hide();
            gameForm.ShowDialog();
            this.Show();  
        }
    }
}
