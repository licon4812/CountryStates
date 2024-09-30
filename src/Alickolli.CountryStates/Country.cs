using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Alickolli.CountryStates.Models;
using Newtonsoft.Json;

namespace Alickolli.CountryStates
{
    public class Country
    {
        internal static ICollection<Models.Country> Countries { get; set; } = LoadData();
        private static ICollection<Models.Country> LoadData()
        {
            var countries = new List<Models.Country>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames().Where(name => name.StartsWith("Alickolli.CountryStates.Data"));

            foreach (var resourceName in resourceNames)
            {
                using (var stream = assembly.GetManifestResourceStream(resourceName))
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    var country = JsonConvert.DeserializeObject<Models.Country>(json);
                    countries.Add(country);
                }
            }
            return countries;
        }

        // summary Returns all Countries
        public static ICollection<Models.Country> AllCountries()
        {
            return Countries;
        }

        /// <summary> Returns Country Name from countryCode, Accepts ISO2, ISO3 codes </summary>
        public static string Name(string countryCode)
        {
            var country = new RegionInfo(countryCode);
            return country.EnglishName;
        }

        /// <summary> Returns State Name from countryCode and stateCode. Accepts ISO2, ISO3 codes </summary>
        public static string StateName(string countryCode, string stateCode)
        {
            var state = Countries.FirstOrDefault(c => c.AltSpellings.Contains(countryCode))?.States.FirstOrDefault(s => s.Abbreviation == stateCode);
            return state?.Name;
        }

        /// <summary> Returns a collection of States by countryCode. Accepts ISO2 and ISO3 codes </summary>
        public static ICollection<State> States(string countryCode)
        {
            return Countries.FirstOrDefault(c => c.AltSpellings.Contains(countryCode))?.States;
        }

        /// <summary> Returns a state by countryCode and stateCode. Accepts ISO2 and ISO3 codes </summary>
        public static State State(string countryCode, string stateCode)
        {
            return Countries.FirstOrDefault(c => c.AltSpellings.Contains(countryCode))?.States.FirstOrDefault(s => s.Abbreviation == stateCode);
        }

        public static ICollection<State> Provinces(string countryCode)
        {
            return States(countryCode);
        }

        public static State Province(string countryCode, string stateCode)
        {
            return State(countryCode, stateCode);
        }

    }
}
