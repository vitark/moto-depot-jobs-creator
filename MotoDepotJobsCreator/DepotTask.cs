using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDepotJobsCreator
{
    [Serializable]
    public class DepotTask
    {
        
        [Serializable]
        public class DepotTaskInfo
        {
            public string paramName;

            public object paramValue;

            public DepotTaskInfo()
            {
            }

            public DepotTaskInfo(string name, object value)
            {
                paramName = name;
                paramValue = value;
            }
        }

        public DepotTaskType TaskType;

        public List<DepotTaskInfo> TaskInfos = new List<DepotTaskInfo>(); 
    }

}
