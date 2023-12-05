using System;
using System.Collections.Generic;

namespace Alickolli.CountryStates.Models
{
    public partial class State
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Country { get; set; }

        public List<string> AltSpellings { get; set; }
    }
}
