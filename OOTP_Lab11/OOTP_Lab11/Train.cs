using System;

namespace OOTP_Lab11
{
    public sealed partial class Train
    {
        private string  _nametrain;
        private string  _destination;
        private int     _depurtureday;
        public int     _numberofseats;
        private int     _depurturehour;
        private int     _depurturemin;

        public Train(string nametrain, string destination, int depurtureday, int numberofseats, int depurturehour, int depurturemin)
        {
            _nametrain = nametrain;
            _destination = destination;
            _depurtureday = depurtureday;
            _numberofseats = numberofseats;
            _depurturehour = depurturehour;
            _depurturemin = depurturemin;

        }

        public string Nametrain
        {
            get => _nametrain;
            set => _nametrain = value;
        }

        public string Destination
        {
            get => _destination;
            set => _destination = value;
        }

        public int Depurtureday
        {
            get => _depurtureday;
            set => _depurtureday = value;
        }

        public int Numberofseats
        {
            get => _numberofseats;
            set => _numberofseats = value;
        }

        public int Depurturehour
        {
            get => _depurturehour;
            set => _depurturehour = value;
        }

        public int Depurturemin
        {
            get => _depurturemin;
            set => _depurturemin = value;
        }
    }
}