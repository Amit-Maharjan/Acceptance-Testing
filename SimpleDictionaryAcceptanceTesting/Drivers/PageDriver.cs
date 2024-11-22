using Microsoft.Playwright;

[Binding]
public class PageDriver
{
    public IPage Page { get; private set; } = null!;

    [BeforeScenario]
    public async Task NewPage()
    {
        var playwright = await Playwright.CreateAsync();
        // Initialise a browser -
        // 'Chromium' can be changed to 'Firefox' or 'Webkit'
        var browser = await playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 500
            });
        var context = await browser.NewContextAsync();
        Page = await context.NewPageAsync();
    }
}
