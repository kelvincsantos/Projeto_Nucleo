using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace Nucleo.Base.Comum
{
    public static class Conversor
    {

        public static Bitmap BytesToBitmap(byte[] e)
        {
            using (var ms = new MemoryStream(e))
            {
                return new Bitmap(ms);
            }
        }
    }
}
