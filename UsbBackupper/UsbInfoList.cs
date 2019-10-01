using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace UsbBackupper
{
    public class UsbInfoList : IList<UsbInfoList.UsbInfo>
    {
        private readonly List<UsbInfo> usbList = new List<UsbInfo>();


        public struct UsbInfo
        {
            public string BackupPath;
            public string VolumeLabel;
            public Guid DeviceId;
            public string LastBackup;
            public BackupMode backupMode;
            public bool CanAutoBackup;
            public bool BackOnCloud;
            public UsbInfo(string backupPath, string volumeLabel, Guid deviceId, BackupMode backupMode, bool backOnCloud, string lastBackup = "Mai",bool canAuto=true)
            {
                BackupPath = backupPath;
                VolumeLabel = volumeLabel;
                DeviceId = deviceId;
                LastBackup = lastBackup;
                this.backupMode = backupMode;
                BackOnCloud = backOnCloud;
                CanAutoBackup = canAuto;
            }
            public enum BackupMode
            {
                [Description("Light")]
                Light,
                [Description("Fast")]
                Fast,
                [Description("Single")]
                Single,
                [Description("Complex")]
                Complex

            }
        }

        public IEnumerator<UsbInfo> GetEnumerator()
        {
            return ((IEnumerable<UsbInfo>) usbList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(UsbInfo item)
        {
            usbList.Add(item);
            Serialize();
        }

        public void Clear()
        {
            usbList.Clear();
            Serialize();

        }

        public bool Contains(UsbInfo item)
        {
            return usbList.Contains(item);
        }

        public void CopyTo(UsbInfo[] array, int arrayIndex)
        {
            usbList.CopyTo(array, arrayIndex);
        }

        public bool Remove(UsbInfo item)
        {
            var result = usbList.Remove(item);
            Serialize();
            return result;

        }

        public int Count => usbList.Count;
        public bool IsReadOnly => false;

        public void Serialize()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(UsbInfoList));
                using (var stream = new StreamWriter("devices.xml"))
                {
                    serializer.Serialize(stream, this);
                    stream.Close();
                }
            }
            catch
            {
                // ignored
            }
        }

        public static UsbInfoList Deserialize()
        {
            UsbInfoList result;
            try
            {
                var deserializer = new XmlSerializer(typeof(UsbInfoList));

                using (var stream = new StreamReader("devices.xml"))
                {
                    result = (UsbInfoList)deserializer.Deserialize(stream);
                    stream.Close();
                }
            }
            catch (FileNotFoundException)
            {
                result = null;
            }
            return result;

        }

        public int IndexOf(UsbInfo item)
        {
            return usbList.IndexOf(item);
        }

        public void Insert(int index, UsbInfo item)
        {
            usbList.Insert(index, item);
            Serialize();
        }

        public void RemoveAt(int index)
        {
            usbList.RemoveAt(index);
            Serialize();
        }

        public UsbInfo this[int index]
        {
            get => index==-1 ? new UsbInfo("","",Guid.NewGuid(),UsbInfo.BackupMode.Fast,false,"") : usbList[index];
            set
            {
                if (index != -1)
                {
                    usbList[index] = value;
                }
                Serialize();
            }
           
        }
    }

}
