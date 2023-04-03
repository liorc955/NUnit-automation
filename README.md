
# Python Automation - nopCommerce Website & API Testing

In this project, I built a test automation framework for UI and API tests in C# using RestSharp, Selenium, and NUnit.



## Attached resources
- allure-results folder - contains all the test reports.
- TestData - contains the CSV file for the data-driven testing
- Configuration - contains an ini file that configures the browser, timeout, etc.. for the automation framework.


## Run Locally

Install dotnet:

https://dotnet.microsoft.com/en-us/download

Clone the project

```bash
  git clone https://github.com/liorc955/NUnit-automation.git
```

Go to the project directory

```bash
  cd NUnit-automation
```


Run the UI tests

```bash
dotnet test SeleniumTestProject.csproj --filter TestCategory=Sanity -- TestRunParameters.Parameter(name=\"browserName\", value=\"chrome\") -- TestRunParameters.Parameter(name=\"platformName\", value=\"web\")
```
Run the API tests

```bash
  dotnet test SeleniumTestProject.csproj --filter TestCategory=API -- TestRunParameters.Parameter(name=\"platformName\", value=\"api\")
```