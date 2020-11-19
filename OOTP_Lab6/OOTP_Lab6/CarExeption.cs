using System;

namespace OOTP_Lab6
{
    public class checkAge : Exception
    {
        public checkAge (string message)
            : base(message)
        { }
    }
    public class percentAlcohol : Exception
    {
        public percentAlcohol(string message)
            : base(message)
        { }
    }
}