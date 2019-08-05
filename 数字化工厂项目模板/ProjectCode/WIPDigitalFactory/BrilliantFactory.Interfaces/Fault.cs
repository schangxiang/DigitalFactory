using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BrilliantFactory.Interfaces.Faults
{
    /// <summary>
    /// This is the Base General Fault Exception
    /// </summary>
    [DataContract]
    public class GeneralFaultException
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unlocalizedMessage"></param>
        public GeneralFaultException(string unlocalizedMessage)
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Unlocalized Error Message
        /// </summary>
        [DataMember]
        public string UnlocalizedMessage { get; set; }

        #endregion

    }
}
