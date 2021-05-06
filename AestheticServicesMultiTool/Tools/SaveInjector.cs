using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AestheticServicesMultiTool.Tools
{
    static class SaveInjector
    {
        private static int userID = -1;
        internal static int UserID { get => userID; }

        internal static bool GetSave(string cookie, string path)
        {
            return true;
            //throw new NotImplementedException();
        }
        internal static bool Inject(string path)
        {
            return true;
            //throw new NotImplementedException();
        }
    }
}
