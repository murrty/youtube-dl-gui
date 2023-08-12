namespace youtube_dl_gui;

internal sealed class QueueList<T> : List<T> {
    public bool TryAdd(T item) {
        int index = this.IndexOf(item);
        if (index > -1)
            return false;
        this.Add(item);
        return true;
    }
    public bool TryRemove(T item) {
        int index = this.IndexOf(item);
        if (index == -1)
            return false;
        this.RemoveAt(index);
        return true;
    }
}