using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsbBackupper
{
    class UsbInfoList : ICollection<UsbInfoList.UsbInfo>
    {
        private List<UsbInfo> usbList;
        public UsbInfoList() { }
       

        public struct UsbInfo
        {
            public string backupPath;
            public string volumeLabel;
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
    }

}
