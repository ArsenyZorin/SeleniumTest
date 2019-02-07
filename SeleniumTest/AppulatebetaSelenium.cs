using System;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace MuranoTestProject
{
    [TestClass]
    public class AppulatebetaSelenium
    {
        [TestMethod]
        public void AppulatebetaSeleniumTest()
        {
            RemoteWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://appulatebeta.com/signup-old/intro.aspx/");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var js = (IJavaScriptExecutor) driver;

            //Main window
            driver.FindElementById(@"begin-registration-link").Click();

            //Registration Window Stage 1
            #region Registration Stage 1

            var txtCompanyName = driver.FindElementById(@"contentPlaceHolder_txtCompanyName");
            txtCompanyName.Clear();
            txtCompanyName.SendKeys("Company Name");
            var txtCompanyNameValue = txtCompanyName.GetAttribute("value");

            if (txtCompanyNameValue == "")
            {
                js.ExecuteScript("alert('Invalid Company name')");
                Thread.Sleep(1000);
                driver.SwitchTo().Alert().Accept();

                txtCompanyName.SendKeys("Company Name");
            }

            if (txtCompanyNameValue.Length > 128)
            {
                txtCompanyNameValue = txtCompanyNameValue.Substring(0, 128);
                txtCompanyName.Clear();
                txtCompanyName.SendKeys(txtCompanyNameValue);
            }
            

            var txtCompanyWebSite = driver.FindElementById(@"contentPlaceHolder_txtWebSite");
            txtCompanyWebSite.Clear();
            txtCompanyWebSite.SendKeys("www.compname.com");

            #region Primary Location

            const string name = @"contentPlaceHolder_locations_Location0_txtName";
            wait.Until(ExpectedConditions.ElementExists(By.Id(name)));

            var txtName = driver.FindElementById(name);
            txtName.Clear();
            txtName.SendKeys("Location Name");

            var txtStreetAdr1 = driver.FindElementById(@"contentPlaceHolder_locations_Location0_txtStreetAddress");
            txtStreetAdr1.Clear();
            var txtStreetAdr1Value = txtStreetAdr1.GetAttribute("value");

            if (txtStreetAdr1Value == "")
            {
                js.ExecuteScript("alert('Invalid address')");
                Thread.Sleep(1000);
                driver.SwitchTo().Alert().Accept();

                txtStreetAdr1.SendKeys("Primary address");
            }

            if (txtStreetAdr1Value.Length > 128)
            {
                txtStreetAdr1Value = txtStreetAdr1Value.Substring(0, 128);
                txtStreetAdr1.Clear();
                txtStreetAdr1.SendKeys(txtStreetAdr1Value);
            }

            var txtStreetAdr2 = driver.FindElementById(@"contentPlaceHolder_locations_Location0_txtStreetAddress2");
            txtStreetAdr2.Clear();

            var txtCity = driver.FindElementById(@"contentPlaceHolder_locations_Location0_txtCity");
            txtCity.Clear();
            txtCity.SendKeys("Praga");
            var txtCityValue = txtCity.GetAttribute("value");

            if (txtCityValue == "")
            {
                js.ExecuteScript("alert('Invalid city')");
                Thread.Sleep(1000);
                driver.SwitchTo().Alert().Accept();

                txtStreetAdr1.SendKeys("Salt Lake City");
            }

            if (txtCityValue.Length > 50)
            {
                var subscity = txtCityValue.Substring(0, 50);
                txtCity.Clear();
                txtCity.SendKeys(subscity);
            }

            var lstState = new SelectElement(driver.FindElementById(@"contentPlaceHolder_locations_Location0_lstState"));
            
            if (lstState.SelectedOption.Text == "--Select State--")
            {
                js.ExecuteScript("alert('Select state')");
                Thread.Sleep(1000);
                driver.SwitchTo().Alert().Accept();
                lstState.SelectByText("Utah");
            }
            
            var txtZip = driver.FindElementById(@"contentPlaceHolder_locations_Location0_txtZip");
            txtZip.Clear();
            txtZip.SendKeys("123456");
            var txtZipValue = txtZip.GetAttribute("value");

            if (txtZipValue == "")
            {
                js.ExecuteScript("alert('Invaid zip')");
                driver.SwitchTo().Alert().Accept();
                txtZip.SendKeys("57896153");
            }

            if (txtZipValue.Length > 50)
            {
                txtZipValue = txtZipValue.Substring(0, 50);
                txtZip.Clear();
                txtZip.SendKeys(txtZipValue);
            }

            var txtPhone = driver.FindElementById(@"contentPlaceHolder_locations_Location0_txtPhone");
            txtPhone.Clear();
            txtPhone.SendKeys("5000045496");
            var txtPhoneValue = txtPhone.GetAttribute("value");

            if (txtPhoneValue == "")
            {
                js.ExecuteScript("alert('Invaid zip')");
                Thread.Sleep(1000);
                driver.SwitchTo().Alert().Accept();
                txtPhone.SendKeys("57896153");
            }

            if (txtPhoneValue.Length > 100)
            {
                txtPhoneValue = txtPhoneValue.Substring(0, 100);
                txtPhone.Clear();
                txtPhone.SendKeys(txtPhoneValue);
            }

            var txtFax = driver.FindElementById(@"contentPlaceHolder_locations_Location0_txtFax");
            txtFax.Clear();
            var txtFaxValue = txtFax.GetAttribute("value");

            #endregion

            #region Checking Location 2
            driver.FindElementById(@"contentPlaceHolder_locations_btnAddNewLocation").Click();
            driver.FindElementById(@"contentPlaceHolder_locations_btnAddNewLocation").Click();

            const string name2 = @"contentPlaceHolder_locations_Location1_txtName";
            wait.Until(ExpectedConditions.ElementExists(By.Id(name2)));

            driver.FindElementById(name2).SendKeys("Name2");
            driver.FindElementById(@"contentPlaceHolder_locations_Location1_txtStreetAddress").SendKeys("Address 2");
            driver.FindElementById(@"contentPlaceHolder_locations_Location1_txtStreetAddress2").Clear();
            driver.FindElementById(@"contentPlaceHolder_locations_Location1_txtCity").SendKeys("Sacramento");
            new SelectElement(driver.FindElementById(@"contentPlaceHolder_locations_Location1_lstState")).SelectByText("California");
            driver.FindElementById(@"contentPlaceHolder_locations_Location1_txtZip").SendKeys("223456");
            driver.FindElementById(@"contentPlaceHolder_locations_Location1_txtPhone").SendKeys("7000045496");
            driver.FindElementById(@"contentPlaceHolder_locations_Location1_txtFax").Clear();
            
            driver.FindElementById("contentPlaceHolder_locations_Location1_btnDeleteLocation").Click();
            driver.SwitchTo().Alert().Accept();

            try
            {
                driver.FindElementById("contentPlaceHolder_locations_Location1_btnDeleteLocation").Click();
                driver.SwitchTo().Alert().Accept();

            }
            catch (Exception)
            {
                goto nextbtn;
            }
            #endregion

            nextbtn:
            var btnNext = driver.FindElementById(@"contentPlaceHolder_btnNext");
            btnNext.Click();
            #endregion

            //Registration. Stage 2

            #region Registration Stage 2

            const string fnameindex = @"ctl00_contentPlaceHolder_newUserInfoEditor_txtFirstName";

            wait.Until(ExpectedConditions.ElementExists(By.Id(fnameindex)));

            var txtFname = driver.FindElementById(fnameindex);
            txtFname.Clear();
            txtFname.SendKeys("Name");
            var txtFnameValue = txtFname.GetAttribute("value");
            var checkFname = !(txtFnameValue.Equals("") || txtFnameValue.Length > 16);

            var txtLname = driver.FindElementById(@"ctl00_contentPlaceHolder_newUserInfoEditor_txtLastName");
            txtLname.Clear();
            txtLname.SendKeys("Surname");
            var txtLnameValue = txtLname.GetAttribute("value");
            var checkLname = !(txtLnameValue.Equals("") || txtLnameValue.Length > 16);
            
            var txtPhone1 = driver.FindElementById(@"ctl00_contentPlaceHolder_newUserInfoEditor_txtPhone");
            txtPhone1.Clear();
            txtPhone1.SendKeys(txtPhoneValue);

            var txtFax1 = driver.FindElementById(@"ctl00_contentPlaceHolder_newUserInfoEditor_txtFax");
            txtFax1.Clear();
            txtFax1.SendKeys(txtFaxValue);

            var txtEmail = driver.FindElementById(@"ctl00_contentPlaceHolder_newUserInfoEditor_txtEmail");
            txtEmail.Clear();
            txtEmail.SendKeys("");
            var txtEmailValue = txtEmail.GetAttribute("value");
            const string cond = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            var checkemail = !(txtEmailValue.Equals("") || !Regex.IsMatch(txtEmailValue, cond) || txtEmailValue.Contains(" "));
           
            var txtEmailConf = driver.FindElementById(@"ctl00_contentPlaceHolder_newUserInfoEditor_txtSecondEmail");
            txtEmailConf.Clear();
            txtEmailConf.SendKeys(@"companyemail@host.com");
            var txtEmailConfValue = txtEmailConf.GetAttribute("value");
            var checkemailconf = !(!txtEmailConfValue.Equals(txtEmailValue) || txtEmailConfValue.Equals(""));

            var txtPassword = driver.FindElementById(@"ctl00_contentPlaceHolder_passwordControl_txtPassword");
            txtPassword.Clear();
            txtPassword.SendKeys(@"KoaL");
            var txtPasswordValue = txtPassword.GetAttribute("value");
            var checkpassw = !(txtPasswordValue.Length < 5 ||  txtPasswordValue.Contains(txtEmailValue));

            var txtPasswordConf = driver.FindElementById(@"ctl00_contentPlaceHolder_passwordControl_txtPasswordConfirm");
            txtPasswordConf.Clear();
            txtPasswordConf.SendKeys(@"KoaLaLoVeSeuQaLiPTus");
            var txtPasswordConfValue = txtPasswordConf.GetAttribute("value");
            var checkpasswconf = !(txtPasswordConfValue.Equals(txtPasswordValue) || txtPasswordConfValue.Equals(""));

            #endregion

            nextstage2:
            var btnNextStage2 = driver.FindElementByName(@"ctl00$contentPlaceHolder$btnNext");
            btnNextStage2.Click();

            if (!checkFname || !checkLname || !checkemail || !checkemailconf || !checkpassw || !checkpasswconf)
            {
                Thread.Sleep(1000);
                driver.SwitchTo().Alert().Accept();

                if (!checkFname)
                {
                    if (txtFnameValue.Equals(""))
                    {
                        txtFnameValue = "Name";
                        txtFname.Clear();
                        txtFname.SendKeys(txtFnameValue);
                    }

                    if (txtFnameValue.Length > 16)
                    {
                        txtFnameValue = txtFnameValue.Substring(0, 16);
                        txtFname.Clear();
                        txtFname.SendKeys(txtFnameValue);
                    }           
                    checkFname = true;
                }

                if (!checkLname)
                {
                    if (txtLnameValue.Equals(""))
                    {
                        txtLnameValue = "Surname";
                        txtLname.Clear();
                        txtLname.SendKeys(txtLnameValue);
                    }

                    if (txtLnameValue.Length > 16)
                    {
                        txtLnameValue = txtLnameValue.Substring(0, 16);
                        txtFname.Clear();
                        txtFname.SendKeys(txtLnameValue);
                    }
                    checkLname = true;
                }

                if (!checkemail)
                {
                    if (txtEmailValue.Equals(""))
                    {
                        txtEmailValue = @"companyemail@host.com";
                        txtEmail.Clear();
                        txtEmail.SendKeys(txtEmailValue);
                    }

                    if (txtEmailValue.Contains(" "))
                    {
                        txtEmailValue = txtEmailValue.Trim();
                        txtEmail.Clear();
                        txtEmail.SendKeys(txtEmailValue);
                    }

                    if (!Regex.IsMatch(txtEmailValue, cond))
                    {
                        txtEmailValue = @"companyemail@host.com";
                        txtEmail.Clear();
                        txtEmail.SendKeys(txtEmailValue);
                    }
                    checkemail = true;
                }

                if (!checkemailconf)
                {
                    if (txtEmailConfValue.Equals(""))
                    {
                        txtEmailValue = @"companyemail@host.com";
                        txtEmail.Clear();
                        txtEmail.SendKeys(txtEmailValue);
                    }

                    if (!txtEmailConfValue.Equals(txtEmailValue))
                    {
                        txtEmailConfValue = txtEmailValue;
                        txtEmailConf.Clear();
                        txtEmailConf.SendKeys(txtEmailConfValue);
                    }
                    checkemailconf = true;
                }

                if (!checkpassw)
                {
                    if (txtPasswordValue.Length < 5)
                    {
                        txtPasswordValue = "KoaLaLoVeSeuQaLiPTus";
                        txtPassword.Clear();
                        txtPassword.SendKeys(txtPasswordValue);
                    }

                    if (txtPasswordValue.Contains(txtEmailValue))
                    {
                        txtPasswordValue = "KoaLaLoVeSeuQaLiPTus";
                        txtPassword.Clear();
                        txtPassword.SendKeys(txtPasswordValue);
                    }
                    checkpassw = true;
                }

                if (!checkpasswconf)
                {
                    if (txtPasswordConfValue.Equals(""))
                    {
                        txtPasswordConfValue = "KoaLaLoVeSeuQaLiPTus";
                        txtPasswordConf.Clear();
                        txtPasswordConf.SendKeys(txtPasswordConfValue);
                    }

                    if (!txtPasswordConfValue.Equals(txtPasswordValue))
                    {
                        txtPasswordConfValue = txtPasswordValue;
                        txtPasswordConf.Clear();
                        txtPassword.SendKeys(txtPasswordConfValue);
                    }
                    checkpasswconf = true;
                }
                goto nextstage2;
            }
            driver.Quit();
        }
    }
}
