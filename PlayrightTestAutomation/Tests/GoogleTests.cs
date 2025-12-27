using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;



namespace PlaywrightTests
{
    [TestFixture]
    public class GoogleTests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;

        [SetUp]
        public async Task Setup()
        {

            

            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new() { Headless = false });

            var context = await _browser.NewContextAsync(); 

            _page = await context.NewPageAsync();
        }

        [Test]
        public async Task SearchGoogle()
        {

           
            await _page.GotoAsync("https://duckduckgo.com/");
           

            await _page.FillAsync("//*[@id='searchbox_input']", "Playwright C#");
            await _page.PressAsync("//*[@id='searchbox_input']", "Enter");
            await _page.WaitForSelectorAsync("h3");

            var firstResult = await _page.InnerTextAsync("h3");
            //Assert.(firstResult);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}
