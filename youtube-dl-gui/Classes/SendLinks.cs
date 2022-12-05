namespace youtube_dl_gui;
using System.Runtime.InteropServices;
/// <summary>
/// Represents a simple text-only structure that contains a single string for downloading.
/// The string can contain multiple links joined with a pipe "|" character, and is 65,535 in length.
/// Pipe-allowed values can have "{{%OEMPIPE%}}" as a replacement which will be accounted for, eventually.
/// </summary>
/// <param name="Argument">The argument that contains data passed between instances of youtube-dl-gui.</param>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public record struct SendLinks([field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65_536)] string Argument);