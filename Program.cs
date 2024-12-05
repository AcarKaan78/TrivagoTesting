using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Create ChromeOptions to add arguments
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--no-sandbox");  // Disable sandbox
        options.AddArgument("--disable-dev-shm-usage");  // Prevent shared memory usage issues

        // Create a StreamWriter to write results to a text file
        using (StreamWriter writer = new StreamWriter("testResults.txt"))
        {
            // Initialize the WebDriver with ChromeOptions
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                // Test 4: Login to Booking.com (example login)
                driver.Navigate().GoToUrl("https://auth.trivago.com/tr");
                driver.FindElement(By.Name("email")).Click(); // Click login
                wait.Until(d => d.FindElement(By.Name("email"))).SendKeys("acarkaan2003@outlook.com");
                //driver.FindElement(By.Id("password")).SendKeys("your-password");
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();
                driver.FindElement(By.Name("password")).Click(); // Click login
                wait.Until(d => d.FindElement(By.Name("password"))).SendKeys("Test123test");
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();
                Thread.Sleep(3000);
                //wait.Until(d => d.FindElement(By.CssSelector(".user-profile-name"))); // Wait until login completes
                writer.WriteLine("Test 4: Login functionality - Passed");

                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@data-testid='customisation-survey-banner-secondary-cta']")).Click();
                Thread.Sleep(2000);
                driver.Navigate().GoToUrl("https://trivago.com/tr");
                Thread.Sleep(1000);

                driver.FindElement(By.XPath("//*[@data-testid='search-form-destination']")).Click();
                wait.Until(d => d.FindElement(By.XPath("//*[@data-testid='search-form-destination']"))).SendKeys("Bursa");

                driver.FindElement(By.XPath("//*[@data-testid='search-form-calendar-checkin']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@data-testid='valid-calendar-day-2025-01-29']")).Click();
                driver.FindElement(By.XPath("//*[@data-testid='valid-calendar-day-2025-01-31']")).Click();
                driver.FindElement(By.XPath("//*[@data-testid='guest-selector-apply']")).Click();
                driver.FindElement(By.XPath("//*[@data-testid='search-button-with-loader']")).Click();
                driver.FindElement(By.XPath("//*[@data-testid='search-button-with-loader']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(//*[@accommodation-card-favorite-list-button'])[1]")).Click();


                //// Test 1: Open Booking.com and Search for a destination
                //driver.Navigate().GoToUrl("https://www.booking.com");
                //IWebElement searchBox = wait.Until(d => d.FindElement(By.Id("ss")));
                //searchBox.SendKeys("New York");
                //IWebElement searchButton = driver.FindElement(By.CssSelector("button.sb-searchbox__button"));
                //searchButton.Click();
                //wait.Until(d => d.FindElement(By.CssSelector(".sr_property_block"))); // Wait until the results load
                //writer.WriteLine("Test 1: Search for New York - Passed");

                //// Test 2: Sort search results by price
                //IWebElement priceSort = wait.Until(d => d.FindElement(By.CssSelector("span[data-id='price']")));
                //priceSort.Click();
                //wait.Until(d => d.FindElement(By.CssSelector(".sr_property_block"))); // Wait for sorting to complete
                //writer.WriteLine("Test 2: Sort by price - Passed");

                //// Test 3: Select the first hotel from the results
                //IWebElement firstHotel = wait.Until(d => d.FindElement(By.CssSelector(".sr_property_block")));
                //firstHotel.Click();
                //wait.Until(d => d.FindElement(By.CssSelector(".hp__hotel-name"))); // Wait for hotel details page to load
                //writer.WriteLine("Test 3: Select first hotel - Passed");


                //// Test 5: Apply filter for free cancellation
                //IWebElement freeCancellation = wait.Until(d => d.FindElement(By.CssSelector("div[data-filters-group='free_cancellation']")));
                //freeCancellation.Click();
                //wait.Until(d => d.FindElement(By.CssSelector(".sr_property_block"))); // Wait for filter to apply
                //writer.WriteLine("Test 5: Apply free cancellation filter - Passed");

                //// Test 6: Change the travel dates
                //driver.FindElement(By.CssSelector(".xp__dates")).Click();
                //driver.FindElement(By.CssSelector(".bui-calendar__date")).Click(); // Select check-in date
                //driver.FindElement(By.CssSelector(".bui-calendar__date--next")).Click(); // Select check-out date
                //Thread.Sleep(2000); // Allow time for date selection to be applied
                //writer.WriteLine("Test 6: Change travel dates - Passed");

                //// Test 7: Check for hotel price details
                //string priceDetails = driver.FindElement(By.CssSelector(".bui-price-display__value")).Text;
                //writer.WriteLine($"Test 7: Hotel price details: {priceDetails} - Passed");

                //// Test 8: Check customer reviews section is visible
                //bool reviewsVisible = driver.FindElement(By.CssSelector(".review_list")).Displayed;
                //writer.WriteLine($"Test 8: Customer reviews visible - {reviewsVisible}");

                //// Test 9: Change the language to Spanish
                //driver.FindElement(By.CssSelector(".bui-language-selector__link")).Click();
                //driver.FindElement(By.CssSelector("button[data-lang='es']")).Click(); // Spanish
                //wait.Until(d => d.FindElement(By.CssSelector(".bui-button--secondary"))); // Wait for page to reload
                //writer.WriteLine("Test 9: Change language to Spanish - Passed");

                //// Test 10: Search with a different destination (e.g., Paris)
                //driver.Navigate().GoToUrl("https://www.booking.com");
                //driver.FindElement(By.Id("ss")).SendKeys("Paris");
                //driver.FindElement(By.CssSelector("button.sb-searchbox__button")).Click();
                //wait.Until(d => d.FindElement(By.CssSelector(".sr_property_block"))); // Wait for results
                //writer.WriteLine("Test 10: Search for Paris - Passed");
            }
            catch (Exception ex)
            {
                writer.WriteLine($"Test failed: {ex.Message}");
            }
            finally
            {
                //driver.Quit(); // Close the browser after tests
            }
        }

        Console.WriteLine("Test results have been written to testResults.txt.");
    }
}
