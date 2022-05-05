using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace McEdShare.CoreSystem
{
    [DataContract]
    public abstract class SerializableBase : NotifyPropertyChangedBase
    {
        /// <summary>
        /// Data serialize version.
        /// </summary>
        [DataMember]
        public uint Version { get; set; }
    }
}
