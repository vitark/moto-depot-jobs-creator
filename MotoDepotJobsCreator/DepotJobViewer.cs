using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotoDepotJobsCreator
{
    public partial class DepotJobViewer : Form
    {
        public DepotJobViewer(bool selfSignedMode)
        {
            InitializeComponent();

            if (selfSignedMode)
                configureSigningKeyCombobox();
            else
                configureMotorolaKeyCombobox();

            checkOpenJobButtonCondition();
        }

        private class PublicKeyItem
        {
            public string? Name { get; set; }
            public PublicKey? PublicKey { get; set; }
        }

        private void configureSigningKeyCombobox()
        {
            cbSigningKey.Items.Clear();
            var keysDir = Path.Combine(Directory.GetCurrentDirectory(), SigningKey.KeysDirname);
            if (!Directory.Exists(keysDir) || Directory.GetDirectories(keysDir).Length == 0)
            {
                warningText(@"No signing key(s) found.");
                return;
            }


            var dataSource = new List<PublicKeyItem>();
            foreach (string keyDir in Directory.GetDirectories(keysDir))
            {
                var key = new PublicKey(keyDir);
                dataSource.Add(new PublicKeyItem() { Name = key.Name, PublicKey = key });
            }

            cbSigningKey.DataSource = dataSource;
            cbSigningKey.DisplayMember = "Name";
            cbSigningKey.ValueMember = "PublicKey";
        }

        private void configureMotorolaKeyCombobox()
        {
            cbSigningKey.Items.Clear();
            cbSigningKey.Enabled = false;
            var keysDir = Path.Combine(Directory.GetCurrentDirectory(), SigningKey.KeysDirname);
            var motorolaPublicKey = Path.Combine(keysDir, PublicKey.MotorolaPublicKey);
            if (!File.Exists(motorolaPublicKey))
            {
                warningText($"Motorola server public key not found. Expected location is {motorolaPublicKey}");
                return;
            }
            var dataSource = new List<PublicKeyItem>();
            var pk = new PublicKey(keysDir, PublicKey.MotorolaPublicKey);
            dataSource.Add(new PublicKeyItem() { Name = "Motorola server public key", PublicKey = pk });
            cbSigningKey.DataSource = dataSource;
            cbSigningKey.DisplayMember = "Name";
            cbSigningKey.ValueMember = "PublicKey";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkOpenJobButtonCondition()
        {
            btnOpen.Enabled = false;

            if (cbSigningKey.SelectedIndex != -1)
            {
                var sk = cbSigningKey.SelectedValue as PublicKey;
                if (sk == null)
                    return;

                sk.Validate();
                warningText(sk.Error);
                if (sk.hasError())
                    return;
            }
            else
                return;

            btnOpen.Enabled = true;
        }
        private void warningText(string warning)
        {
            textBox.Text = warning;
        }

        private void cbSigningKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkOpenJobButtonCondition();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Depot Job (*.zip)|*.zip|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var publicKey = cbSigningKey.SelectedValue as PublicKey;
                if (publicKey == null)
                {
                    MessageBox.Show("Unknown error in the method btnOpen_Click");
                    return;
                }
                textBox.Text = publicKey.decode(openFileDialog.FileName);
            }
        }
    }
}
