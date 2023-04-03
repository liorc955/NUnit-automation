using CsvHelper;
using objects;
using System.Globalization;
using System.Xml;

namespace utilities
{
    public class ManageDDT
    {

        public static string ReadFile(string path) { 
            return File.ReadAllText(path);
        }

        public static string GetDataFromXMLConfig(string nodeName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("./Configuration/DataConfig.xml");
            XmlNodeList nodes = doc.GetElementsByTagName(nodeName);
            return nodes[0].InnerText;
        }

        private static IList<UserDetails> readCsv(string csvPath) {
            List<UserDetails> records;
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                 records = csv.GetRecords<UserDetails>().ToList();
            }
            return records;
        }


        public static IEnumerable<TestCaseData> AddTestDataConfig() {

            foreach (UserDetails user in readCsv(GetDataFromXMLConfig("ddtPath")))
                yield return new TestCaseData(user.Title, user.Initial, user.FirstName, user.MiddleName, user.Gender, user.Language);
        }

    }
}
