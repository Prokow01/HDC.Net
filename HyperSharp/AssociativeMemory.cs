using System.Collections.Generic;
using HyperSharp.Datamodel;

namespace HyperSharp {
    public class AssociativeMemory {

        private readonly Encoder _encoder;

        /// <summary>
        /// This is essentially a datastore
        /// </summary>
        public AssociativeMemory(Encoder EncodingScheme) {
            _encoder = EncodingScheme;
        }

        // todo implement serializable
        // /// <summary>
        // /// 
        // /// </summary>
        // /// <returns></returns>
        // public string ToJSON() {
        //     return "";
        // }
        //
        // /// <summary>
        // /// 
        // /// </summary>
        // public void FromJSON() {
        //     
        // }
    }
}