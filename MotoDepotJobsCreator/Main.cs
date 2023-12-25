using System;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MotoDepotJobsCreator
{

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            configureJobTypeCombobox();
            configureSigningKeyCombobox();
            readAllSettings();

            checkCreateJobButtonCondition();
        }

        private class DepotTaskItem
        {
            public string? Name { get; set; }
            public DepotTaskType Type { get; set; }
        }

        private class SigningKeyItem
        {
            public string? Name { get; set; }
            public SigningKey? SigningKey { get; set; }
        }

        private void configureJobTypeCombobox()
        {
            cbTaskType.Items.Clear();

            var dataSource = new List<DepotTaskItem>();
            dataSource.Add(new DepotTaskItem() { Name = "Factory Reset", Type = DepotTaskType.TASK_TYPE_FACTORY_RESET });
            //dataSource.Add(new DepotTaskItem() { Name = "Software Upgrade", Type = DepotTaskType.TASK_TYPE_SW_UPGRADE });
            //dataSource.Add(new DepotTaskItem() { Name = "Codeplug Override", Type = DepotTaskType.TASK_TYPE_CP_OVERRIDE });
            //dataSource.Add(new DepotTaskItem() { Name = "Codeplug Upload", Type = DepotTaskType.TASK_TYPE_CP_UPLOAD });
            //dataSource.Add(new DepotTaskItem() { Name = "Switchover", Type = DepotTaskType.TASK_TYPE_SWITCHOVER });
            //dataSource.Add(new DepotTaskItem() { Name = "Write And Switchover", Type = DepotTaskType.TASK_TYPE_WRITE_AND_SWITCHOVER });
            //dataSource.Add(new DepotTaskItem() { Name = "None", Type = DepotTaskType.TASK_TYPE_NONE });
            //dataSource.Add(new DepotTaskItem() { Name = "Update Serial Number", Type = DepotTaskType.TASK_TYPE_UPDATE_SERIAL_NUMBER });
            //dataSource.Add(new DepotTaskItem() { Name = "CBI Program", Type = DepotTaskType.TASK_TYPE_CBI_PROGRAM });
            //dataSource.Add(new DepotTaskItem() { Name = "Codeplug Force Write", Type = DepotTaskType.TASK_TYPE_CP_FORCEWRITE });
            //dataSource.Add(new DepotTaskItem() { Name = "Unkill Radio", Type = DepotTaskType.TASK_TYPE_UNKILL_RADIO });
            //dataSource.Add(new DepotTaskItem() { Name = "Software Upgrade Bootmode", Type = DepotTaskType.TASK_TYPE_SW_UPGRADE_BOOTMODE });
            //dataSource.Add(new DepotTaskItem() { Name = "Request WiFi Certificate", Type = DepotTaskType.TASK_TYPE_REQUEST_WIFI_CERTIFICATE });

            cbTaskType.DataSource = dataSource;
            cbTaskType.DisplayMember = "Name";
            cbTaskType.ValueMember = "Type";
        }

        private void configureSigningKeyCombobox()
        {
            cbSigningKey.Items.Clear();
            var keysDir = Path.Combine(Directory.GetCurrentDirectory(), SigningKey.KeysDirname);
            if (!Directory.Exists(keysDir) || Directory.GetDirectories(keysDir).Length == 0)
            {
                warningText("No signing key(s) found.");
                return;
            }


            var dataSource = new List<SigningKeyItem>();
            foreach (string keyDir in Directory.GetDirectories(keysDir))
            {
                var signKey = new SigningKey(keyDir);
                dataSource.Add(new SigningKeyItem() { Name = signKey.Name, SigningKey = signKey });
            }

            cbSigningKey.DataSource = dataSource;
            cbSigningKey.DisplayMember = "Name";
            cbSigningKey.ValueMember = "SigningKey";
        }

        private void readAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                var sn = appSettings["recent-used-sn"];
                tbSerialNumber.Text = new SerialNumber(sn).validate() ? sn : "";

                var sidx = int.Parse(appSettings["recent-used-jobtype"] ?? "0");
                cbTaskType.SelectedIndex = sidx < cbTaskType.Items.Count ? sidx : 0;

                if (cbSigningKey.Items.Count > 0)
                {
                    var skdx = int.Parse(appSettings["recent-used-signing-key"] ?? "0");
                    cbSigningKey.SelectedIndex = skdx < cbSigningKey.Items.Count ? skdx : 0;
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        private void saveAllSettongs()
        {
            addUpdateAppSettings("recent-used-sn", tbSerialNumber.Text);
            addUpdateAppSettings("recent-used-jobtype", cbTaskType.SelectedIndex.ToString());
            addUpdateAppSettings("recent-used-signing-key", cbSigningKey.SelectedIndex.ToString());
        }

        static void addUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                    settings.Add(key, value);
                else
                    settings[key].Value = value;
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }


        private void checkCreateJobButtonCondition()
        {
            btnCreate.Enabled = false;
            generateMenuItem.Enabled = btnCreate.Enabled;

            if (cbSigningKey.SelectedIndex != -1)
            {
                var sk = cbSigningKey.SelectedValue as SigningKey;
                if (sk == null)
                    return;

                sk.Validate();
                warningText(sk.Error);
                if (sk.hasError())
                    return;
            }
            else
                return;

            btnCreate.Enabled = (new SerialNumber(tbSerialNumber.Text).validate());
            generateMenuItem.Enabled = btnCreate.Enabled;
        }

        private void btnPasteSN_Click(object sender, EventArgs e)
        {
            if (new SerialNumber(Clipboard.GetText().Trim()).validate())
                tbSerialNumber.Text = Clipboard.GetText().Trim();
            else
            {
                tbSerialNumber.BackColor = Color.LightCoral;
                Task.Delay(250).ContinueWith(t => tbSerialNumber.BackColor = SystemColors.Window);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var sk = cbSigningKey.SelectedValue as SigningKey;
            if (sk == null)
            {
                MessageBox.Show("Unknown error.");
                return;
            }

            if (!sk.TestKey())
            {
                MessageBox.Show(sk.Error);
                return;
            }


            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Depot Job (*.zip)|*.zip|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = fileNameBuilder();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var depotJobData = new DepotJobData(
                        (DepotTaskType)cbTaskType.SelectedValue,
                        tbSerialNumber.Text,
                        saveFileDialog.FileName
                    );

                if (new DepotJob().CreateDepotJobFile(depotJobData))
                {
                    //addSerialNumber(cbSerialNumer.Text);
                }
            }
        }

        private void warningText(string? w)
        {
            if (statusStrip.Items.Count > 0)
            {
                statusStrip.Items[0].Text = w;
                statusStrip.Items[0].ToolTipText = w;
            }

        }

        private string fileNameBuilder()
        {
            return string.Format("{0}_{1}", tbSerialNumber.Text, cbTaskType.Text.Replace(" ", "_"));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Implement me. {0}", Application.ProductVersion));
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveAllSettongs();
        }

        private void tbSerialNumber_TextChanged(object sender, EventArgs e)
        {
            checkCreateJobButtonCondition();
        }

        private void cbSigningKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkCreateJobButtonCondition();
        }
        private void selfGeneratedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepotJobViewer frm = new DepotJobViewer(true);
            frm.ShowDialog();
        }

        private void originalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepotJobViewer frm = new DepotJobViewer(false);
            frm.ShowDialog();
        }
    }
}
