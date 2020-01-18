using System;
using System.Collections.Generic;
using System.Text;

namespace KTApp.Core.Models
{
    public class DataSheet
    {
        public int Id { get; set; }

        // Can't use the same name as the enclosing class

        // public string DataSheet {get;set;}

        public string Name { get; set; }

        public ICollection<FactionDatasheet> FactionDatasheets { get; set; }
    }
}
