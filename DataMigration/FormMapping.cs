using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMigration
{
    public partial class FormMapping : Form
    {
        private DataMigrationSettings _settings = new DataMigrationSettings();
        public FormMapping()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void FormMapping_Load(object sender, EventArgs e)
        {
            //using mocked data before we get real data

            string jsonTxt;
            using (StreamReader r = new StreamReader("json\\MigrationDataModel.json"))
            {
                jsonTxt = r.ReadToEnd();
            }
            var jsonObj = JsonConvert.DeserializeObject<RootObject>(jsonTxt);
                
            //whatever gets binded here should implement IEnumerable
            dataGridView1.DataSource = jsonObj.AttributeMapping.ContractItems;
        }
    }
}
