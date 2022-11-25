namespace murrty.controls;

using System;
using System.Text.RegularExpressions;

/// <summary>
/// Represents an event args that occurs when a regex match is found.
/// </summary>
public sealed class RegexMatchEventArgs : EventArgs {
    /// <summary>
    /// Gets the index in which the regex pattern is located.
    /// </summary>
    public int RegexPatternIndex {
        get;
    }
    /// <summary>
    /// Gets the Match value of the matched input.
    /// </summary>
    public Match Match {
        get;
    }
    /// <summary>
    /// Initializes a new RegexMatchEventArgs class.
    /// </summary>
    /// <param name="RegexPatternIndex">The int value index of the regex pattern value.</param>
    public RegexMatchEventArgs(int RegexPatternIndex) {
        this.RegexPatternIndex = RegexPatternIndex;
        Match = null;
    }
    /// <summary>
    /// Initializes a new RegexMatchEventArgs class.
    /// </summary>
    /// <param name="Match">The match object that contains data about the match.</param>
    public RegexMatchEventArgs(Match Match) {
        RegexPatternIndex = 0;
        this.Match = Match;
    }
}