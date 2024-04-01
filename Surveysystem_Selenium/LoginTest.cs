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
public class LoginTest {
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
  public void login() {
    driver.Navigate().GoToUrl("http://localhost:3000/");
    driver.Manage().Window.Size = new System.Drawing.Size(842, 824);
    driver.FindElement(By.Name("userEmail")).Click();
    driver.FindElement(By.Name("userEmail")).Click();
    driver.FindElement(By.Name("userEmail")).SendKeys("ashamold2002@gmail.com");
    driver.FindElement(By.Name("password")).Click();
    driver.FindElement(By.Name("password")).Click();
    driver.FindElement(By.Name("password")).SendKeys("ashaj@123");
    driver.FindElement(By.CssSelector(".active\\3Ascale-\\[\\.98\\]")).Click();
    driver.FindElement(By.CssSelector(".active\\3Ascale-\\[\\.98\\]")).Click();
  }
}