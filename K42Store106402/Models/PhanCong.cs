﻿using System;
using System.Collections.Generic;

namespace K42Store106402.Models
{
    public partial class PhanCong
    {
        public int MaPc { get; set; }
        public string MaNv { get; set; }
        public string MaPb { get; set; }
        public DateTime? NgayPc { get; set; }
        public bool? HieuLuc { get; set; }

        public NhanVien MaNvNavigation { get; set; }
        public PhongBan MaPbNavigation { get; set; }
    }
}
