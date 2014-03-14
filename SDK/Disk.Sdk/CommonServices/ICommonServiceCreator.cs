using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Disk.SDK.CommonServices
{
    /// <summary>
    /// Service creator interface
    /// </summary>
    public interface ICommonServiceCreator
    {
        ICommonService Create();
    }

    /// <summary>
    /// Default CommonService creator
    /// </summary>
    internal class DefaultCommonServiceCreator : ICommonServiceCreator
    {
        private const string ASSEMBLY_NAME = "Disk.SDK.Provider",
                             SERVICE_NAME = "Disk.SDK.Provider.CommonService",
                             SERVICE_FULL_NAME_FORMAT = "{0}, {1}";

        #region Implementation of ICommonServiceCreator

        public ICommonService Create()
        {
            var assemblyName = new AssemblyName { Name = ASSEMBLY_NAME };
            var commonServiceType = Type.GetType(string.Format(SERVICE_FULL_NAME_FORMAT, SERVICE_NAME, assemblyName.FullName), false);
            if (commonServiceType == null)
            {
                throw new SdkProviderException();
            }

            return (ICommonService)Activator.CreateInstance(commonServiceType);
        }

        #endregion
    }
}
