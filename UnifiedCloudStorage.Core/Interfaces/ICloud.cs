using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedCloudStorage.Core
{
    public interface ICloud
    {

        /// <summary>
        ///     Gets the used quota of the account
        /// </summary>
        /// <param name="service">The <see cref="DriveService" /> that is needed</param>
        /// <returns>The used quota of the account</returns>
        long GetQuotaUsed();

        /// <summary>
        ///     Gets the total quota (is 15 GB) of the account
        /// </summary>
        /// <param name="service">The <see cref="DriveService" /> that is needed</param>
        /// <returns>The total quota of the account</returns>
        long GetQuotaTotal();

    }
}
