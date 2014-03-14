/* Лицензионное соглашение на использование набора средств разработки
 * «SDK Яндекс.Диска» доступно по адресу: http://legal.yandex.ru/sdk_agreement
 */

using System;
using System.Reflection;

namespace Disk.SDK.CommonServices
{
    /// <summary>
    /// Represents entry point for common service.
    /// </summary>
    public static class CommonServiceManager
    {
        /// <summary>
        /// Manager's CommonService creator.
        /// </summary>
        public static ICommonServiceCreator ServiceCreator = new DefaultCommonServiceCreator();

        private static ICommonService commonService;

        /// <summary>
        /// Creates the platform specific common service instance.
        /// </summary>
        /// <returns>The common service implementation.</returns>
        private static ICommonService CreateService()
        {
            return ServiceCreator.Create();
        }

        /// <summary>
        /// Gets the platform specific common service instance.
        /// </summary>
        /// <value>
        /// The common service instance.
        /// </value>
        public static ICommonService CommonService
        {
            get
            {
                return commonService ?? (commonService = CreateService());
            }
        }
    }
}