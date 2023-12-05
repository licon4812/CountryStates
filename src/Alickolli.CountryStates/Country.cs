using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Alickolli.CountryStates.Models;
using Newtonsoft.Json;

namespace Alickolli.CountryStates
{
    public class Country
    {
        /// <summary> Returns Country Name from countryCode, Accepts ISO2, ISO3 codes </summary>
        public static string Name(string countryCode)
        {
            var country = new RegionInfo(countryCode);
            return country.EnglishName;
        }

        /// <summary> Returns State Name from countryCode and stateCode. Accepts ISO2, ISO3 codes </summary>
        public static string StateName(string countryCode, string stateCode)
        {
            var region = new RegionInfo(countryCode);
            var fileName = region.EnglishName.Replace(" ", "_").ToLower();
            var file = new FileInfo($"./Data/{fileName}.json");
            var stream = file.OpenRead();
            var reader = new StreamReader(stream, Encoding.UTF8);
            var json = reader.ReadToEnd();
            var country = JsonConvert.DeserializeObject<Models.Country>(json);
            var state = country.States.Find(s => s.Abbreviation == stateCode);
            return state.Name;
        }

        /// <summary> Returns a collection of States by countryCode. Accepts ISO2 and ISO3 codes </summary>
        public static ICollection<State> States(string countryCode)
        {
            var region = new RegionInfo(countryCode);
            var fileName = region.EnglishName.Replace(" ", "_").ToLower();
            var file = new FileInfo($"./Data/{fileName}.json");
            var stream = file.OpenRead();
            var reader = new StreamReader(stream, Encoding.UTF8);
            var json = reader.ReadToEnd();
            var country = JsonConvert.DeserializeObject<Models.Country>(json);
            return country.States;
        }

        /// <summary> Returns a state by countryCode and stateCode. Accepts ISO2 and ISO3 codes </summary>
        public static State State(string countryCode, string stateCode)
        {
            var region = new RegionInfo(countryCode);
            var fileName = region.EnglishName.Replace(" ", "_").ToLower();
            var file = new FileInfo($"./Data/{fileName}.json");
            var stream = file.OpenRead();
            var reader = new StreamReader(stream, Encoding.UTF8);
            var json = reader.ReadToEnd();
            var country = JsonConvert.DeserializeObject<Models.Country>(json);
            return country?.States.FirstOrDefault(s => s.Abbreviation == stateCode);
        }

        public static ICollection<State> Provinces(string countryCode, string stateCode)
        {
            var region = new RegionInfo(countryCode);
            var fileName = region.EnglishName.Replace(" ", "_").ToLower();
            var file = new FileInfo($"./Data/{fileName}.json");
            var stream = file.OpenRead();
            var reader = new StreamReader(stream, Encoding.UTF8);
            var json = reader.ReadToEnd();
            var country = JsonConvert.DeserializeObject<Models.Country>(json);
            return country.States;
        }

        public static State Province(string countryCode, string stateCode)
        {
            var region = new RegionInfo(countryCode);
            var fileName = region.EnglishName.Replace(" ", "_").ToLower();
            var file = new FileInfo($"./Data/{fileName}.json");
            var stream = file.OpenRead();
            var reader = new StreamReader(stream, Encoding.UTF8);
            var json = reader.ReadToEnd();
            var country = JsonConvert.DeserializeObject<Models.Country>(json);
            return country?.States.FirstOrDefault(s => s.Abbreviation == stateCode);
        }

    }
}
