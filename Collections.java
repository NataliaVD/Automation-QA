public class Collections<T> {
    private final int InitialCapacity = 16;
    private T[] items;
    public int Capacity = this.items.length;
    public int Count;

    public Collections(T[] items) {
        int capacity = Math.max(2 * items.length, InitialCapacity);
        this.items = (T[]) new Object[Capacity];
        for (int i = 0; i < items.length; i++) {
            this.items[i] = items[i];
        }
        this.Count = items.length;
    }

    public void Add(T item) {
        this.EnsureCapacity();
        this.items[this.Count] = item;
        this.Count++;
    }

    public void AddRange(T[] items) {
        for (var item : items) {
            this.Add(item);
        }
    }

    private void EnsureCapacity() {
        if (this.Count == this.Capacity) {
            T[] oldItems = this.items;
            this.items = (T[]) new Object[2 * oldItems.length];
            for (int i = 0; i < this.Count; i++)
                this.items[i] = oldItems[i];
        }
    }

    public boolean CheckRange(int index, int count) {
        return index >= 0 && index < count;
    }

    public void InsertAt(int index, T item) {
        if (this.CheckRange(index, this.Count)) {
            this.EnsureCapacity();
            for (int i = this.Count - 1; i >= index; i--)
                this.items[i + 1] = this.items[i];
            this.items[index] = item;
            this.Count++;
        } else {
            throw new IndexOutOfBoundsException();
        }
    }

    public void Exchange(int index1, int index2) {
        if (CheckRange(index1, Count - 1) && CheckRange(index2, Count - 1)) {
            T oldItem = this.items[index1];
            this.items[index1] = this.items[index2];
            this.items[index2] = oldItem;
        }
    }

    public T RemoveAt(int index) {
        T item = null;
        if (CheckRange(index, this.Count - 1)) {
            T removedItem = this.items[index];
            for (int i = index + 1; i < this.Count; i++) {
                this.items[i - 1] = this.items[i];
                this.Count--;
            }
            item = removedItem;
        }
        return item;
    }

    public void Clear() {
        this.Count = 0;
    }

    @Override
    public String toString() {
        StringBuilder result = new StringBuilder("[");
        for (int i = 0; i < this.Count; i++) {
            if (i > 0) {
                result.append(", ");
                result.append(this.items[i]);
            }
            result.append("]");
        }
        return result.toString();
    }
}
