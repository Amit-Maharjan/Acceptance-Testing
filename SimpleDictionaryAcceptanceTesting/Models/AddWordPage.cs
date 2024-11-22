using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDictionaryAcceptanceTesting.Models;

public class AddWordPage
{
    private readonly IPage _page;
    private readonly ILocator _textWord;
    private readonly ILocator _textMeaning;
    private readonly ILocator _submitCreate;
    private readonly ILocator _linkBack;
    private readonly string _url = "https://localhost:7044/Home/AddWord";

    public AddWordPage(IPage page)
    {
        _page = page;
        _textWord = _page.GetByLabel("Word");
        _textMeaning = _page.GetByLabel("Meaning");
        _submitCreate = _page.Locator(selector: "input[value=\"Create\"]");
        _linkBack = _page.Locator(selector: "text='Back to List'");
    }

    public async Task GotoAsync()
    {
        await _page.GotoAsync(_url);
    }

    public async Task InputWord(string word)
    {
        await _textWord.FillAsync(word);
    }

    public async Task InputMeaning(string meaning)
    {
        await _textMeaning.FillAsync(meaning);
    }

    public async Task PressCreate()
    {
        await _submitCreate.ClickAsync();
    }
}
