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
            checkCreateJobButtonCondition();
        }

        public class DepotTaskItem
        {
            public string? Name { get; set; }
            public DepotTaskType Type { get; set; }
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


        private void checkCreateJobButtonCondition()
        {
            btnCreate.Enabled = new SerialNumber(cbSerialNumer.Text).validate();
        }

        private void btnPasteSN_Click(object sender, EventArgs e)
        {
            if (new SerialNumber(Clipboard.GetText().Trim()).validate())
                addSerialNumber(Clipboard.GetText().Trim());
        }

        private void addSerialNumber(string sn)
        {
            foreach (string i in cbSerialNumer.Items)
                if (i.Equals(sn))
                    return;

            cbSerialNumer.Items.Insert(0, sn);
            if (cbSerialNumer.Items.Count > 10)
                cbSerialNumer.Items.RemoveAt(cbSerialNumer.Items.Count - 1);

            cbSerialNumer.SelectedIndex = 0;
        }

        private void cbSerialNumer_TextChanged(object sender, EventArgs e)
        {
            checkCreateJobButtonCondition();
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Depot Job (*.zip)|*.zip|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = fileNameBuilder();
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var depotJobData = new DepotJobData(
                        (DepotTaskType)cbTaskType.SelectedValue,
                        cbSerialNumer.Text,
                        saveFileDialog.FileName
                    );

                if (new DepotJob().CreateDepotJobFile(depotJobData))
                {
                    addSerialNumber(cbSerialNumer.Text);
                }
            }
        }

        private string fileNameBuilder()
        {
            return string.Format("{0}_{1}", cbSerialNumer.Text, cbTaskType.Text.Replace(" ", "_"));
        }
    }
}
