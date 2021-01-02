using System;
using System.Collections;
using System.Collections.Generic;

namespace OOTP_Lab10.Properties
{
    
    public class WebStoreCollection<T> : IList<T>
    {
        private int a;

        public WebStoreCollection()
        {
        }

        public int A
        {
            get => a;
            set => a = value;
        }
    }