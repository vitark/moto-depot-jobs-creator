using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MotoDepotJobsCreator
{
    class DepotJobData 
    {
        public string SerialNumber { get; }
        public string JobFilename { get; }
        public DepotTaskType JobType { get; }

        public DepotJobData(DepotTaskType jobType, string serialNumber, string jobFilename)
        {
            JobType = jobType;
            SerialNumber = serialNumber;
            JobFilename = jobFilename;
        }
    }
}
