using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamePlatform.Entities
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public class GuestInfoList : IList<GuestInfo>
    {
        public event ChangedEventHandler Changed;

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        private List<GuestInfo> _guestInfoList;
        public GuestInfoList()
        {
            _guestInfoList = new List<GuestInfo>();
        }
        public int IndexOf(GuestInfo item)
        {
            return _guestInfoList.IndexOf(item);
        }

        public void Insert(int index, GuestInfo item)
        {
            _guestInfoList.Insert(index, item);
            OnChanged(EventArgs.Empty);
        }

        public void RemoveAt(int index)
        {
            _guestInfoList.RemoveAt(index);
            OnChanged(EventArgs.Empty);
        }

        public GuestInfo this[int index]
        {
            get
            {
                return _guestInfoList[index];
            }
            set
            {
                _guestInfoList[index] = value;
            }
        }

        public void Add(GuestInfo item)
        {
            _guestInfoList.Add(item);
            OnChanged(EventArgs.Empty);
        }

        public void Clear()
        {
            _guestInfoList.Clear();
            OnChanged(EventArgs.Empty);
        }

        public bool Contains(GuestInfo item)
        {
            return _guestInfoList.Contains(item);
        }

        public void CopyTo(GuestInfo[] array, int arrayIndex)
        {
            _guestInfoList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _guestInfoList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(GuestInfo item)
        {
            bool isSuccess = _guestInfoList.Remove(item);
            OnChanged(EventArgs.Empty);
            return isSuccess;
        }

        public IEnumerator<GuestInfo> GetEnumerator()
        {
            return _guestInfoList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}