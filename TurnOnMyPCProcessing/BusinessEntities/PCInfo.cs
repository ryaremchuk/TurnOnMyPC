using System.Xml.Serialization;

namespace TurnOnMyPCProcessing.BusinessEntities
{
    public class PCInfo
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Mac")]
        public string MacAddress { get; set; }

        [XmlIgnore]
        public LocalPCState State { get; set; }
    }
}