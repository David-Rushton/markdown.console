# Release Notes

## `v1.6.0`

We've improved our [Nerd Fonts](https://www.nerdfonts.com/) support.

Previously Nerd Fonts where enabled by default.  Which Nerd Fonts are awesome, no al fonts support the
full range of glyphs.  This led to ugly fallbacks.

## Examples

Let's look at three examples, which all use this markdown:

```md
## With Nerd Fonts

To enable Nerd Fonts: `MarkdownConsole.UseNerdFonts(UseNerdFonts.Yes)`.

> *Nerd Fonts* patches developer targeted fonts with a high number of glyphs (icons).

Number List: 
1. Item 1
1. Item 2
1. Item 3

To Do List: 
- [ ] Item 1
- [x] Item 2
- [ ] Item 3

Bullet List:
- Bullet 1
- Bullet 2
- Bullet 3
```

### Nerd Fonts Enabled But Not Supported

As you can see we don't fallback gracefully.  

Our numbered lists, bullet lists and to do lists all look the same.  The numbered list has lost it numbers - arguably the most important bit!

Inline code is pre and postfixed with your font's default fallback glyph.

![Nerd Fonts enabled and not supported](../../images/examples/nerd-fonts-enabled-not-supported.png)

### Nerd Fonts Disabled

Our new default.  We stick to characters from the standard and extended ASCII table.  This should be supported by virtually all fonts.

Lists and inline code have been restored.

We have also picked a different quote glyph.  This one has wider support.  

![Nerd Fonts disabled](../../images/examples/nerd-fonts-disabled.png)

### With Nerd Fonts Enabled and Supported

You can still opt-in to Nerd Fonts.

To do lists and inline code blocks make great use of the extended glyph set.

![Nerd Fonts endabled and supported](../../images/examples/nerd-fonts-enabled-and-supported.png)

To enable Nerd Fonts:

1. [Install](https://www.nerdfonts.com/font-downloads) a supported font
1. Enable: `MarkdownConsole.UseNerdFonts(UseNerdFonts.Yes);`

## `v1.5.0`

We have added support for [auto links](https://spec.commonmark.org/0.30/#autolinks).

![auto link screen shot](../../images/examples/auto-link-example.png)

## `v1.4.0`

We've added support for [`.NetStandard 2.0`](https://docs.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0)!
We've always supported `.Net 6.0`.  Now you can use these additional `.Net` implementations & versions:

- .Net 5.0
- .Net Core 3.1
- .Net Core 3.0
- .Net Core 2.2
- .Net Core 2.1
- .Net Core 2.0
- .Net Framework 4.8
- .Net Framework 4.7.2
- .Net Framework 4.7.1
- .Net Framework 4.7
- .Net Framework 4.6.2
- .Net Framework 4.6.1
- Mono 6.4
- Mono 5.4
- Xamarin.iOS 12.16
- Xamarin.iOS 10.14
- Xamarin.Mac 5.16
- Xamarin.Mac 3.8
- Xamarin.Android 10.0
- Xamarin.Android 8.0
- Universal Windows Platform 10.0.16299
- Unity 2018.1

We now include these release notes in our NuGet package.

## `v1.3.2`

We've added our logo to NuGet.

## `v1.3.1`

Bug fix.  We failed to print the final character when falling back to plain text.

## `v1.3.0`

This release contains mostly internal changes.

Our test suite now runs in Rider.  Previously all tests failed in Rider because we incorrectly detected the level of Ansi escape code support.  

We've improved how we fallback to plain text.  The previous approach proved to be too complex.  We now fallback - or fail if in test mode.

## `v1.2.0`

Internal changes only.

We've moved a few things around to simplify future changes.

## `v1.1.0`

### Plain Text Fallback

`MarkdownConsole` now falls back to plain text for any unsupported markdown elements.  Previously we
threw an exception or printed an ugly warning message.  This was bad for two reasons:

- Mixing exceptions and printed warnings is inconsistent
- If we do not support a type we shouldn't omit the content

`MarkdownConsole` is now a best effort renderer.  It will always print all of the text passed to it.
Where we can we will format it.  Where we cannot we will print plain text.

A future update will introduce a callback/logger/return value that informs the caller where and why
we have fallen back to plain text.  That is still in the planning.  However I expect this to be available
in the next few updates.

### Other Changes

We've added support for:

- Thematic breaks  
  `***`, `---` or `___` adds a horizontal line.

- Image Links  
  Format: `![fallback text](file_path_or_url_to_image).  
  See below for more details.  

- Embedded inlines  
  You can now embed inline styles within each other.  
  Example: `**bold text with _bold and italic_ section**`.  

And we've fixed a few bugs:

- 🐛 Incorrect multiline quotes  
  Quotes are prefixed with a space and a horizontal chevron.  
  Multiline quotes omitted the space on the 2nd and subsequent lines.  

- 🐛 Test runners could crash
  We didn't support the case where `MarkdownConsole` was not attached to a terminal.

### Image Links

Powered by the amazing [ImageSharp](https://github.com/SixLabors/ImageSharp); we support the
following:

- TIFF
- BMP
- PNG
- JPEG
- GIF
- PBM
- TGA
- Webp

## `v1.0.2`

Improved README.

I want to warn users that this library is very new, and still in pre-release.

## `v1.0.1`

Small bug fixes.

## `v1.0.0`

We have a project name - `Morello`!

I've moved the `MarkdownConsole` into a our top-level namespace.

```cs
using Morello;

MarkdownConsole.Write("# Markdown");
```

## `v.0.3.0`

Titles are now rendered left-aligned.  Previously centre-aligned.  Centre alignment didn't look great
in wide terminals.  The heading looked detected from the content.  Left alignment ensures the heading
appears above the content.

## `v.0.2.0`

We have added unit tests.

## `v.0.1.0`

Big Bang!

Converts markdown to beautifully formatted terminal output.

```csharp
using Markdown.Console;

MarkdownConsole.Write(@"
# Markdown Console

Some content that includes *bold*, _italic_ and ~strikethrough~ text.

We support:

- Tables
- Fenced code blocks
- Quotes
- Lists

Syntax highlighting is available if you have [Bat](https://github.com/sharkdp/bat) on your path.
");

```

> ⚠️ Warning ⚠️
> We used [Nerd Fonts](https://www.nerdfonts.com/) when rendering to the console.  If your font doesn't support the fall range of characters some elements may not render correctly.
