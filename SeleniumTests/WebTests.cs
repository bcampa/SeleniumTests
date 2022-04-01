using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeveMostrarAlertaParaErrosDeValidacaoNoLinkedin()
        {
            IWebDriver webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();

            webDriver.Url = "https://www.linkedin.com/";
            webDriver.Navigate();

            IWebElement submitButton = webDriver.FindElement(By.CssSelector(".sign-in-form-container .sign-in-form__submit-button"));
            Assert.IsNotNull(submitButton);
            
            submitButton.Click();
            IWebElement alert = webDriver.FindElement(By.ClassName("alert-content"));
            Assert.AreEqual("Please enter your email address or mobile number.", alert.Text);

            IWebElement sessionKeyInput = webDriver.FindElement(By.CssSelector(".sign-in-form-container #session_key"));
            sessionKeyInput.SendKeys("teste");
            submitButton.Click();
            Assert.AreEqual("Please enter a valid email address or mobile number.", alert.Text);

            webDriver.Quit();
        }

        [Test]
        public void DeveEncontrarUnaryPlusNaMdn()
        {
            IWebDriver webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();

            webDriver.Url = "https://developer.mozilla.org/";
            webDriver.Navigate();

            IWebElement searchInput = webDriver.FindElement(By.Id("hp-search-q"));

            searchInput.SendKeys("Unary plus");
            searchInput.Submit();

            var results = webDriver.FindElements(By.CssSelector(".search-results a"));

            Assert.IsNotEmpty(results);

            results[0].Click();

            Assert.AreEqual("https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/Unary_plus", webDriver.Url);

            webDriver.Quit();
        }

        [Test]
        public void DeveEncontrarRickRoll()
        {
            IWebDriver webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();

            webDriver.Url = "https://www.youtube.com/";
            webDriver.Navigate();

            IWebElement searchInput = webDriver.FindElement(By.CssSelector("#search-input #search"));

            searchInput.SendKeys("rick astley never gonna give you up");
            searchInput.Submit();

            IWebElement result = webDriver.FindElement(By.Id("video-title"));

            Assert.IsNotNull(result);

            result.Click();

            Assert.AreEqual("https://www.youtube.com/watch?v=dQw4w9WgXcQ", webDriver.Url);

            webDriver.Quit();
        }
    }
}