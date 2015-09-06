# Gemini [![Build status](https://ci.appveyor.com/api/projects/status/slt527oxp8ey995f/branch/master?svg=true)](https://ci.appveyor.com/project/revam/gemini/branch/master)
Original source code by ForeverZer0 and Zeus81 found at http://www.gdunlimited.net/forums/topic/7724-gemini-script-editor/.

Terms of use set by ForeverZer0 (found under Download at link above)
> Do to a lack of time to fix bugs, and for the benefit of others, I am open-sourcing Gemini, and I welcome anyone with knowledge of .NET to fix/add anything they wish, under the following conditions, which I respectfully ask be followed:
> - Gemini is to remain non-commercial
> - Original credit is to be given, although feel free to add yourself for any changes that are made
> - Please notify me if you decide to host it anywhere other than where I already have

## Introduction
Gemini, named after the Zodiac Twins (RMXP/RMVX)(and now VX Ace!), is a feature-rich script editor designed purposefully for the RPG Maker community. It can directly read and write archived Scripts.r*data files, which allows you to use the power of an external IDE without the trouble of importing/exporting scripts to and from the built-in editor.

## Features
- Uses the popular SciLexer library for syntax highlighting
- (New) Able to customize game-runtime for custom projects
- (New) Able to save project-based configuration
- Custom color and font styles for parsing Ruby syntax
- Auto-Complete function to help improve productivity, letting you choose default words, or create your own list
- Auto-Indentation which follows standard Ruby conventions
- "Script-Structuring" to apply proper format to your script with the click of a button
- Batch comment/uncomment selected lines
- Line highlighter with custom style as an added visual guide
- Indentation guides for easily seeing the start/end of blocks
- Brace-matching for tracking down the elusive missing parenthesis...
- Powerful Find/Replace function, as well as incremental search
- Tabbed-style editor for quickly switching between open scripts
- Automatic updater built-in so you can make sure you have the latest version
- Debug games directly from the editor, with choice to run normally or in DEBUG/TEST mode
- Character map for using special Unicode character sets
- Simple and intuitive interface
- Portable, no-install application
- Much more!

## TODO
- Move to ScintillaNet 3.5
- Adapt the update methods to work with the new GitHub-Repo.

## Changelog
### Changes from 2.0.0 to 3.0.0
- Removed the Splash screen
- Added Fody and Fody Costura
- Compressed and integrated and all dll-libraries into assembly
- Changed settings save format to xml
- Implemented project-based settings (does not work on r*data)
  - Stores last opened scripts, debug mode and custom runtime parameters
- Rewrite the script-handeling API and related methods
  - Removed the list-view and related methods
  - Added a new tree-view and related methods
  - Faster save and load time
- Made the UI to be more flexible
- Improved import - will now import under currently selected script or group or in the 'Materials' group if present
- Added a project scripts folder and related methods
- Added quick import from/export to project scripts folder
- Added customization to game-runtime
- Updated the help-files, data- and dll-library for XP and VXAce to the latest english ones
- Updated folder icons
- Temporarily disabled update functionality
- Minor changes not stated above

See `Changelog.html` for a more detailed list of changes.

## Compatibility
Requires Microsoft [.NET Framework 4 (Web Installer)](http://www.microsoft.com/en-us/download/details.aspx?id=17851).

## Licence
This project is licenced under the GNU General Public Licence v.3.0 found both in `licence.txt` and at http://www.gnu.org/licenses/gpl-3.0.txt
