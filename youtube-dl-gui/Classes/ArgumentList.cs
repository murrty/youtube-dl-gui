#nullable enable
namespace youtube_dl_gui;
using System;
using System.Collections;
internal class ArgumentList : IList {
    private readonly List<string> _args = [];

    object? IList.this[int index] { get { return this[index]; } set { if (value is not string str) throw new ArgumentException("value is not string"); this[index] = str; } }

    bool IList.IsReadOnly => false;
    bool IList.IsFixedSize => false;
    int ICollection.Count => _args.Count;
    object? ICollection.SyncRoot => null;
    bool ICollection.IsSynchronized => false;

    int IList.Add(object? value) {
        return ((IList)_args).Add(value);
    }
    void IList.Clear() => _args.Clear();
    bool IList.Contains(object? value) => ((IList)_args).Contains(value);
    void ICollection.CopyTo(Array array, int index) => ((IList)_args).CopyTo(array, index);
    int IList.IndexOf(object? value) => ((IList)_args).IndexOf(value);
    void IList.Insert(int index, object? value) => ((IList)_args).Insert(index, value);
    void IList.Remove(object? value) => ((IList)_args).Remove(value);
    void IList.RemoveAt(int index) => _args.RemoveAt(index);

    public ArgumentList() { }
    public ArgumentList(string FirstArg) {
        if (!FirstArg.IsNullEmptyWhitespace()) {
            _args.Add(FirstArg);
        }
    }

    public string this[int index] {
        get => _args[index];
        set => _args[index] = value;
    }
    public void Add(string argument) {
        if ((argument =  argument.Trim()).IsNullEmptyWhitespace()) {
            return;
        }
        _args.Add(argument);
    }
    public void Remove(string argument) {
        _args.Remove(argument);
    }
    public void Clear() => _args.Clear();
    public override string ToString() {
        if (_args.Count < 1) {
            return string.Empty;
        }
        return string.Join(" ", _args);
    }
    public IEnumerator GetEnumerator() => _args.GetEnumerator();
}
