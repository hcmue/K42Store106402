﻿using System;
using System.Collections.Generic;

namespace K42Store106402.Models
{
    public partial class TrangWeb
    {
        public TrangWeb()
        {
            PhanQuyen = new HashSet<PhanQuyen>();
        }

        public int MaTrang { get; set; }
        public string TenTrang { get; set; }
        public string Url { get; set; }

        public ICollection<PhanQuyen> PhanQuyen { get; set; }
    }
}
