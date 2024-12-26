using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

class Program
{
    static IWebDriver driver;
    static WebDriverWait wait;

    static void Main(string[] args)
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--no-sandbox"); // Disable sandbox
        options.AddArgument("--disable-dev-shm-usage"); // Prevent shared memory usage issues

        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        try
        {
            EnterUsername();
            EnterPassword();
            SelectLocation();
            SelectDates();
            PerformSearch();
            SelectHotel();
            SelectMap();
            SelectFavourites();
            SelectLanguage();
            SelectCurrency();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Test failed: {ex.Message}");
        }
        finally
        {
            //driver.Quit();
        }

    }

    static void EnterUsername()
    {
        driver.Navigate().GoToUrl("https://auth.trivago.com/tr");
        wait.Until(d => d.FindElement(By.Name("email"))).SendKeys("acarkaan2003@outlook.com");
        driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        Console.WriteLine("Step 1: Enter username - Passed");
    }

    static void EnterPassword()
    {
        wait.Until(d => d.FindElement(By.Name("password"))).SendKeys("Test123test");
        driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        Thread.Sleep(3000); // Wait for the login to complete
        Console.WriteLine("Step 2: Enter password - Passed");
    }

    static void SelectLocation()
    {
        driver.Navigate().GoToUrl("https://trivago.com/tr");
        Thread.Sleep(5000);
        wait.Until(d => d.FindElement(By.XPath("//*[@data-testid='search-form-destination']"))).SendKeys("Bursa");
        Console.WriteLine("Step 3: Location selection - Passed");
    }

    static void SelectDates()
    {
        driver.FindElement(By.XPath("//*[@data-testid='search-form-calendar-checkin']")).Click();
        Thread.Sleep(1000);
        driver.FindElement(By.XPath("//*[@data-testid='valid-calendar-day-2025-01-29']")).Click();
        driver.FindElement(By.XPath("//*[@data-testid='valid-calendar-day-2025-01-31']")).Click();
        Console.WriteLine("Step 4: Date selection - Passed");
    }

    static void PerformSearch()
    {
        driver.FindElement(By.XPath("//*[@data-testid='guest-selector-apply']")).Click();
        driver.FindElement(By.XPath("//*[@data-testid='search-button-with-loader']")).Click();
        Console.WriteLine("Step 5: Search functionality - Passed");
    }

    static void SelectHotel()
    {
        Thread.Sleep(2000);
        wait.Until(d => d.FindElement(By.XPath("(//button[@data-testid='champion-deal'])[1]"))).Click();
        Thread.Sleep(2000);
        Console.WriteLine("Step 6: Hotel selection functionality - Passed");
    }

    static void SelectMap()
    {
        Thread.Sleep(3000);
        wait.Until(d => d.FindElement(By.CssSelector("[data-testid='view-map-button']"))).Click();
        Console.WriteLine("Step 7: Map selection functionality - Passed");
    }

    static void SelectFavourites()
    {
        Thread.Sleep(2000);
        driver.Navigate().GoToUrl("https://trivago.com/tr");
        Thread.Sleep(2000);
        driver.FindElement(By.XPath("(//span[@class='Ji89fk'])[1]")).Click();
        Thread.Sleep(2000);
        Console.WriteLine("Step 8: Select Favourites - Passed");
    }

    static void SelectLanguage()
    {
        driver.FindElement(By.XPath("(//span[@class='Ji89fk'])[2]")).Click();
        Thread.Sleep(2000);
        IWebElement languageDropdown = wait.Until(d => d.FindElement(By.Id("language-select")));
        SelectElement languageSelect = new SelectElement(languageDropdown);
        languageSelect.SelectByIndex(0);
        Console.WriteLine("Step 9: Selected first language - Passed" + languageSelect.SelectedOption.Text);
    }

    static void SelectCurrency()
    {
        IWebElement currencyDropdown = wait.Until(d => d.FindElement(By.Id("currency-select")));
        SelectElement currencySelect = new SelectElement(currencyDropdown);
        currencySelect.SelectByIndex(0);
        Console.WriteLine("Step 10: Selected first currency - " + currencySelect.SelectedOption.Text);
        IWebElement applyButton = wait.Until(d => d.FindElement(By.CssSelector("button.Mnd902.Vau_Mq.tKTPp2[type='submit']")));
        applyButton.Click();
        Console.WriteLine("Step 10: Clicked 'Uygula' button - Passed");
    }
}