using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDepotJobsCreator
{
    public enum DepotTaskType
    {
        TASK_TYPE_SW_UPGRADE,
        TASK_TYPE_CP_OVERRIDE,
        TASK_TYPE_CP_UPLOAD,
        TASK_TYPE_SWITCHOVER,
        TASK_TYPE_WRITE_AND_SWITCHOVER,
        TASK_TYPE_NONE,
        TASK_TYPE_UPDATE_SERIAL_NUMBER,
        TASK_TYPE_FACTORY_RESET,
        TASK_TYPE_CBI_PROGRAM,
        TASK_TYPE_CP_FORCEWRITE,
        TASK_TYPE_UNKILL_RADIO,
        TASK_TYPE_SW_UPGRADE_BOOTMODE,
        TASK_TYPE_REQUEST_WIFI_CERTIFICATE
    }


    internal class DepotJob
    {
        public bool CreateDepotJobFile(DepotJobData  depotJobData)
        {
            MessageBox.Show(string.Format("{0} {1} {2}",
                depotJobData.JobType,
                depotJobData.SerialNumber,
                depotJobData.JobFilename));

            return true;
        }
    }


}
