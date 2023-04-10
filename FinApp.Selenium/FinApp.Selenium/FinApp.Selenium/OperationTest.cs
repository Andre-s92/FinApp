using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class OperationTest
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheUntitledTestCaseTest()
        {
            driver.Navigate().GoToUrl("http://localhost:4200/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Lista de Operações'])[1]/following::button[1]")).Click();
            driver.FindElement(By.Id("cnpj")).Click();
            driver.FindElement(By.Id("cnpj")).Clear();
            driver.FindElement(By.Id("cnpj")).SendKeys("11.111.111/1111-11");
            driver.FindElement(By.Id("nome")).Click();
            driver.FindElement(By.Id("nome")).Clear();
            driver.FindElement(By.Id("nome")).SendKeys("CLIENTE TESTE");
            driver.FindElement(By.Id("telefone")).Click();
            driver.FindElement(By.Id("telefone")).Clear();
            driver.FindElement(By.Id("telefone")).SendKeys("(11) 11111-1111");
            driver.FindElement(By.Id("cep")).Click();
            driver.FindElement(By.Id("cep")).Clear();
            driver.FindElement(By.Id("cep")).SendKeys("11111-111");
            driver.FindElement(By.Id("endereco")).Click();
            driver.FindElement(By.Id("endereco")).Clear();
            driver.FindElement(By.Id("endereco")).SendKeys("RUA TESTE");
            driver.FindElement(By.Id("estado")).Click();
            new SelectElement(driver.FindElement(By.Id("estado"))).SelectByText("Ceará");
            driver.FindElement(By.Id("cidade")).Click();
            driver.FindElement(By.Id("cidade")).Clear();
            driver.FindElement(By.Id("cidade")).SendKeys("CIDADE TESTE");
            driver.FindElement(By.Id("bairro")).Click();
            driver.FindElement(By.Id("bairro")).Clear();
            driver.FindElement(By.Id("bairro")).SendKeys("BAIRRO TESTE");
            driver.FindElement(By.Id("vencimento")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='April'])[1]/following::span[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sat'])[1]/following::span[12]")).Click();
            driver.FindElement(By.Id("desconto")).Click();
            driver.FindElement(By.Id("desconto")).Clear();
            driver.FindElement(By.Id("desconto")).SendKeys("R$20,000");
            driver.FindElement(By.Id("valor")).Click();
            driver.FindElement(By.Id("valor")).Clear();
            driver.FindElement(By.Id("valor")).SendKeys("R$80,000");
            driver.FindElement(By.Id("numero")).Click();
            driver.FindElement(By.Id("numero")).Clear();
            driver.FindElement(By.Id("numero")).SendKeys("ID 13405");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cadastro Manual'])[1]/following::button[1]")).Click();
            driver.FindElement(By.Id("cnpj")).Click();
            driver.FindElement(By.Id("cnpj")).Clear();
            driver.FindElement(By.Id("cnpj")).SendKeys("11.111.111/1111-11");
            driver.FindElement(By.Id("nome")).Click();
            driver.FindElement(By.Id("nome")).Clear();
            driver.FindElement(By.Id("nome")).SendKeys("CLIENTE TESTE");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancelar'])[1]/following::form[1]")).Click();
            driver.FindElement(By.Id("telefone")).Click();
            driver.FindElement(By.Id("telefone")).Clear();
            driver.FindElement(By.Id("telefone")).SendKeys("(11) 11111-1111");
            driver.FindElement(By.Id("cep")).Click();
            driver.FindElement(By.Id("cep")).Clear();
            driver.FindElement(By.Id("cep")).SendKeys("11111-111");
            driver.FindElement(By.Id("endereco")).Click();
            driver.FindElement(By.Id("endereco")).Clear();
            driver.FindElement(By.Id("endereco")).SendKeys("RUA TESTE");
            driver.FindElement(By.Id("estado")).Click();
            new SelectElement(driver.FindElement(By.Id("estado"))).SelectByText("Ceará");
            driver.FindElement(By.Id("cidade")).Click();
            driver.FindElement(By.Id("cidade")).Clear();
            driver.FindElement(By.Id("cidade")).SendKeys("CIDADE TESTE");
            driver.FindElement(By.Id("bairro")).Click();
            driver.FindElement(By.Id("bairro")).Clear();
            driver.FindElement(By.Id("bairro")).SendKeys("BAIRRO TESTE");
            driver.FindElement(By.Id("vencimento")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='April'])[1]/following::span[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sat'])[1]/following::span[12]")).Click();
            driver.FindElement(By.Id("desconto")).Click();
            driver.FindElement(By.Id("desconto")).Clear();
            driver.FindElement(By.Id("desconto")).SendKeys("R$30,000");
            driver.FindElement(By.Id("valor")).Click();
            driver.FindElement(By.Id("valor")).Clear();
            driver.FindElement(By.Id("valor")).SendKeys("R$100,000");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Valor Desconto'])[1]/following::div[1]")).Click();
            driver.FindElement(By.Id("numero")).Click();
            driver.FindElement(By.Id("numero")).Clear();
            driver.FindElement(By.Id("numero")).SendKeys("ID 1345093");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cadastro Manual'])[1]/following::button[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Remessa de Títulos para Análise'])[1]/following::button[1]")).Click();

        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
