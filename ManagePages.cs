using PageObjects;

namespace utilities
{
    public class ManagePages : Base
    {
        public static void InitiateWebPages() {
            loginPage = new LoginPage(driver);
        }
    }
}
