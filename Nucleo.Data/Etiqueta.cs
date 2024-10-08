﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Data
{
    public class Etiqueta
    {
        public string ID { get; set; }
        public DateTime? DataCalibracao { get; set; }
        public DateTime? ProximaCalibracao { get; set; }
        public string NumeroCertificado { get; set; }
        public string DiretorioLaudo { get; set; }
        public string NumeroIdentificacao { get; set; }
        public string CodigoOrdemServico { get; set; }
        public string OrdemServico { get; set; }
    }
}
