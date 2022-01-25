fuck you riaa

# youtube-dl-gui
GUI for [youtube-dl](https://ytdl-org.github.io/youtube-dl/) (and forks) + [FFmpeg](https://ffmpeg.org/) (ffmpeg.exe & ffprobe.exe) which is used for converting.

The goal of youtube-dl-gui is to make it as accessible to as many people as possible, with as many arguments added as options as I use them... or get requested to add them. If at all.

Powerusers can use the custom arguments option to have almost absolute control of the input arguments, excepting the URL and the output.

The forks that are supported are [youtube-dl](https://github.com/ytdl-org/youtube-dl), [yt-dlc](https://github.com/blackjack4494/yt-dlc), and [yt-dlp](https://github.com/yt-dlp/yt-dlp). Additional forks can be added, by request.

# Prerequisites

This requires .NET Framework 4.5 or higher, the reasoning is because this program frequently uses Github's API which now only allows TLS 1.2, which isn't available on previous frameworks because... Microsoft. On the plus side, everything that isn't older than Windows 7 (bless up, Windows 7) supports it.

Sorry to Windows XP users, it's just the world we live in. Even though it's a terrible world, and one that I don't want to live in, it's the world we live in.

# Usage

**On first start, be sure to read the dialogs.**

This program won't run without youtube-dl being in either the same directory as youtube-dl-gui, or in the system's PATH. It's designed to download youtube-dl for you if it does not find one.

Downloading with custom formats and converting in any way will require FFmpeg, which you can download and put the files in "ffmpeg/bin/*.exe" in with the same directory as youtube-dl-gui or extract it anywhere and put the bin directory into your windows PATH.

The static paths for youtube-dl and ffmpeg may be set, which will allow you to select the executable, for youtube-dl, and/or the directory, for ffmpeg.

# Custom Arguments

When using custom arguments, the url and save directory are automatically passed, url being the first thing passed, followed by custom arguments, and the save-to directory being the final one passed.

Ex:  
* youtube-dl.exe https://awebsite.tld/video.html \<custom arguments> -o "C:\Users\User\Downloads\"  
* ffmpeg.exe -i "C:\Users\User\Downloads\VideoToConvert.ext" \<custom arguments> "C:\Users\User\Downloads\FileOutput.ext"

# Compatible sites

Each fork may have differences in compatible sites. It's recommended to do your own research. Or just try it, and see if it works. The worst that can happen is you blow up.

# Contributing

For anyone looking to translate, feel free to open a pull request with the new language file in the `Language` folder. Check if a language you're translating exists already, and you can edit it off of that.

For anyone looking to contribute to the code, make a pull request with the changed code.

# Future plans

things and stuff
