using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;
using BarcodeStandard;
using QRCoder;
using System.Drawing;

namespace Nucleo.Operacoes.Aplicacao
{
    public static class CodigoBarras
    {
        public static Bitmap GenerateQRCode(string conteudo)
        {
            if (string.IsNullOrWhiteSpace(conteudo))
                return null;

            var fgColor = Color.Black;
            var bgColor = Color.White;

            QRCodeGenerator.ECCLevel eccLevel = QRCodeGenerator.ECCLevel.M;
            using (var qrGenerator = new QRCodeGenerator())
            {
                using (var qrCodeData = qrGenerator.CreateQrCode(conteudo, eccLevel))
                {
                    using (var qrCode = new PngByteQRCode(qrCodeData))
                    {
                        return  Nucleo.Base.Comum.Conversor.BytesToBitmap(qrCode.GetGraphic(4));
                    }
                }
            }
        }
    }
}
