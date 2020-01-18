using System;
using System.Collections.Generic;
using System.Text;

namespace KTApp.Core.Models
{
    public class Faction
    {
        public int Id { get; set; }

        public string Name {get; set; }

        public string Keyword { get; set; }

        public ICollection<FactionDatasheet> FactionDatasheets { get; set; }
    }
}