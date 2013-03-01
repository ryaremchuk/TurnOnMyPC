using System.IO;
using System.Xml.Serialization;

namespace TurnOnMyPC.Logic
{
    public static class XmlSerializationService<T> where T : class
    {
        private static XmlSerializer _serializer = new XmlSerializer(typeof (T));

        public static T Deserialize(string serializedObject)
        {
            using (var sr = new StringReader(serializedObject))
            {
                return (T) _serializer.Deserialize(sr);
            }
        }

        public static string Serialize(T objectToSerialize)
        {
            using (var sw = new StringWriter())
            {
                _serializer.Serialize(sw, objectToSerialize);
                return sw.ToString();
            }
        }
    }
}