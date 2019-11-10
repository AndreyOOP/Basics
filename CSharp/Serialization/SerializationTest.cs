using CSharp.Serialization.Types;
using Microsoft.Xrm.Sdk;
using NUnit.Framework;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharp.Serialization
{
    [TestFixture]
    public class SerializationTest
    {
        [Test]
        public void SerializeTempDeserializeTemp_TempTypeDeserialized()
        {
            var temp = new SimpleClassForSerialization();

            var objBytes = Serializer.SerializeToBytes(temp, 100);

            var deserialized = Serializer.DeserializeFromBytes(objBytes);
        }

        [Test]
        public void SerializeEntityDeserializeEntity_EntityDeserialized()
        {
            var entity = new Entity("Account_Name");

            var bytes = Serializer.SerializeToBytes(entity, 100000);

            var deserialized = Serializer.DeserializeFromBytes(bytes);
        }

        [Test]
        public void SaveToDiskDeserializeFromDisk()
        {
            var path = @"C:\Users\Anik\Documents\Visual Studio 2017\Projects\CSharp\CSharp\Files\ent.dat";
            var entity = new Entity("Account");

            var bytes = Serializer.SerializeToBytes(entity, 100000);

            File.WriteAllBytes(path, bytes);

            var fromFileBytes = File.ReadAllBytes(path);

            var deserializedEntity = Serializer.DeserializeFromBytes(fromFileBytes);
        }

        [Test]
        // here try to inherite from Entity, mark it as serializable & implement ISerializable interface, not work...
        public void SerializableEntity()
        {
            byte[] bytes;
            var binaryFormatter = new BinaryFormatter();

            var serializableEntity = new SerializableEntity("Item");

            using(var stream = new MemoryStream())
            {
                binaryFormatter.Serialize(stream, serializableEntity);
                bytes = stream.ToArray();
                stream.Close();
            }

            using(var stream = new MemoryStream(bytes))
            {
                var deserialized = binaryFormatter.Deserialize(stream);
            }
        }
    }
}
