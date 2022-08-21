using Markdig.Syntax;
using Spectre.Console;

namespace Morello.Markdown.Console;

public partial class AnsiRenderer
{
    private void WriteThematicBreakBlock(ThematicBreakBlock thematicBreakBlock)
    {
        const char lineCharacter = '═';
        var charactersRequired = GetConsoleWidth() - 2;
        var line = new string(lineCharacter, charactersRequired);

        _console.MarkupLine($"[purple] {line}[/]");
    }
}
