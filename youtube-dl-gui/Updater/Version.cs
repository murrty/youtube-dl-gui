namespace youtube_dl_gui.updater;

using System.Text.RegularExpressions;

/// <summary>
/// Represents a modified Version.
/// </summary>
[System.Diagnostics.DebuggerStepThrough]
public struct Version {
    /// <summary>
    /// Contains an empty Version with no version information relevant.
    /// </summary>
    [NonSerialized]
    public static readonly Version Empty = new(0, 0, 0, 0);

    /// <summary>
    /// The major of the version.
    /// </summary>
    public byte Major { get; init; }
    /// <summary>
    /// The minor of the version.
    /// </summary>
    public byte Minor { get; init; }
    /// <summary>
    /// The revision of the version.
    /// </summary>
    public byte Revision { get; init; }
    /// <summary>
    /// The beta number of the version.
    /// </summary>
    public byte Beta { get; init; }
    /// <summary>
    /// Whether the version is a beta version.
    /// </summary>
    public bool IsBeta => Beta != 0;

    /// <summary>
    /// Initializes a new <see cref="Version"/> structure for defining the current application version.
    /// </summary>
    /// <param name="Major">The major version of the release.</param>
    /// <param name="Minor">The minor version of the release.</param>
    /// <param name="Revision">The revision of the release.</param>
    public Version(byte Major, byte Minor, byte Revision) {
        this.Major = Major;
        this.Minor = Minor;
        this.Revision = Revision;
        Beta = 0;
    }
    /// <summary>
    /// Initializes a new <see cref="Version"/> structure for defining the current application version.
    /// </summary>
    /// <param name="Major">The major version of the release.</param>
    /// <param name="Minor">The minor version of the release.</param>
    /// <param name="Revision">The revision of the release.</param>
    /// <param name="BetaVersion">The beta version of the release.</param>
    public Version(byte Major, byte Minor, byte Revision, byte BetaVersion) {
        this.Major = Major;
        this.Minor = Minor;
        this.Revision = Revision;
        this.Beta = BetaVersion;
    }
    /// <summary>
    /// Initializes a new <see cref="Version"/> structure for defining the current application version.
    /// </summary>
    /// <param name="Data">The version string that is parsed through.
    /// <para>Example strings are: "1.0.1" and "1.0.1-1" with limited support for "1.01" and "1.01-pre1".</para>
    /// </param>
    public Version(string Data) => ToVersion(Data);

    /// <summary>
    /// Converts a string representation of the <see cref="Version"/> to a structure with the data.
    /// </summary>
    /// <param name="Data">The string data to convert.</param>
    /// <returns>A new <see cref="Version"/> structure filled with relevant information.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static Version ToVersion(string Data) =>
        TryParseNew(Data, out Version vers) ? vers : throw new ArgumentException($"Data {Data} is not a valid version to parse.");
    [Obsolete("The old values of the version will be removed after a release.")]
    public static Version ToVersionFromOld(string OldVersion) =>
        TryParseOld(OldVersion, out Version vers) ? vers : throw new ArgumentException($"Data {OldVersion} is not a valid version to parse.");
    /// <summary>
    /// Tries to parsre a string value to a <see cref="Version"/> structure representing the data.
    /// </summary>
    /// <param name="Data">The string value to convert.</param>
    /// <param name="vers">The output <see cref="Version"/> structure.</param>
    /// <returns><see langword="true"/> if the parse was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse(string Data, out Version vers) {
        if (Regex.IsMatch(Data, "^[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}(-[0-9]{1,3})?$")) {
            if (TryParseNew(Data, out Version overs)) {
                vers = overs;
                return true;
            }
        }
        else if (Regex.IsMatch(Data, "^[0-9]{1}.[0-9]{1,3}(-pre[0-9]{1})?$")) {
            if (TryParseOld(Data, out Version overs)) {
                vers = overs;
                return true;
            }
        }

        vers = Empty;
        return false;
    }
    [Obsolete("The old values of the version will be removed after a release which will make this method invalid.")]
    public static bool TryParseNew(string Data, out Version vers) {
        if (Data.IsNullEmptyWhitespace()) {
            vers = Empty;
            return false;
        }

        if (Data[0] == 'v')
            Data = Data[1..];

        if (Regex.IsMatch(Data, "^[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}$")) {
            string[] Parts = Data.Split('.');

            if (Parts.Length == 3 && byte.TryParse(Parts[0], out byte maj)
            && byte.TryParse(Parts[1], out byte min) && byte.TryParse(Parts[2], out byte rev)) {
                vers = new(maj, min, rev, 0);
                return true;
            }
            else {
                vers = Empty;
                return false;
            }
        }
        else if (Regex.IsMatch(Data, "^[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}-[0-9]{1,3}$")) {
            string[] Parts = Data.Split('.');
            string[] RevisionAndBeta = Parts[2].Split('-');

            if (Parts.Length == 3 && RevisionAndBeta.Length == 2 &&
            byte.TryParse(Parts[0], out byte maj) && byte.TryParse(Parts[1], out byte min) &&
            byte.TryParse(RevisionAndBeta[0], out byte rev) && byte.TryParse(RevisionAndBeta[1], out byte beta)) {
                vers = new(maj, min, rev, beta);
                return true;
            }
            else {
                vers = Empty;
                return false;
            }
        }
        else {
            vers = Empty;
            return false;
        }
    }
    [Obsolete("The old values of the version will be removed after a release.")]
    public static bool TryParseOld(string OldVersion, out Version vers) {
        if (OldVersion.IsNullEmptyWhitespace()) throw new ArgumentException($"Data is null, empty, or whitespace.");
        if (Regex.IsMatch(OldVersion, "^[0-9]{1}.[0-9]{1,3}$")) {
            if (OldVersion.Length < 2) {
                vers = Empty;
                return false;
            }
            byte Major = 0;
            byte Minor = 0;
            byte Rev = 0;
            byte Beta = 0;

            for (int i = 0; i < OldVersion.Length; i++) {
                switch (i) {
                    case 0: {
                        Major = byte.Parse($"{OldVersion[i]}");
                    } break;

                    case 2: {
                        Minor = byte.Parse($"{OldVersion[i]}");
                    } break;

                    case 3: {
                        Rev = byte.Parse($"{OldVersion[i]}");
                    } break;

                    case 4: {
                        Beta = byte.Parse($"{OldVersion[i]}");
                        vers = new(Major, Minor, Rev, Beta);
                    } return true;

                    case > 4: {
                        vers = new(Major, Minor, Rev, Beta);
                    } return true;
                }
            }
            vers = new(Major, Minor, Rev, Beta);
            return true;
        }
        else if (Regex.IsMatch(OldVersion, "^[0-9]{1}.[0-9]{1,3}-pre[0-9]{1}$")) {
            string[] Parts = OldVersion.Split('-');
            Parts[1] = Parts[1].Replace("pre", "");

            string CurrentParse = Parts[0];
            if (CurrentParse.Length < 2 || Parts[1].Length < 1) {
                vers = Empty;
                return false;
            }

            byte Major = 0;
            byte Minor = 0;
            byte Rev = 0;

            for (int i = 0; i < CurrentParse.Length; i++) {
                switch (i) {
                    case 0: {
                        Major = byte.Parse($"{Parts[0][i]}");
                    } break;
                    case 2: {
                        Minor = byte.Parse($"{Parts[0][i]}");
                    } break;
                    case 3: {
                        Rev = byte.Parse($"{Parts[0][i]}");
                    } break;
                }
            }

            byte Beta = byte.Parse($"{Parts[1][0]}");

            vers = new(Major, Minor, Rev, Beta);
            return true;
        }
        vers = Empty;
        return false;
    }

    /// <inheritdoc/>
    public override string ToString() => $"{Major}.{Minor}.{Revision}{(IsBeta ? $"-{Beta}" : "")}";

    /// <inheritdoc/>
    public override bool Equals(object obj) =>
        obj is Version version && Major == version.Major && Minor == version.Minor && Revision == version.Revision && Beta == version.Beta;

    /// <inheritdoc/>
    public override int GetHashCode() {
        int hashCode = -1072827954;
        hashCode = hashCode * -1521134295 + Major.GetHashCode();
        hashCode = hashCode * -1521134295 + Minor.GetHashCode();
        hashCode = hashCode * -1521134295 + Revision.GetHashCode();
        hashCode = hashCode * -1521134295 + Beta.GetHashCode();
        return hashCode;
    }

    /// <summary>
    /// Determines if the left version is older-than the right version.
    /// </summary>
    /// <param name="versa">The first version to check</param>
    /// <param name="versb">The second version to check</param>
    /// <returns><see langword="true"/> if the left version is older; otherwise, <see langword="false"/>.</returns>
    public static bool operator <(Version versa, Version versb) {
        if (versa.IsBeta) {
            if (versb.IsBeta) {
                if (versa.Major < versb.Major) {
                    return true;
                }
                else if (versa.Major == versb.Major) {
                    if (versa.Minor < versb.Minor) {
                        return true;
                    }
                    else if (versa.Minor == versb.Minor) {
                        if (versa.Revision < versb.Revision) {
                            return true;
                        }
                        else if (versa.Revision == versb.Revision) {
                            return versa.Beta < versb.Beta;
                        }
                    }
                }
            }
            else {
                if (versa.Major < versb.Major) {
                    return true;
                }
                else if (versa.Major == versb.Major) {
                    if (versa.Minor < versb.Minor) {
                        return true;
                    }
                    else if (versa.Minor == versb.Minor) {
                        return versa.Revision <= versb.Revision;
                    }
                }
            }
        }
        else {
            if (versa.Major < versb.Major) {
                return true;
            }
            else if (versa.Major == versb.Major) {
                if (versa.Minor < versb.Minor) {
                    return true;
                }
                else if (versa.Minor == versb.Minor) {
                    return versa.Revision < versb.Revision;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Determines if the left version is newer-than the right version.
    /// </summary>
    /// <param name="versa">The first version to check</param>
    /// <param name="versb">The second version to check</param>
    /// <returns><see langword="true"/> if the left version is newer; otherwise, <see langword="false"/>.</returns>
    public static bool operator >(Version versa, Version versb) {
        if (versb.IsBeta) {
            if (versa.IsBeta) {
                if (versa.Major > versb.Major) {
                    return true;
                }
                else if (versa.Major == versb.Major) {
                    if (versa.Minor > versb.Minor) {
                        return true;
                    }
                    else if (versa.Minor == versb.Minor) {
                        if (versa.Revision > versb.Revision) {
                            return true;
                        }
                        else if (versa.Revision == versb.Revision) {
                            return versa.Beta > versb.Beta;
                        }
                    }
                }
            }
            else {
                if (versa.Major > versb.Major) {
                    return true;
                }
                else if (versa.Major == versb.Major) {
                    if (versa.Minor > versb.Minor) {
                        return true;
                    }
                    else if (versa.Minor == versb.Minor) {
                        if (versa.Revision >= versb.Revision) {
                            return true;
                        }
                    }
                }
            }
        }
        else {
            if (versa.Major > versb.Major) {
                return true;
            }
            else if (versa.Major == versb.Major) {
                if (versa.Minor > versb.Minor) {
                    return true;
                }
                else if (versa.Minor == versb.Minor) {
                    return versa.Revision > versb.Revision;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Determines if the left version is older-than or equal-to the right version.
    /// </summary>
    /// <param name="versa">The first version to check</param>
    /// <param name="versb">The second version to check</param>
    /// <returns><see langword="true"/> if the left version is older-than or equal-to; otherwise, <see langword="false"/>.</returns>
    public static bool operator <=(Version versa, Version versb) {
        return versa == versb || versa < versb;
    }

    /// <summary>
    /// Determines if the left version is newer-than or equal-to the right version.
    /// </summary>
    /// <param name="versa">The first version to check</param>
    /// <param name="versb">The second version to check</param>
    /// <returns><see langword="true"/> if the left version is newer-than or equal-to; otherwise, <see langword="false"/>.</returns>
    public static bool operator >=(Version versa, Version versb) {
        return versa == versb || versa >= versb;
    }

    /// <summary>
    /// Determines if the two versions compared are equal to each other.
    /// </summary>
    /// <param name="versa"></param>
    /// <param name="versb"></param>
    /// <returns><see langword="true"/> if the versions are equal; otherwise, <see langword="false"/>.</returns>
    public static bool operator ==(Version versa, Version versb) =>
        versa.Major == versb.Major && versa.Minor == versb.Minor && versa.Revision == versb.Revision && versa.Beta == versb.Beta;

    /// <summary>
    /// Determines if the two versions compared are not equal to each other.
    /// </summary>
    /// <param name="versa"></param>
    /// <param name="versb"></param>
    /// <returns><see langword="true"/> if the versions are different; otherwise, <see langword="false"/>.</returns>
    public static bool operator !=(Version versa, Version versb) =>
        versa.Major != versb.Major || versa.Minor != versb.Minor || versa.Revision != versb.Revision || versa.Beta != versb.Beta;
}