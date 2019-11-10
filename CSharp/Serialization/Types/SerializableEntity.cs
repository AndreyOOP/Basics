using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace CSharp.Serialization.Types
{
    [Serializable]
    public class SerializableEntity : Entity, ISerializable
    {
        public SerializableEntity()
        {
        }

        public SerializableEntity(string name) : base(name)
        {
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LogicalName", this.LogicalName);
        }
    }
}
