# youtube-dl-gui
GUI for [youtube-dl](https://rg3.github.io/youtube-dl) + [FFmpeg](https://ffmpeg.org/) (ffmpeg.exe & ffprobe.exe) (which is used for converting).

The goal of youtube-dl-gui is to make it as accessible to as many people as possible, which means a lot of power-user options aren't available in the general settings.

That doesn't mean that power users can't use it, either. I included custom arguments for anyone who wants to set their own for downloading or converting.

# Prerequisites
This requires .NET Framework 4.5 or higher, the reasoning is because this program frequently uses Github's API which now only allows TLS 1.2, which isn't available on previous frameworks because... Microsoft.

As soon as everything is settled, I can work on a more compatible version for < NET 4.5.

# Usage

**On first start, be sure to read the dialogs.**

This program won't run without youtube-dl being in either the same directory as youtube-dl-gui, or in the system's PATH. It's designed to download youtube-dl for you if it does not find one.

Downloading with custom formats and converting in any way will require FFmpeg, which you can download and put the files in "ffmpeg/bin/*.exe" in with the same directory as youtube-dl-gui or extract it anywhere and put the bin directory into your windows PATH.

The static paths for youtube-dl and ffmpeg may be set, which will allow you to select the executable, for youtube-dl, and/or the directory, for ffmpeg.

# Custom Arguments

When using custom arguments, the url and save directory are automatically passed, url being the first thing passed, followed by custom arguments, and the save-to directory being the final one passed.

Ex:  

youtube-dl.exe https://awebsite.tld/video.html <custom arguments> -o "C:\Users\User\Downloads\"  
ffmpeg.exe -i "C:\Users\User\Downloads\VideoToConvert.ext" <custom arguments> "C:\Users\User\Downloads\FileOutput.ext"

# Compatible sites

https://rg3.github.io/youtube-dl/supportedsites.html

# Future plans

stuff and things
