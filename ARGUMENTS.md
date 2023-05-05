# Arguments
youtube-dl-gui supports arguments. Surprise, surprise. It's mostly to interact with userscripts to download from websites using easy to click buttons. All arguments can optionally have a hyphen `-` before the argument, but it is not required.

For protocol information, see the bottom of this markdown.

The following arguments are supported on version >= 3.3.0:

## Video
### `-v` or `-video`
Downloads a video that does not require authentication and is not archived or unavailable. Availablility may differ between websites and/or media requested. It's up to you to make sure it is supported.

### `-var` or `-varchive` or `-videoarchive`
Downloads a youtube video from an archive. View the youtube-dl forks README for information about archived videos which uses the `ytarchive:` argument.

### `-vau` or `-vauth` or `-videoauth`
Downloads a video using authentication to access the media. This will display the authentication window before downloading.

### `-vaa` or `-varchiveauth` or `-videoarchiveauth`
A possible future argument for archived data that may not use the `ytarchive` youtube-dl argument. This may or may not be removed in the future.

## Audio
### `-a` or `-audio`
Downloads audio that does not require authentication and is not archived or unavailable. Availablility may differ between websites and/or media requested. It's up to you to make sure it is supported.

### `-aar` or `-aarchive` or `-audioarchive`
Downloads youtube audio from an archive. View the youtube-dl forks README for information about archived videos which uses the `ytarchive:` argument.

### `-aau` or `-aauth` or `-audioauth`
Downloads audio using authentication to access the media. This will display the authentication window before downloading.

### `-aaa` or `-aarchiveauth` or `-audioarchiveauth`
A possible future argument for archived data that may not use the `ytarchive` youtube-dl argument. This may or may not be removed in the future.

# Protocol support
Optionally supported is browser protocols. You can also send arguments to the application through the use of protocols. The `ytdlgui` protocol will be used to forward arguments to youtube-dl-gui.

This mainly allows web browsers to run the application to download media. You can install the protocol within the application, and it supports all the arguments above. You can read more information about protocols [here](https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa767914(v=vs.85)).