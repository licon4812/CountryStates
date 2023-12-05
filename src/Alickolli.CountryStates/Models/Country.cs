using System;
using System.Collections.Generic;
using System.Text;

namespace Alickolli.CountryStates.Models
{
    public partial class Country
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public List<string> AltSpellings { get; set; }

        public List<State> States { get; set; }
    }
}
