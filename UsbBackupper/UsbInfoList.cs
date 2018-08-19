using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Configuration;
using System.Text;
using System.Xml.Serialization;

namespace UsbBackupper
{
    public class UsbInfoList : ICollection<UsbInfoList.UsbInfo>, IList<UsbInfoList.UsbInfo>
    {
        private readonly List<UsbInfo> usbList = new List<UsbInfo>();
        public UsbInfoList() { }



        public struct UsbInfo
        {
            public string BackupPath;
            public string VolumeLabel;
            public Guid DeviceId;
            public string LastBackup;
            public UsbInfo(string backupPath, string volumeLabel, Guid deviceId, string lastBackup = "Mai")
            {
                BackupPath = backupPath;
                VolumeLabel = volumeLabel;
                DeviceId = deviceId;
                LastBackup = lastBackup;
            }
        }

        public IEnumerator<UsbInfo> GetEnumerator()
        {
            foreach (var item in usbList)
            {
                yield return item;
            }
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
            return usbList.Remove(item);
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
        }

        public void RemoveAt(int index)
        {
            usbList.RemoveAt(index);
        }

        public UsbInfo this[int index]
        {
            get => usbList[index];
            set => usbList[index] = value;
        }
    }

}
