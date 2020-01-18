using System;
using System.Collections.Generic;
using System.Text;

namespace KTApp.Core.Models
{
    public class FactionDatasheet
    {
        public int Id { get; set; }

        public int FactionId { get; set; }

        public int DataSheetId { get; set; }

        public Faction Faction { get; set; }

        public DataSheet DataSheet { get; set; }
    }
}
