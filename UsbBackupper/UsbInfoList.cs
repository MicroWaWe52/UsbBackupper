﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
            public BackupMode backupMode;
            public UsbInfo(string backupPath, string volumeLabel, Guid deviceId, BackupMode backupMode,string lastBackup = "Mai")
            {
                BackupPath = backupPath;
                VolumeLabel = volumeLabel;
                DeviceId = deviceId;
                LastBackup = lastBackup;
                this.backupMode = backupMode;
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
            get => index==-1 ? new UsbInfo("","",Guid.NewGuid(),UsbInfo.BackupMode.Fast,"") : usbList[index];
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
