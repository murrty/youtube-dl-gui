// ==UserScript==
// @name        reddit video download button
// @author      murrty
// @match       http*://*.reddit.com/r/*
// @grant       none
// @version     1.1
// @homepage    https://github.com/murrty/youtube-dl-gui
// @updateURL   https://github.com/murrty/youtube-dl-gui/raw/master/Addons/reddit%20video%20download%20button.user.js
// @downloadURL https://github.com/murrty/youtube-dl-gui/raw/master/Addons/reddit%20video%20download%20button.user.js
// @description Adds a "download video" button to the post.
// @run-at      document-end
// ==/UserScript==

// This only works on old.reddit.com.
// or if the old layout is enabled in the user settings.

var VideoPlayers = document.getElementsByClassName("reddit-video-player-root");
if (VideoPlayers.length > 0) {
    var Protocol = "ytdlgui:";
    var Url = " \"" + document.URL + "\"";
    var TagLines = document.getElementsByClassName("flat-list buttons");
    if (TagLines.length > 0 && TagLines[0] != null) {
        var VideoDownloadItem = document.createElement('li');
        var VideoLink = document.createElement('a');
        VideoLink.id = "download-video";
        VideoLink.title = "Downloads the video using youtube-dl-gui.";
        VideoLink.href = Protocol + "v" + Url;
        VideoLink.appendChild(document.createTextNode("download video"));
        VideoDownloadItem.append(VideoLink);

        var AudioDownloadItem = document.createElement('li');
        var AudioLink = document.createElement('a');
        AudioLink.id = "download-video-audio";
        AudioLink.title = "Downloads the videos audio using youtube-dl-gui.";
        AudioLink.href = Protocol + "a" + Url;
        AudioLink.appendChild(document.createTextNode("download audio"));
        AudioDownloadItem.append(AudioLink);

        var CustomDownloadItem = document.createElement('li');
        var CustomLink = document.createElement('a');
        CustomLink.id = "download-video-custom";
        CustomLink.title = "Downloads the video custom arguments using youtube-dl-gui.";
        CustomLink.href = Protocol + "c" + Url;
        CustomLink.appendChild(document.createTextNode("download custom"));
        CustomDownloadItem.append(CustomLink);

        TagLines[0].append(VideoDownloadItem);
        TagLines[0].append(AudioDownloadItem);
        TagLines[0].append(CustomDownloadItem);
    }
}
//else {
//    var VideoExpandObjects = document.getElementsByClassName("expando-button collapsed video") + document.getElementsByClassName("expando-button video expanded");
//    if (VideoExpandObjects.length > 0) {
//        console.log(VideoExpandObjects.length + " objects found");
//    }
//    else {
//        console.log("no video objects found");
//    }
//}
