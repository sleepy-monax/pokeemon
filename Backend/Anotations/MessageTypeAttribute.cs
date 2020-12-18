using System;

namespace Anotations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageTypeAttribute : Attribute
    {
        public string TypeName { get; }
        
        public MessageTypeAttribute(string typeName)
        {
            TypeName = typeName;
        }
    }
}