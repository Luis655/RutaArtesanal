﻿using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.Domain
{
    public partial class Secretarium
    {
        public int Idsecretaria { get; set; }
        public string Username { get; set; }
        public int? Idlogin { get; set; }

        public virtual Usuario IdloginNavigation { get; set; }
    }
}
