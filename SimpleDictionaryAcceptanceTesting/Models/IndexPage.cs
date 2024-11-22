using Microsoft.Playwright;

namespace SimpleDictionaryAcceptanceTesting;

public class IndexPage
{
    private readonly IPage _page;
    private ILocator _table;

    public IndexPage(IPage page)
    {
        _page = page;
        _table = _page.Locator("table");
    }

    public string GetURL()
    {
        return _page.Url;
    }

    public async Task<bool> HasWordAsync(string word)
    {
        var trs = _table.Locator("tr"); // Get all the TRs
        var count = await trs.CountAsync(); // Count them
        var lastTR = trs.Nth(count - 1); // Get the last one
        var locator = lastTR.GetByText(word); // Get the word from this row
        count = await locator.CountAsync();
        return count == 1;

    }
}