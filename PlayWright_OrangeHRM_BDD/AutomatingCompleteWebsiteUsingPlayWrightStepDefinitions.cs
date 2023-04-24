using System;
using TechTalk.SpecFlow;
using Microsoft.Playwright;


namespace PlayWright_OrangeHRM_BDD
{
    [Binding]
    public class BasePage
    {
        private readonly Task<IPage> _Page;
        public BasePage() 
        {
            _Page = Initialize();
        }
        public IPage Page => _Page.Result;

        public async Task<IPage> Initialize()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 1, });

           return await browser.NewPageAsync();
        }


            [Given(@"Opening Website on Chromium")]
        public async Task GivenOpeningWebsiteOnChromium()
        {

            await Page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

        }

        [Given(@"Login with valid Credential and go to admin")]
        public async Task GivenLoginWithValidCredentialAndGoToAdmin()
        {
            await Page.GetByPlaceholder("Username").FillAsync("Admin");
            await Page.GetByPlaceholder("Password").FillAsync("admin123");
            await Page.ClickAsync("#app > div.orangehrm-login-layout > div > div.orangehrm-login-container > div > div.orangehrm-login-slot > div.orangehrm-login-form > form > div.oxd-form-actions.orangehrm-login-action > button");

        }

        [When(@"Admin is open press add to add data")]
        public async Task WhenAdminIsOpenPressAddToAddData()
        {
            await Page.ClickAsync("#app > div.oxd-layout > div.oxd-layout-navigation > aside > nav > div.oxd-sidepanel-body > ul > li:nth-child(1) > a");
            await Page.ClickAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div.orangehrm-paper-container > div.orangehrm-header-container > button");

        }

        [When(@"Add all the data one by one")]
        public async Task WhenAddAllTheDataOneByOne()
        {
            // User Role Entry
            await Page.ClickAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(1) > div > div:nth-child(2) > div > div");
            await Page.PressAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(1) > div > div:nth-child(2) > div > div", "ArrowDown");
            await Page.PressAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(1) > div > div:nth-child(2) > div > div", "ArrowDown");
            await Page.PressAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(1) > div > div:nth-child(2) > div > div", "Enter");

            // Employee Name Entry
            await Page.FillAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(2) > div > div:nth-child(2) > div > div > input", "a");
            Thread.Sleep(3000);
            await Page.PressAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(2) > div > div:nth-child(2) > div > div > input", "ArrowDown");
            await Page.PressAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(2) > div > div:nth-child(2) > div > div > input", "ArrowDown");
            await Page.PressAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(2) > div > div:nth-child(2) > div > div > input", "Enter");


            // Status Name Entry
            await Page.ClickAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(3) > div > div:nth-child(2) > div > div");
            await Page.PressAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(3) > div > div:nth-child(2) > div > div", "ArrowDown");
            await Page.PressAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(3) > div > div:nth-child(2) > div > div", "ArrowDown");
            await Page.PressAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(3) > div > div:nth-child(2) > div > div", "Enter");

            // Enter Username
            await Page.FillAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(4) > div > div:nth-child(2) > input", "Mujahid");

            // Enter Password
            await Page.FillAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.oxd-form-row.user-password-row > div > div.oxd-grid-item.oxd-grid-item--gutters.user-password-cell > div > div:nth-child(2) > input", "Mujahid+5");

            // Enter Confirm Password
            await Page.FillAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.oxd-form-row.user-password-row > div > div:nth-child(2) > div > div:nth-child(2) > input", "Mujahid+5");

        }

        [Then(@"Press SAVE and go to Username")]
        public async Task ThenPressSAVEAndGoToUsername()
        {
            Thread.Sleep(3000);
            //Submit Press
            await Page.ClickAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space");

        }

        [Then(@"Add name of person in search")]
        public async Task ThenAddNameOfPersonInSearch()
        {
            // Search User
            await Page.FillAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div.oxd-table-filter > div.oxd-table-filter-area > form > div.oxd-form-row > div > div:nth-child(1) > div > div:nth-child(2) > input", "Mujahid");

        }

        [Then(@"Press SEARCH")]
        public async Task ThenPressSEARCH()
        {
            Thread.Sleep(2000);
            //Search Press
            await Page.ClickAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div.oxd-table-filter > div.oxd-table-filter-area > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space");

        }

        [Then(@"Goto Pen symbol and Rename to new Name")]
        public async Task ThenGotoPenSymbolAndRenameToNewName()
        {
            Thread.Sleep(3000);


            await Page.GetByRole(AriaRole.Button, new() { Name = "" }).ClickAsync();
            // Editing Name
            await Page.Locator("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(4) > div > div:nth-child(2) > input").DblClickAsync();
            await Page.FillAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div:nth-child(4) > div > div:nth-child(2) > input", "Aadil");
        }

        [Then(@"Press SAVE")]
        public async Task ThenPressSAVE()
        {
            Thread.Sleep(2000);
            await Page.ClickAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space");

        }

        [Then(@"Search Name that you Entered")]
        public async Task ThenSearchNameThatYouEntered()
        {
            await Page.FillAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div.oxd-table-filter > div.oxd-table-filter-area > form > div.oxd-form-row > div > div:nth-child(1) > div > div:nth-child(2) > input", "aadil");
            Thread.Sleep(2000);
            await Page.ClickAsync("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div.oxd-table-filter > div.oxd-table-filter-area > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space");

        }

        [Then(@"Press DELETE")]
        public async Task ThenPressDELETE()
        {
            Thread.Sleep(2000);
            await Page.GetByRole(AriaRole.Button, new() { Name = "" }).ClickAsync();
        }

        [Then(@"Confim the deletion")]
        public async Task ThenConfimTheDeletion()
        {
            await Page.ClickAsync("#app > div.oxd-overlay.oxd-overlay--flex.oxd-overlay--flex-centered > div > div > div > div.orangehrm-modal-footer > button.oxd-button.oxd-button--medium.oxd-button--label-danger.orangehrm-button-margin");
            Thread.Sleep(5000);
        }


    }
}
