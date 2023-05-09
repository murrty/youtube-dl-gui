namespace youtube_dl_gui; 
internal enum ArgumentType : int {
    NoArguments = 0,
    
    DownloadVideo = 1,
    DownloadAudio = 2,
    DownloadCustom = 3,

    DownloadAuthenticateVideo = 4,
    DownloadAuthenticateAudio = 5,
    DownloadAuthenticateCustom = 6,

    DownloadArchived = 7,

    PushToForm = 90,

    InstallProtocol = 91,
}