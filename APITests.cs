
using extensions;
using NUnit.Allure.Attributes;
using utilities;
using workflows;

namespace sanity
{
    [AllureSuite("API Tests")]
    [AllureEpic("Automation Testing API")]
    public class APITests : CommponsOps
    {
        [Test, Category("API")]
        [AllureStory("This test verifies getting the valid data for specific book")]
        public static void TestOne()
        {
            APIFlows.GetBook("9781449325862");
            var JSONResponse = APIActions.GetDeserializeResponse();
            Assert.That(JSONResponse.title.ToString(), Is.EqualTo("Git Pocket Guide"));
            Assert.That(JSONResponse.author.ToString(), Is.EqualTo("Richard E. Silverman"));
        }

        [Test, Category("API")]
        [AllureStory("This test verifies posting a new book to a userId")]
        public static void TestTwo()
        {
            APIFlows.DeleteBooksOfUser();
            APIFlows.PostBook("9781449325862");
            var JSONResponse = APIActions.GetDeserializeResponse();
            Assert.That(JSONResponse.books[0].isbn.ToString(), Is.EqualTo("9781449325862"));
            
        }

        [Test, Category("API")]
        [AllureStory("This test verifies the updating of exsiting book to a user")]
        public static void TestThree()
        {
            string newBook = "9781491950296";
            string oldBook = "9781449325862";
            APIFlows.UpdateBook(oldBook, newBook);
            var JSONResponse = APIActions.GetDeserializeResponse();
            Assert.That(JSONResponse.books[0].isbn.ToString(), Is.EqualTo(newBook));

        }

    }
}
