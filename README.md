# Gemini

[![Build status](https://ci.appveyor.com/api/projects/status/id45425lg618yc22?svg=true)](https://ci.appveyor.com/project/revam/gemini)

Original source code by ForeverZer0 and Zeus81 found at http://www.gdunlimited.net/forums/topic/7724-gemini-script-editor/.
Terms of use set by ForeverZer0 (found under Download at link above)

> Do to a lack of time to fix bugs, and for the benefit of others, I am open-sourcing Gemini, and I welcome anyone with knowledge of .NET to fix/add anything they wish, under the following conditions, which I respectfully ask be followed:
> - Gemini is to remain non-commercial
> - Original credit is to be given, although feel free to add yourself for any changes that are made
> - Please notify me if you decide to host it anywhere other than where I already have

## Introduction

Gemini, named after the Zodiac Twins (used in the RPG Maker series), is a feature-rich script editor designed purposefully for the RPG Maker community. It can directly read and write archived Scripts.r*data files, which allows you to use the power of an external IDE without the trouble of importing/exporting scripts to and from the built-in editor.


## Newly added features

- Project-based configuration
- Able to customize game executable and arguments
- Can restore last opened tabs per projects for faster production rate

# Known bugs of current release

- When you press Alt together with another key with "Auto-hide menu bar" on,
it toggles menu bar. As it should not.

## Features

- Uses the popular SciLexer library for syntax highlighting
- Custom color and font styles for parsing syntax
- Auto-Complete function to help improve productivity, letting you choose default words, or create your own list
- Auto-Indentation which follows standard Ruby conventions
- "Script-Structuring" to apply proper format to your script with the click of a button
- Batch comment/uncomment selected lines
- Line highlighter with custom style as an added visual guide
- Indentation guides for easily seeing the start/end of blocks
- Brace-matching for tracking down the elusive missing parenthesis...
- Powerful Find/Replace function, as well as incremental search
- Tabbed-style editor for quickly switching between open scripts
- Debug games directly from the editor, with a choice to run normally or in debug mode
- Character map for using special Unicode character sets
- Simple and intuitive interface
- Portable, no-install application
- Much more!

## Temporarily deprecated features

- Automatic updater built-in so you can make sure you have the latest version

## Tasks to do

- [ ] Get Appveyor on master branch to auto-deploy on each update
- [ ] Switch to ScintillaNet 3.5 (Newer, better, but a hassle to fix the incompatibles between current version)
- [ ] Add Drag and Drop functionality to the current Tree View or switch to a better one to view the scripxts.
- [ ] Add Ctrl+Tab/Ctrl+Shift+Tab shortcuts for switching for tabs
- [ ] Adapt the update methods to work with the new Git-Repo.
- [ ] Fix poor implementation of menu bar auto-hiding/-showing.

## Versioning
Version is defined as `MAJOR.MINOR.PATCH`, where:

1. `MAJOR` is increased when there is incompatible API changes,
2. `MINOR` is increased when backwards-compatible functionality is added, and
3. `PATCH` is increased when backwards-compatible bug fixes is added.

## Changes

See `CHANGELOG.md` for a list of changes.

## Compatibility
Requires Microsoft [.NET Framework 4 (Web Installer)](http://www.microsoft.com/en-us/download/details.aspx?id=17851).

## Licence
This project is licensed according to `LICENSE.md`.
