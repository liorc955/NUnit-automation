using extensions;
using NUnit.Allure.Attributes;
using utilities;

namespace workflows
{
    class APIFlows : CommponsOps
    {
        [AllureStep("Businees Flow: Get Book by ID")]
        public static void GetBook(string bookId) {
            APIActions.Get($"/BookStore/v1/Book?ISBN={bookId}");
        }

        [AllureStep("Businees Flow: Post Book to a userId")]
        public static void PostBook(string isbn)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary["userId"] = ManageDDT.GetDataFromXMLConfig("UserId"); ;
            dictionary["isbn"] = isbn;
            string payload = APIActions.CreateRequest(dictionary, ManageDDT.ReadFile("./JsonRequests/postBooksRequest.json"));
            Console.WriteLine(payload);
            APIActions.Post("/BookStore/v1/Books", payload);
        }

        [AllureStep("Businees Flow: Delete All the Books from a user")]
        public static void DeleteBooksOfUser()
        {
            APIActions.Delete($"/BookStore/v1/Books?UserId={ManageDDT.GetDataFromXMLConfig("UserId")}");
        }

        [AllureStep("Businees Flow: Update Existing book of a user")]
        public static void UpdateBook(string oldbook, string newbook)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary["userId"] = ManageDDT.GetDataFromXMLConfig("UserId");
            dictionary["isbn"] = newbook;
            string payload = APIActions.CreateRequest(dictionary, ManageDDT.ReadFile("./JsonRequests/updateBook.json"));
            Console.WriteLine(payload);
            APIActions.Put($"BookStore/v1/Books/{oldbook}", payload);

        }
    }
}
