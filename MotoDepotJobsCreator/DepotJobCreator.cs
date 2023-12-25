using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MotoDepotJobsCreator
{
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }

    public class DepotJobCreator 
    {
        public string SerialNumber { get; }
        public DepotTaskType JobType { get; }
        public SigningKey SigningKey { get; }

        public DepotJobCreator(DepotTaskType jobType, SigningKey signingKey, string serialNumber)
        {
            JobType = jobType;
            SerialNumber = serialNumber;
            SigningKey = signingKey;
        }

        public bool CreateDepotJobFile(string depotJobFilename)
        {
            DepotJob depotJob = new DepotJob();
            depotJob.SerialNumber = SerialNumber;
            depotJob.DepotTasks.Add(DepotTaskFactory(JobType));

            XmlSerializer x = new XmlSerializer(depotJob.GetType());
            using (Utf8StringWriter textWriter = new Utf8StringWriter())
            {
                x.Serialize(textWriter, depotJob);
                var xmlData = textWriter.ToString();
                return SigningKey.CreateDepotJobFile(xmlData, depotJobFilename);
            }
        }

        private DepotTask DepotTaskFactory(DepotTaskType taskType)
        {
            DepotTask depotTask = new DepotTask();
            switch (taskType)
            {
                case DepotTaskType.TASK_TYPE_FACTORY_RESET:
                    depotTask.TaskType = DepotTaskType.TASK_TYPE_FACTORY_RESET;
                    break;   

                default:
                    throw new Exception($"The Depot task type {taskType} is not implemented.");

            }

            return depotTask;
        }

    }
}
