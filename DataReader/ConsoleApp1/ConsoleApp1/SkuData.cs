using System;
using DataExtensions.Attributes;

namespace ConsoleApp1
{
    [Table]
    public class SkuData
    {
        [Column]
        public string Stockcode { get; set; }

        [Column]
        public string Description { get; set; }

        [Column]
        public string QC13Ref { get; set; }

        [Column]
        public string Notes { get; set; } = "";

        [Column(Name = "STKState_ID")]
        public int StkStateId { get; set; }

        [Column]
        public double Mass { get; set; }
    }
}
