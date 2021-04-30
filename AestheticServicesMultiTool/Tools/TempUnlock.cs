using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AestheticServicesMultiTool.Tools
{
    static class TempUnlock
    {
        public delegate void statusUpdate(eStatus e);
        public static event statusUpdate StatusUpdate;
        internal enum eStatus
        {
            ErrorInternetProblem = -2,
            ErrorPerrmisson = -1,
            Ready = 0,
            InstallingCertificastes,
            StartingProxy,
            StartedProxy,
            LaunchingGame,
            LaunchedGame
        }
        private static eStatus status = eStatus.Ready;
        private static eStatus setStatus
        {
            set
            {
                status = value;
                StatusUpdate(value);
            }
        }
        internal static eStatus Status { get => status; }


        internal static class Proxy
        {
            internal static void StartProxy()
            {
                //throw new NotImplementedException();
            }

            internal static void StopProxy()
            {
                //throw new NotImplementedException();
            }
        }

        internal static void LaunchGame()
        {
            //throw new NotImplementedException();
        }

    }
}
