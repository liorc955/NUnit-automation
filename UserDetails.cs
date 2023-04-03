using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace objects
{
    public class UserDetails
    {
        [Name("title")]
        public string Title { get; set; }
        [Name("initial")]
        public string Initial { get; set; }
        [Name("firstName")]
        public string FirstName { get; set; }
        [Name("middleName")]
        public string MiddleName { get; set; }
        [Name("gender")]
        public string Gender { get; set; }
        [Name("language")]
        public string Language { get; set; }
    }
}
