using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace OOTPLab4
{
    public partial class MyList<T> : List<T>
    {

        private dynamic[] mylist;
        public DateTime date;
        public Owner owner = new Owner();
        public override int GetHashCode()
        {
            int res = 757602046;
            foreach(var item in this)
            {
                res = res * 31 + (item == null ? 0 : item.GetHashCode());
            }
            return res;
        }
        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }
        public MyList()
        {
        }

        public MyList(IEnumerable<T> collection) : base(collection)
        {
        }

        public MyList(int capacity) : base(capacity)
        {
        }

        public static MyList<T> operator +(MyList<T> a, dynamic b)
        {
            a.Add(b);
            return a;
        }

        public static MyList<T> operator --(MyList<T> a)
        {
            a.RemoveAt(a.Count - 1);
            return a;
        }

        public static bool operator ==(MyList<T> a, MyList<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(MyList<T> a, MyList<T> b)
        {
            return !(a.Equals(b));
        }

        public static bool operator true(MyList<T> a)
        {
            MyList<T> b = new MyList<T>(a);
            b.Sort();
            return a.Equals(b);
        }
        
        public static bool operator false(MyList<T> a)
        {
            MyList<T> b = new MyList<T>(a);
            b.Sort();
            return a.Equals(b);
        }
        
        public MyList<T> this[int index]
        {
            get
            {
                return mylist[index];
            }
            set
            {
                mylist[index] = value;
            }
        }
    }
}