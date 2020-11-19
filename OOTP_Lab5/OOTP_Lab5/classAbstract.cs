using System;

namespace OOTP_Lab5
{
    abstract class PremiumFeatures
    {
        private bool navigation;
        private string aditionalOptions;

        public virtual void setOptions(string addOptons)
        {
            this.aditionalOptions = addOptons;
        }
        public PremiumFeatures(bool navi)
        {
            navigation = navi;
        }
    }

    abstract class print
    {
        public void msgHello()
        {
            Console.WriteLine("HELLO");
        }

    }
}