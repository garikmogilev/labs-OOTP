using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Serialization
{
    [Serializable]
    [DataContract]
    public class Train 
    {
        [DataMember]
        public string _color;
        [DataMember]
        public string _interier;
        [NonSerialized]
        private Engine _engine;
        
        public Train(string color = "N/A", string interier = "N/A", int power = 0, string fuel = null)
        {
            this._color = color;
            this._interier = interier;
            this._engine = new Engine(power,fuel);
        }

        public string Color => _color;

        public string Interier => _interier;

        public Engine Engine => _engine;

        public override string ToString()
        {
            return "Type: " + base.ToString() + 
                   "\nColor: " + this._color + 
                   "\nColor interier: "  + this._interier + 
                   "\nType fuel: " + _engine.Fuel + 
                   "\nPower: " + _engine.Power + 
                   "\n";
        }
        public Train(){}
    }
}