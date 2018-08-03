using Kahua.ApiClient.ServiceClient.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace DataMigration
{
    public partial class FormSettings : Form
    {
        private DataMigrationSettings m_Settings = new DataMigrationSettings();
        public FormSettings()
        {
            InitializeComponent();
        }
        private bool Ask(string Message)
        {
            return DialogResult.OK == MessageBox.Show(Message, Text, MessageBoxButtons.OKCancel);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                txtExcel.Text = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Ask("are you sure?"))
            {
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var mapForm = new FormMapping();
            Hide();
            mapForm.ShowDialog();
            Show();
            
        }
        private void LoadCfgToUI()
        {
            cmbEnv.Items.AddRange(m_Settings.AvailableEnvironments.ToArray());
            if (cmbEnv.Items.Count > 0) cmbEnv.SelectedIndex = 0;
        }

        private void FormSettings_Shown(object sender, EventArgs e)
        {
            m_Settings.ReadFromConfigFile();
            LoadCfgToUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (var unity = new UnityContainer())
            {
                var client = unity.Resolve<Kahua.Contracts.IKahuaApiClient>();
            }
        }
    }
}
