using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

    [Serializable]
    public class FileSet { }

    public class RadioImage { }

    [Serializable]
    [DataContract]
    public class UpdateDeviceData
    {
        [DataMember]
        public List<RadioImage> MemoryImages = new List<RadioImage>();
    }

    [DataContract]
    public enum DataType
    {
        [EnumMember]
        ISH,
        [EnumMember]
        FDI,
        [EnumMember]
        Image
    }

    [Serializable]
    public class PackedRadioData
    {
        [XmlAttribute("ArchiveSessionID")]
        public ushort ArchiveSessionID = 0;
        [XmlAttribute("Type")]
        public DataType DataType = DataType.ISH;
    }

    [Serializable]
    public class DataBlockType { }

    [Serializable]
    [DebuggerDisplay("PrtID={PartitionID}, BlkTyp={BlockType}, BlkID={BlockID}, Content={Content.Length} bytes")]
    public class ValidationField { }

    [Serializable]
    public class ValidationInfo { }

    [Serializable]
    public class LocalLanguagaePack { }

    [DataContract]
    public enum TetraGeneralCommandCode
    {
        [EnumMember]
        Undefined,
        [EnumMember]
        RP_GET_INDICATION,
        [EnumMember]
        RP_SEND_VERSION_REPLY,
        [EnumMember]
        RP_GET_TERMINAL_ID,
        [EnumMember]
        RP_GET_VERSION_INFO,
        [EnumMember]
        SBEP_ERASE_KEYS,
        [EnumMember]
        SBEP_BEGIN_UPDATE_FDT,
        [EnumMember]
        SBEP_END_UPDATE_FDT,
        [EnumMember]
        SBEP_RESTORE_PDV2_RADIO,
        [EnumMember]
        SBEP_MIGRATE_FDT,
        [EnumMember]
        SWITCH_MODE_NO_WAIT,
        [EnumMember]
        SBEP_WRITE_KEYS,
        [EnumMember]
        SBEP_READ_KEYS,
        [EnumMember]
        SBEP_CLEAN_DAMAGE_FLAG,
        [EnumMember]
        SBEP_TEST_FDT,
        [EnumMember]
        OPEN_COMMUNICATION_PIPE,
        [EnumMember]
        AT_CUSTOM_MESSAGE,
        [EnumMember]
        AT_GET_BATTERY_STATUS,
        [EnumMember]
        AT_GET_DEVICE_MODE,
        [EnumMember]
        AT_GET_EMERGENCY_STATUS,
        [EnumMember]
        AT_GET_RADIO_INFO,
        [EnumMember]
        AT_RESET_TO_PROGMODE,
        [EnumMember]
        AT_SET_RP_STATE,
        [EnumMember]
        CLOSE_COMMUNICATION_PIPE,
        [EnumMember]
        GET_CEMSTONE_RADIO_FP_INFO,
        [EnumMember]
        SBEP_GET_PLATFORM_INFO,
        [EnumMember]
        VERIFY_RADIO_LANGUAGE_PACK,
        [EnumMember]
        REMOVE_RS232_RADIO_FROM_SYSTEM,
        [EnumMember]
        AT_GET_DMS,
        [EnumMember]
        AT_ERASE_DMS,
        [EnumMember]
        AT_CHANGE_DMS_CODE,
        [EnumMember]
        MS_COLLECT_PICTURES,
        [EnumMember]
        MS_PUSH_PICTURES,
        [EnumMember]
        CPA_AUTHENTICATE_RADIO,
        [EnumMember]
        SBEP_FLASH_REGION_OPERATION,
        [EnumMember]
        CPA_UNAUTHENTICATE_RADIO,
        [EnumMember]
        SBEP_GET_STATUS,
        [EnumMember]
        SBEP_SET_DAMAGE_FLAG
    }
    [Serializable]
    public class ValidationSpecialField { }

    [Serializable]
    public class PbaObject
    {
        [OptionalField]
        public List<FileSet> FileSetList;
        [OptionalField]
        public UpdateDeviceData PreUpdateData = new UpdateDeviceData();
        [XmlElement("Codeplug")]
        public PackedRadioData CodeplugData;
        public List<DataBlockType> DeletableTypes;
        public List<DataBlockType> IDDeletableTypes;
        public List<ValidationField> ValidationFields;
        public List<ValidationInfo> ValidationInfos;
        public List<ValidationField> PerserveMask;
        public LocalLanguagaePack LocalLangaugePack;
        public TetraGeneralCommandCode GeneralCommandCode = TetraGeneralCommandCode.Undefined;
        public UpdateDeviceData UpdateData = new UpdateDeviceData();
        public bool IsRetoreJob = false;
        public bool IsFactoryResetOp = false;
        public bool IsStaged = false;
        public int RebootCount = 0;
        public List<ValidationSpecialField> ValidationSpecialFields;

        public PbaObject()
        {
            CodeplugData = new PackedRadioData();
            DeletableTypes = new List<DataBlockType>();
            IDDeletableTypes = new List<DataBlockType>();
            ValidationFields = new List<ValidationField>();
            ValidationInfos = new List<ValidationInfo>();
            LocalLangaugePack = new LocalLanguagaePack();
            FileSetList = new List<FileSet>();
            UpdateData = new UpdateDeviceData();
            PreUpdateData = new UpdateDeviceData();
            IsStaged = false;
            RebootCount = 0;
            ValidationSpecialFields = new List<ValidationSpecialField>();
            GeneralCommandCode = TetraGeneralCommandCode.Undefined;
            IsRetoreJob = false;
        }
    }

    [DataContract]
    [Flags]
    public enum ProductFamily
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        AstroRadio = 1,
        [EnumMember]
        MatrixRadio = 2,
        [EnumMember]
        PhoenixRadio = 4,
        [EnumMember]
        ParadiseRadio = 8,
        [EnumMember]
        ParadiseLightRadio = 0x10,
        [EnumMember]
        ParadiseRepeaterRadio = 0x20,
        [EnumMember]
        MatrixRepeaterRadio = 0x40,
        [EnumMember]
        PCRRadio = 0xF007E,
        [EnumMember]
        PBBRadio = 0x80,
        [EnumMember]
        LegacyProgRadio = 0x100,
        [EnumMember]
        LegacyAppRadio = 0x200,
        [EnumMember]
        FrodoProgRadio = 0x400,
        [EnumMember]
        FrodoAppRadio = 0x800,
        [EnumMember]
        AMPRadio = 0x1000,
        [EnumMember]
        GemstoneBMPAppRadio = 0x2000,
        [EnumMember]
        GemstoneBMPMassStorageRadio = 0x4000,
        [EnumMember]
        TetraRadio = 0x106F00,
        [EnumMember]
        DenaliRadio = 0x8000,
        [EnumMember]
        DMR3Controller = 0x10000,
        [EnumMember]
        MNIS = 0x20000,
        [EnumMember]
        VRC = 0x40000,
        [EnumMember]
        ParadisePrimeRadio = 0x80000,
        [EnumMember]
        GemstoneBMPProgRadio = 0x100000,
        [EnumMember]
        Any = 0xFFFF
    }

    [Serializable]
    public class DepotJob
    {
        public string SerialNumber = string.Empty;

        public PbaObject pbaObject = new PbaObject();

        public List<DepotTask> DepotTasks = new List<DepotTask>();

        public string ReportPath = string.Empty;

        public string RamDownloaderFile = string.Empty;

        public bool IsBootMode = false;

        public ProductFamily ProductFamily = ProductFamily.None;
    }


}
