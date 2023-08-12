// Derived from https://www.codeproject.com/Articles/170684/Time-Picker
namespace murrty.controls;

using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

[DefaultEvent("OnValueChanged")]
public sealed class TimePicker : UserControl {

    #region Component Designer generated code
    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        this.TimeDisplay = new TextBox();
        this.SuspendLayout();

        this.TimeDisplay.Location = new Point(0, 0);
        this.TimeDisplay.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        this.TimeDisplay.Name = "TheTimeBox";
        this.TimeDisplay.Size = new Size(75, 20);
        this.TimeDisplay.TabIndex = 0;
        this.TimeDisplay.Text = "00:00:00";
        this.TimeDisplay.Click += new EventHandler(this.TimeDisplay_Click);
        this.TimeDisplay.KeyDown += new KeyEventHandler(this.TimeDisplay_KeyDown);
        this.TimeDisplay.LostFocus += new EventHandler(TimeDisplay_LostFocus);

        this.AutoScaleDimensions = new SizeF(6F, 13F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.Controls.Add(this.TimeDisplay);
        this.LostFocus += new EventHandler(TimeDisplay_LostFocus);
        this.Name = "TimePicker";
        this.Size = TimeDisplay.Size;
        this.ResumeLayout(false);
        this.PerformLayout();

    }
    #endregion

    private TextBox TimeDisplay;

    protected override void Dispose(bool disposing) {
        if (disposing)
            TimeDisplay.Dispose();
        base.Dispose(disposing);
    }

    [Browsable(true)]
    public event EventHandler OnValueChanged;
    [Browsable(true)]
    public new Font Font { get => TimeDisplay.Font; set => TimeDisplay.Font = value; }
    [DefaultValue(true)]
    public bool DateBasedTime { get; set; } = true;
    [DefaultValue(false)]
    public bool ShowMilliseconds {
        get => _showms;
        set {
            _showms = value;
            UpdateDisplay();
        }
    }
    //[DefaultValue("00:00:00")]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public string Time {
    //    get => TimeDisplay.Text;
    //    set {
    //        if (value is null || !Regex.IsMatch(value, "([0-9]{1,}:)?[0-9]{1,2}:[0-9]{1,2}(\\.[0-9]{1,3})?")) {
    //            Hours = 0;
    //            Minutes = 0;
    //            Seconds = 0;
    //            Milliseconds = 0;
    //        }
    //        else {
                
    //        }

    //    }
    //}
    private int Hours { get; set; } = 0;
    private int Minutes { get; set; } = 0;
    private int Seconds { get; set; } = 0;
    private int Milliseconds { get; set; } = 0;
    private bool _showms = false;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TimeSpan TimeSpan {
        get {
            return new TimeSpan(0, Hours > 24 ? 0 : Hours, Minutes, Seconds, Milliseconds);
        }
        set {
            Hours = value.Hours;
            Minutes = value.Minutes;
            Seconds = value.Seconds;
            Milliseconds = value.Milliseconds;
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Time Value {
        get => new(Hours, Minutes, Seconds, Milliseconds);
        set {
            Hours = value.Hours;
            Minutes = value.Minutes;
            Seconds = value.Seconds;
            Milliseconds = value.Milliseconds;
        }
    }

    [DefaultValue(HorizontalAlignment.Left)]
    public HorizontalAlignment TextAlign {
        get => TimeDisplay.TextAlign;
        set => TimeDisplay.TextAlign = value;
    }
    public bool HasValue => Hours > 0 || Minutes > 0 || Seconds > 0 || Milliseconds > 0;

    private int HourToMinuteSeparator { get; set; } = 2;
    private int MinuteToSecondSeparator => HourToMinuteSeparator + 3;
    private int SecondToMillisecondSeparator => MinuteToSecondSeparator + 3;

    public TimePicker() {
        InitializeComponent();
    }

    private bool SpecifyingNumbers = false;
    private int NumbersStartingIndex = -1;

    protected override bool ProcessTabKey(bool forward) {
        if (SpecifyingNumbers)
            UpdateControl();

        if (TimeDisplay.SelectionStart <= HourToMinuteSeparator) {
            SelectMinutePosition();
            return true;
        }
        else if (TimeDisplay.SelectionStart <= MinuteToSecondSeparator) {
            SelectSecondPosition();
            return true;
        }
        else if (ShowMilliseconds && TimeDisplay.SelectionStart <= SecondToMillisecondSeparator) {
            SelectMillisecondPosition();
            return true;
        }
        else {
            SelectHourPosition();
            return base.ProcessTabKey(forward);
        }
    }
    public void SetValue(int Hour, int Minute, int Second, int Millisecond) {
        this.Hours = Hour >= 24 && DateBasedTime ? 24 : Hours < 0 ? 0 : Hours;
        this.Minutes = Minute >= 59 ? 59 : Minute < 0 ? 0 : Minute;
        this.Seconds = Second >= 59 ? 59 : Second < 0 ? 0 : Second;
        this.Milliseconds = Millisecond >= 999 ? 999 : Millisecond < 0 ? 0 : Millisecond;
        UpdateDisplay();
    }
    private void UpdateControl() {
        string[] Parts = TimeDisplay.Text.Trim().Split(":".ToCharArray());

        this.Hours = !int.TryParse(Parts[0], out int ParseHours) || ParseHours < 0 ? 0 : ParseHours >= 25 && DateBasedTime ? 24 : ParseHours;
        this.Minutes = !int.TryParse(Parts[1], out int ParseMinutes) || ParseMinutes < 0 ? 0 : ParseMinutes >= 59 ? 59 : ParseMinutes;

        if (ShowMilliseconds) {
            string[] SecondParts = Parts[2].Split(".".ToCharArray());
            this.Seconds = !int.TryParse(SecondParts[0], out int ParseSeconds) || ParseSeconds < 0 ? 0 : ParseSeconds >= 59 ? 59 : ParseSeconds;
            this.Milliseconds = !int.TryParse(SecondParts[1], out int ParseMilliseconds) || ParseMilliseconds < 0 ? 0 : ParseMilliseconds >= 999 ? 999 : ParseMilliseconds;
        }
        else {
            this.Seconds = !int.TryParse(Parts[2], out int ParseSeconds) || ParseSeconds < 0 ? 0: ParseSeconds >= 59 ? 59 : ParseSeconds;
            this.Milliseconds = 0;
        }

        UpdateHourSeparator();
        UpdateDisplay();
        SpecifyingNumbers = false;
        OnValueChanged?.Invoke(null, new EventArgs());
    }
    private void UpdateDisplay() {
        int SelectedIndex = SpecifyingNumbers ? NumbersStartingIndex : TimeDisplay.SelectionStart;
        TimeDisplay.Text = $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}" + (ShowMilliseconds ? $".{Milliseconds:D3}" : "");
        SelectedIndex = SelectedIndex > TimeDisplay.Text.Length ? TimeDisplay.Text.Length : SelectedIndex;
        SelectCorrectText(SelectedIndex);
    }
    private void UpdateHourSeparator() {
        HourToMinuteSeparator = Hours switch {
            < 0 => throw new ArgumentOutOfRangeException("The hour cannot be less-than 0."),
            < 100 => 2,
            < 1_000 => 3,
            < 10_000 => 4,
            < 100_000 => 5,
            < 1_000_000 => 6,
            < 10_000_000 => 7,
            < 100_000_000 => 8,
            < 1_000_000_000 => 9,
            _ => 10,
        };
    }
    private void SelectCorrectText(int SelectedIndex) {
        //Debug.Print("SelectCorrectText");

        if (SelectedIndex <= HourToMinuteSeparator)
            SelectHourPosition();
        else if (SelectedIndex <= MinuteToSecondSeparator)
            SelectMinutePosition();
        else if (SelectedIndex <= SecondToMillisecondSeparator || !ShowMilliseconds)
            SelectSecondPosition();
        else
            SelectMillisecondPosition();
    }

    public void SelectHourPosition() => TimeDisplay.Select(0, HourToMinuteSeparator);
    public void SelectMinutePosition() => TimeDisplay.Select(HourToMinuteSeparator + 1, 2);
    public void SelectSecondPosition() => TimeDisplay.Select(MinuteToSecondSeparator + 1, 2);
    public void SelectMillisecondPosition(bool? GoToHours = null) {
        if (!ShowMilliseconds) {
            if (GoToHours is not null) {
                if (GoToHours == true)
                    SelectHourPosition();
                else SelectSecondPosition();
            }
            return;
        }
        TimeDisplay.Select(SecondToMillisecondSeparator + 1, 3);
    }

    private void TimeDisplay_KeyDown(object sender, KeyEventArgs e) {
        switch (e.KeyCode) {
            case Keys.Up: {
                if (SpecifyingNumbers)
                    UpdateControl();

                if (ShowMilliseconds) {
                    if (TimeDisplay.SelectionStart <= HourToMinuteSeparator) {
                        if (DateBasedTime && Hours >= 24) {
                            Hours = 0;
                        } else Hours++;
                        UpdateHourSeparator();
                    }
                    else if (TimeDisplay.SelectionStart <= MinuteToSecondSeparator) {
                        if (Minutes >= 59) {
                            Minutes = 0;
                        } else Minutes++;
                    }
                    else if (TimeDisplay.SelectionStart <= SecondToMillisecondSeparator) {
                        if (Seconds >= 59) {
                            Seconds = 0;
                        } else Seconds++;
                    }
                    else {
                        if (Milliseconds >= 999) {
                            Milliseconds = 0;
                        } else Milliseconds++;
                    }
                }
                else {
                    if (TimeDisplay.SelectionStart <= HourToMinuteSeparator) {
                        if (DateBasedTime && Hours >= 24) {
                            Hours = 0;
                        } else Hours++;
                        UpdateHourSeparator();
                    }
                    else if (TimeDisplay.SelectionStart <= MinuteToSecondSeparator) {
                        if (Minutes >= 59) {
                            Minutes = 0;
                        } else Minutes++;
                    }
                    else {
                        if (Seconds >= 59) {
                            Seconds = 0;
                        } else Seconds++;
                    }
                }

                UpdateDisplay();
                OnValueChanged?.Invoke(null, new EventArgs());
                e.Handled = e.SuppressKeyPress = true;
            } break;
            case Keys.Down: {
                if (SpecifyingNumbers)
                    UpdateControl();

                if (ShowMilliseconds) {
                    if (TimeDisplay.SelectionStart <= HourToMinuteSeparator) {
                        if (Hours <= 0) {
                            if (!DateBasedTime) {
                                e.Handled = true;
                                e.SuppressKeyPress = true;
                                System.Media.SystemSounds.Exclamation.Play();
                                return;
                            }
                            Hours = 24;
                        } else Hours--;
                        UpdateHourSeparator();
                    }
                    else if (TimeDisplay.SelectionStart <= MinuteToSecondSeparator) {
                        if (Minutes <= 0) {
                            Minutes = 59;
                        } else Minutes--;
                    }
                    else if (TimeDisplay.SelectionStart <= SecondToMillisecondSeparator) {
                        if (Seconds <= 0) {
                            Seconds = 59;
                        } else Seconds--;
                    }
                    else {
                        if (Milliseconds <= 0) {
                            Milliseconds = 999;
                        } else Milliseconds--;
                    }
                }
                else {
                    if (TimeDisplay.SelectionStart <= HourToMinuteSeparator) {
                        if (Hours <= 0) {
                            if (!DateBasedTime) {
                                e.Handled = true;
                                e.SuppressKeyPress = true;
                                System.Media.SystemSounds.Exclamation.Play();
                                return;
                            }
                            Hours = 24;
                        } else Hours--;
                        UpdateHourSeparator();
                    }
                    else if (TimeDisplay.SelectionStart <= MinuteToSecondSeparator) {
                        if (Minutes <= 0) {
                            Minutes = 59;
                        } else Minutes--;
                    }
                    else {
                        if (Seconds <= 0) {
                            Seconds = 59;
                        } else Seconds--;
                    }
                }

                UpdateDisplay();
                OnValueChanged?.Invoke(null, new EventArgs());
                e.Handled = e.SuppressKeyPress = true;
            } break;
            case Keys.Left: {
                if (SpecifyingNumbers)
                    UpdateControl();

                if (TimeDisplay.SelectionStart <= HourToMinuteSeparator)
                    SelectMillisecondPosition(false);
                else if (TimeDisplay.SelectionStart <= MinuteToSecondSeparator)
                    SelectHourPosition();
                else if (TimeDisplay.SelectionStart <= SecondToMillisecondSeparator)
                    SelectMinutePosition();
                else
                    SelectSecondPosition();

                e.Handled = e.SuppressKeyPress = true;
            } break;
            case Keys.Right: {
                if (SpecifyingNumbers)
                    UpdateControl();

                if (TimeDisplay.SelectionStart <= HourToMinuteSeparator)
                    SelectMinutePosition();
                else if (TimeDisplay.SelectionStart <= MinuteToSecondSeparator)
                    SelectSecondPosition();
                else if (ShowMilliseconds && TimeDisplay.SelectionStart <= SecondToMillisecondSeparator)
                    SelectMillisecondPosition();
                else
                    SelectHourPosition();

                e.Handled = e.SuppressKeyPress = true;
            } break;
            case Keys.Return: {
                if (SpecifyingNumbers)
                    UpdateControl();
                e.Handled = e.SuppressKeyPress = true;
            } break;

            case Keys.D0: case Keys.NumPad0:
            case Keys.D1: case Keys.D2: case Keys.D3:
            case Keys.D4: case Keys.D5: case Keys.D6:
            case Keys.D7: case Keys.D8: case Keys.D9:
            case Keys.NumPad1: case Keys.NumPad2: case Keys.NumPad3:
            case Keys.NumPad4: case Keys.NumPad5: case Keys.NumPad6:
            case Keys.NumPad7: case Keys.NumPad8: case Keys.NumPad9: {
                if (!SpecifyingNumbers)
                    NumbersStartingIndex = TimeDisplay.SelectionStart;
                SpecifyingNumbers = true;
            } break;

            default: {
                e.Handled = e.SuppressKeyPress = true;
                System.Media.SystemSounds.Exclamation.Play();
            } break;
        }
    }
    private void TimeDisplay_LostFocus(object sender, EventArgs e) {
        if (!SpecifyingNumbers)
            return;

        try {
            UpdateControl();
        }
        catch { }
    }
    private void TimeDisplay_Click(object sender, EventArgs e) {
        if (SpecifyingNumbers)
            UpdateControl();
        else
            SelectCorrectText(TimeDisplay.SelectionStart);
    }
}

public struct Time : IEquatable<Time> {
    public static Time Empty = new(0, 0, 0, 0);
    public int Hours;
    public int Minutes;
    public int Seconds;
    public int Milliseconds;
    public Time() {
        Hours = 0;
        Minutes = 0;
        Seconds = 0;
        Milliseconds = 0;
    }
    public Time(int Hours) {
        if (Hours < 0)
            throw new ArgumentOutOfRangeException(nameof(Hours));

        this.Hours = Hours;
        Minutes = 0;
        Seconds = 0;
        Milliseconds = 0;
    }
    public Time(int Hours, int Minutes) {
        if (Hours < 0)
            throw new ArgumentOutOfRangeException(nameof(Hours));

        if (Minutes < 0)
            throw new ArgumentOutOfRangeException(nameof(Minutes));

        this.Hours = Hours;
        this.Minutes = Minutes;
        Seconds = 0;
        Milliseconds = 0;
    }
    public Time(int Hours, int Minutes, int Seconds) {
        if (Hours < 0)
            throw new ArgumentOutOfRangeException(nameof(Hours));

        if (Minutes < 0)
            throw new ArgumentOutOfRangeException(nameof(Minutes));

        if (Seconds < 0)
            throw new ArgumentOutOfRangeException(nameof(Seconds));

        this.Hours = Hours;
        this.Minutes = Minutes;
        this.Seconds = Seconds;
        Milliseconds = 0;
    }
    public Time(int Hours, int Minutes, int Seconds, int Milliseconds) {
        if (Hours < 0)
            throw new ArgumentOutOfRangeException(nameof(Hours));

        if (Minutes < 0)
            throw new ArgumentOutOfRangeException(nameof(Minutes));

        if (Seconds < 0)
            throw new ArgumentOutOfRangeException(nameof(Seconds));

        if (Milliseconds < 0)
            throw new ArgumentOutOfRangeException(nameof(Milliseconds));


        this.Hours = Hours;
        this.Minutes = Minutes;
        this.Seconds = Seconds;
        this.Milliseconds = Milliseconds;
    }

    public static bool operator ==(Time a, Time b) =>
        a.Hours == b.Hours && a.Minutes == b.Minutes && a.Seconds == b.Seconds && a.Milliseconds == b.Milliseconds;
    public static bool operator !=(Time a, Time b) =>
        a.Hours != b.Hours || a.Minutes != b.Minutes || a.Seconds != b.Seconds || a.Milliseconds != b.Milliseconds;
    public static bool operator >(Time a, Time b) {
        if (a.Hours > b.Hours)
            return true;
        else if (a.Hours < b.Hours)
            return false;

        if (a.Minutes > b.Minutes)
            return true;
        else if (a.Minutes < b.Minutes)
            return false;

        if (a.Seconds > b.Seconds)
            return true;
        else if (a.Seconds < b.Seconds)
            return false;

        if (a.Milliseconds > b.Milliseconds)
            return true;
        else if (a.Milliseconds < b.Milliseconds)
            return false;

        return false;
    }
    public static bool operator >=(Time a, Time b) {
        if (a.Hours > b.Hours)
            return true;
        else if (a.Hours < b.Hours)
            return false;

        if (a.Minutes > b.Minutes)
            return true;
        else if (a.Minutes < b.Minutes)
            return false;

        if (a.Seconds > b.Seconds)
            return true;
        else if (a.Seconds < b.Seconds)
            return false;

        if (a.Milliseconds > b.Milliseconds)
            return true;
        else if (a.Milliseconds < b.Milliseconds)
            return false;

        return true;
    }
    public static bool operator <(Time a, Time b) {
        if (a.Hours < b.Hours)
            return true;
        else if (a.Hours > b.Hours)
            return false;

        if (a.Minutes < b.Minutes)
            return true;
        else if (a.Minutes > b.Minutes)
            return false;

        if (a.Seconds < b.Seconds)
            return true;
        else if (a.Seconds > b.Seconds)
            return false;

        if (a.Milliseconds < b.Milliseconds)
            return true;
        else if (a.Milliseconds > b.Milliseconds)
            return false;

        return false;
    }
    public static bool operator <=(Time a, Time b) {
        if (a.Hours < b.Hours)
            return true;
        else if (a.Hours > b.Hours)
            return false;

        if (a.Minutes < b.Minutes)
            return true;
        else if (a.Minutes > b.Minutes)
            return false;

        if (a.Seconds < b.Seconds)
            return true;
        else if (a.Seconds > b.Seconds)
            return false;

        if (a.Milliseconds < b.Milliseconds)
            return true;
        else if (a.Milliseconds > b.Milliseconds)
            return false;

        return true;
    }

    public bool HasValue =>
        Hours > 0 || Minutes > 0 || Seconds > 0 || Milliseconds > 0;

    public override bool Equals(object obj) => obj is Time time && Equals(time);
    public bool Equals(Time other) => Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds && Milliseconds == other.Milliseconds;

    public override int GetHashCode() {
        int hashCode = 446537655;
        hashCode = hashCode * -1521134295 + Hours.GetHashCode();
        hashCode = hashCode * -1521134295 + Minutes.GetHashCode();
        hashCode = hashCode * -1521134295 + Seconds.GetHashCode();
        hashCode = hashCode * -1521134295 + Milliseconds.GetHashCode();
        return hashCode;
    }

    public override string ToString() {
        StringBuilder buf = new();

        if (Hours > 0)
            buf.Append(Hours.ToString("D2"));

        if (Minutes > 0) {
            if (buf.Length > 0)
                buf.Append(":");
            buf.Append(Minutes.ToString());
        }
        else if (buf.Length > 0)
            buf.Append(":00");

        if (Seconds > 0) {
            if (buf.Length > 0)
                buf.Append(":");
            buf.Append(Seconds.ToString());
        }
        else if (buf.Length > 0)
            buf.Append(":00");

        if (Milliseconds > 0) {
            if (buf.Length > 0)
                buf.Append(".");
            buf.Append(Milliseconds.ToString());
        }


        return buf.ToString();
    }
}

public struct TimeOffset : IEquatable<TimeOffset> {
    public static TimeOffset Empty;

    public Time StartingTime;
    public Time EndingTime;

    public TimeOffset() {
        StartingTime = Time.Empty;
        EndingTime = Time.Empty;
    }
    
    public TimeOffset(Time StartingTime) {
        this.StartingTime = StartingTime;
        EndingTime = Time.Empty;
    }

    public TimeOffset(Time StartingTime, Time EndingTime) {
        if (EndingTime >= StartingTime)
            throw new ArgumentOutOfRangeException(nameof(EndingTime));
        this.StartingTime = StartingTime;
        this.EndingTime = EndingTime;
    }

    public bool HasStartingTime => StartingTime != Time.Empty;
    public bool HasEndingTime => EndingTime != Time.Empty;

    public bool Equals(TimeOffset other) => throw new NotImplementedException();
}