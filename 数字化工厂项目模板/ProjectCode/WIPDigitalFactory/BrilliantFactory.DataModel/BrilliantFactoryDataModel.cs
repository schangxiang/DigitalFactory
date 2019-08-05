using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    public class BrilliantFactoryDataModel : BaseDataModel
    {
        /// <summary>
        /// The code version
        /// </summary>
        /// <returns>The code version</returns>
        public override long GetCodeVersion()
        {
            // Always increase by 1
            return 47;
        }
        

        public static long GetDataModelVersion()
        {
            return 47;
        }
    }
}
