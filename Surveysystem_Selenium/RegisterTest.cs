// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class RegisterTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void register() {
    driver.Navigate().GoToUrl("http://localhost:3000/home");
    driver.Manage().Window.Size = new System.Drawing.Size(1536, 824);
    driver.FindElement(By.CssSelector(".bg-orange-200")).Click();
    driver.FindElement(By.Name("userName")).Click();
    driver.FindElement(By.Name("userName")).SendKeys("Arun");
    driver.FindElement(By.Name("userEmail")).Click();
    driver.FindElement(By.Name("userEmail")).SendKeys("Arun@123gmail.com");
    driver.FindElement(By.Name("password")).Click();
    driver.FindElement(By.Name("password")).SendKeys("Arun@123");
    driver.FindElement(By.CssSelector(".active\\3Ascale-\\[\\.98\\]")).Click();
    Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("The Registeration is successfull. Your Userid is 32"));
    driver.Close();
    driver.FindElement(By.Name("userName")).Click();
    driver.FindElement(By.Name("userName")).SendKeys("Praveen");
    driver.FindElement(By.Name("userEmail")).Click();
    driver.FindElement(By.Name("userEmail")).SendKeys("Praveen@gmail.com");
    driver.FindElement(By.Name("password")).Click();
    driver.FindElement(By.Name("password")).SendKeys("Praveen@345");
    driver.FindElement(By.CssSelector(".active\\3Ascale-\\[\\.98\\]")).Click();
    Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("The Registeration is successfull. Your Userid is 33"));
  }
}
