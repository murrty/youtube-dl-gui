# youtube-dl-gui
GUI for [youtube-dl](https://rg3.github.io/youtube-dl) + [FFmpeg](https://ffmpeg.org/) (ffmpeg.exe & ffprobe.exe) (which is used for converting).

It is what youtube visual downloaders should be, not bloated with adware or viruses like other places and it downloads from Google's servers so it's (technically) safer than a 3rd party site that could leak your information.

# Prerequisites
This requires .NET Framework 4.5 or higher, the reasoning is because this program frequently uses Github's API which now only allows TLS 1.2, which isn't available on previous frameworks.

As soon as everything is settled, I can work on a more compatible version.

# Usage

**On first start, be sure to read the dialogs.**

This program won't run without youtube-dl being in either the same directory as youtube-dl-gui, or in the system's PATH. It's designed to download youtube-dl for you if it does not find one.

Downloading with custom formats and converting in any way will require FFmpeg, which you can download and put the files in "ffmpeg/bin/*.exe" in with the same directory as youtube-dl-gui or extract it anywhere and put the bin directory into your windows PATH.

The static paths for youtube-dl and ffmpeg may be set, which will allow you to select the executable, for youtube-dl, and/or the directory, for ffmpeg.

# Custom Arguments

When using custom arguments, the url and save directory are automatically passed, url being the first thing passed, followed by custom arguments, and the save-to directory being the final one passed.

This applies to downloads and vonersions.

# Compatible sites

https://rg3.github.io/youtube-dl/supportedsites.html

# Future plans

yes
