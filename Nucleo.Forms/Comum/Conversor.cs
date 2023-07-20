using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Nucleo.Forms.Comum
{
    public static class Conversor
    {
        public static bool EnterToTab(char e)
        {
            if (e == (char)13)
            {
                SendKeys.Send("{tab}");
                return true;
            }
            else if (e == (char)39)
            {
                SendKeys.Send("{u}");
                SendKeys.Send("{BackSpace}");
                return true;
            }
            return false;
        }
    }
}
