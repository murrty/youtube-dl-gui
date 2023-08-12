namespace youtube_dl_gui; 
internal enum ArgumentType {
    NoArguments,
    
    DownloadVideo,
    DownloadAudio,
    DownloadCustom,

    DownloadAuthenticateVideo,
    DownloadAuthenticateAudio,
    DownloadAuthenticateCustom,

    DownloadVideoNoSound,
    DownloadAuthenticateVideoNoSound,

    DownloadArchived,
    DownloadArchivedNoSound,

    PushToForm,
    InstallProtocol,
}