using System;
using System.Collections.Generic;

namespace Fastfood.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethd = new HashSet<Chitiethd>();
        }
        //ok
        public int UserId { get; set; }
        public DateTime Ngaylap { get; set; }
        public decimal Tongtien { get; set; }
        public int HoadonId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Chitiethd> Chitiethd { get; set; }
    }
}
