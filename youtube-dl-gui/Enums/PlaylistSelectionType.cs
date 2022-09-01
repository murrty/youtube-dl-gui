namespace youtube_dl_gui;
public enum PlaylistSelectionType : int {
    None = -1,
    PlaylistStartPlaylistEnd = 0,
    PlaylistItems = 1,
    DateBefore = 2,
    DateDuring = 3,
    DateAfter = 4
}