// Decompiled with JetBrains decompiler
// Type: GPU_Z_Temp_Alert.GPUZ_SHMEM
// Assembly: GPU_Z_Temp_Alert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 452730C4-31F2-4158-BDF0-B1E019AB01BC
// Assembly location: C:\Users\dwkpw\Desktop\GPU_Z_Temp_Alert.exe
// Compiler-generated code is shown
// Metadata token values is shown

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace MiningManager
{
    // Type GPUZ_SHMEM with token 02000006
    public class GPUZ_SHMEM
    {
        // Field MAX_RECORDS with token 04000016
        private const int MAX_RECORDS = 128;
        // Field gPUZ_Running with token 04000017
        private bool gPUZ_Running;
        // Field shMem with token 04000018
        public GPUZ_SHMEM.GPUZ_SH_MEM shMem;

        // Method .ctor with token 06000010
        public GPUZ_SHMEM()
        {
            this.gPUZ_Running = false;
            this.shMem = new GPUZ_SHMEM.GPUZ_SH_MEM();
            //base.\u002Ector();
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.Contains("GPU-Z"))
                {
                    this.gPUZ_Running = true;
                    this.ReadSharedMemory();
                }
                    
            }
        }

        // Property GPUZ_Running with token 17000004
        public bool GPUZ_Running
        {
            // Method get_GPUZ_Running with token 06000011
            get
            {
                return this.gPUZ_Running;
            }
        }

        // Method ReadSharedMemory with token 06000012
        public void ReadSharedMemory()
        {
            this.shMem.data.Clear();
            this.shMem.sensors.Clear();
            using (MemoryMappedFile memoryMappedFile = MemoryMappedFile.OpenExisting("GPUZShMem"))
            {
                using (MemoryMappedViewStream viewStream = memoryMappedFile.CreateViewStream())
                {
                    BinaryReader binaryReader = new BinaryReader((Stream)viewStream, Encoding.Unicode);
                    this.shMem.version = binaryReader.ReadUInt32();
                    this.shMem.busy = binaryReader.ReadInt32();
                    this.shMem.lastUpdate = binaryReader.ReadUInt32();
                    for (int index = 0; index < 128; ++index)
                    {
                        string key = new string(binaryReader.ReadChars(256)).Trim(new char[1]);
                        if (key.Contains("\0"))
                            key = key.Substring(0, key.IndexOf("\0"));
                        string str = new string(binaryReader.ReadChars(256)).Trim(new char[1]);
                        if (str.Contains("\0"))
                            str = str.Substring(0, str.IndexOf("\0"));
                        if (key != string.Empty)
                            this.shMem.data.Add(new KeyValuePair<string, string>(key, str));
                    }
                    for (int index = 0; index < 65536; ++index)
                    {
                        string str1 = new string(binaryReader.ReadChars(256)).Trim(new char[1]);
                        if (str1.Contains("\0"))
                            str1 = str1.Substring(0, str1.IndexOf("\0"));
                        string str2 = new string(binaryReader.ReadChars(8)).Trim(new char[1]);
                        if (str2.Contains("\0"))
                            str2 = str2.Substring(0, str2.IndexOf(char.MinValue));
                        if (str1 != string.Empty)
                        {
                            GPUZ_SHMEM.GPUZ_SENSOR_RECORD gpuzSensorRecord = new GPUZ_SHMEM.GPUZ_SENSOR_RECORD();
                            gpuzSensorRecord.name = str1;
                            gpuzSensorRecord.unit = str2;
                            gpuzSensorRecord.digits = binaryReader.ReadUInt32();
                            gpuzSensorRecord.value = binaryReader.ReadDouble();
                            this.shMem.sensors.Add(gpuzSensorRecord);
                        }
                    }
                }
            }
        }

        // Method GetListOfRecords with token 06000013
        public List<KeyValuePair<string, string>> GetListOfRecords()
        {
            return this.shMem.data;
        }

        // Method GetArrayOfRecords with token 06000014
        public KeyValuePair<string, string>[] GetArrayOfRecords()
        {
            return this.shMem.data.ToArray();
        }

        // Method GetListOfSensors with token 06000015
        public List<GPUZ_SHMEM.GPUZ_SENSOR_RECORD> GetListOfSensors()
        {
            return this.shMem.sensors;
        }

        // Method GetArrayOfSensors with token 06000016
        public GPUZ_SHMEM.GPUZ_SENSOR_RECORD[] GetArrayOfSensors()
        {
            return this.shMem.sensors.ToArray();
        }

        // Method GetRecordByName with token 06000017
        public KeyValuePair<string, string> GetRecordByName(/*Parameter with token 08000005*/string name)
        {
            foreach (KeyValuePair<string, string> keyValuePair in this.shMem.data)
            {
                if (keyValuePair.Key == name)
                    return keyValuePair;
            }
            return new KeyValuePair<string, string>((string)null, (string)null);
        }

        // Method GetSensorByName with token 06000018
        public GPUZ_SHMEM.GPUZ_SENSOR_RECORD GetSensorByName(/*Parameter with token 08000006*/string name)
        {
            foreach (GPUZ_SHMEM.GPUZ_SENSOR_RECORD sensor in this.shMem.sensors)
            {
                if (sensor.name == name)
                    return sensor;
            }
            return (GPUZ_SHMEM.GPUZ_SENSOR_RECORD)null;
        }

        // Method GetRecordByIndex with token 06000019
        public KeyValuePair<string, string> GetRecordByIndex(/*Parameter with token 08000007*/int index)
        {
            if (index >= 0 && index < this.shMem.data.Count)
                return this.shMem.data[index];
            return new KeyValuePair<string, string>((string)null, (string)null);
        }

        // Method GetSensorByIndex with token 0600001A
        public GPUZ_SHMEM.GPUZ_SENSOR_RECORD GetSensorByIndex(/*Parameter with token 08000008*/int index)
        {
            if (index >= 0 && index < this.shMem.sensors.Count)
                return this.shMem.sensors[index];
            return (GPUZ_SHMEM.GPUZ_SENSOR_RECORD)null;
        }

        // Type GPUZ_SENSOR_RECORD with token 02000007
        public class GPUZ_SENSOR_RECORD
        {
            // Field name with token 04000019
            public string name;
            // Field unit with token 0400001A
            public string unit;
            // Field digits with token 0400001B
            public uint digits;
            // Field value with token 0400001C
            public double value;

            // Method .ctor with token 0600001B
           /* public GPUZ_SENSOR_RECORD()
            {
                base.\u002Ector();
            }*/
        }

        // Type GPUZ_SH_MEM with token 02000008
        public class GPUZ_SH_MEM
        {
            // Field version with token 0400001D
            public uint version;
            // Field busy with token 0400001E
            public volatile int busy;
            // Field lastUpdate with token 0400001F
            public uint lastUpdate;
            // Field data with token 04000020
            public List<KeyValuePair<string, string>> data;
            // Field sensors with token 04000021
            public List<GPUZ_SHMEM.GPUZ_SENSOR_RECORD> sensors;

            // Method .ctor with token 0600001C
            public GPUZ_SH_MEM()
            {
                this.data = new List<KeyValuePair<string, string>>(128);
                this.sensors = new List<GPUZ_SHMEM.GPUZ_SENSOR_RECORD>(128);
               // base.\u002Ector();
            }
        }
    }
}
