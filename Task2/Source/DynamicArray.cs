using System.Collections;



namespace Task2.Source
{
    internal class DynamicArray<Type> : IEnumerable<Type>, IDisposable
    {
        private Type[] _array;
        private int _length;
        private bool _disposedValue;


        public Type this[int indx]
        {
            get
            {
                ThrowIfInvalid(indx);
                return _array[indx];
            }
            set
            {
                ThrowIfInvalid(indx);
                _array[indx] = value;
            }
        }
        public int Capacity
        {
            get
            {
                return _array.Length;
            }
        }
        public int Length
        {
            get
            {
                return _length;
            }
            private set
            {
                _length = value;
            }
        }


        public delegate void CapacityEventHandler(object sender, CapacityEventArgs e);
        public CapacityEventHandler? CapacityChanged;


        public DynamicArray(int capacity = 8)
        {
            _array = new Type[capacity];
            Length = 0;
        }
        public DynamicArray(IEnumerable<Type> collection)
        {
            _array = new Type[0];
            AddRange(collection);
        }


        public void Add(Type value)
        {
            Resize(1);
            _array[Length - 1] = value;
        }
        public void AddRange(IEnumerable<Type> collection)
        {
            int length = Length;
            Resize(Count(collection));
            foreach (var item in collection)
            {
                _array[length] = item;
                length++;
            }
        }
        public void Insert(Type value, int posValue)
        {
            ThrowIfInvalid(posValue);
            Resize(1);
            for (int iIndx = Length - 1; iIndx > posValue; iIndx--)
            {
                _array[iIndx] = _array[iIndx - 1];
            }
            _array[posValue] = value;
        }
        public void RemoveAll(Type value, Func<Type, Type, bool>? match = null)
        {
            if (match == null)
            {
                for (int iIndx = Length - 1; iIndx >= 0; iIndx--)
                {
                    if (_array[iIndx].Equals(value))
                    {
                        Remove(iIndx);
                    }
                }
            }
            else
            {
                for (int iIndx = Length - 1; iIndx >= 0; iIndx--)
                {
                    if (match(value, _array[iIndx]))
                    {
                        Remove(iIndx);
                    }
                }
            }
        }
        private void Remove(int posValue)
        {
            ThrowIfInvalid(posValue);
            for (int iIndx = posValue; iIndx < Length - 1; iIndx++)
            {
                _array[iIndx] = _array[iIndx + 1];
            }
            _array[Length - 1] = default(Type);
            Length--;
        }
        private void Resize(int addedLength)
        {
            Length += addedLength;
            if (Capacity <= Length)
            {
                int tempCapacity = Capacity;
                while (tempCapacity <= Length)
                {
                    tempCapacity *= 2;
                }
                OnCapacityChanged(Capacity, tempCapacity);
                Array.Resize(ref _array, Capacity == 0 ? 1 : tempCapacity);
            }
        }
        private void ThrowIfInvalid(int indx)
        {
            if(indx < 0 || indx > Length)
            {
                throw new IndexOutOfRangeException($"{nameof(indx)} : {indx}");
            }
        }
        private int Count(IEnumerable<Type> collection)
        {
            int count = 0;
            foreach (var item in collection)
            {
                count++;
            }
            return count;
        }
        private void OnCapacityChanged(int oldValue, int newValue)
        {
            CapacityChanged?.Invoke(this, new CapacityEventArgs(oldValue, newValue));
        }


        public static implicit operator Type[]?(DynamicArray<Type> obj)
        {
            return obj._array.Clone() as Type[];
        }

        public static explicit operator DynamicArray<Type>(Type[] obj)
        {
            return new DynamicArray<Type>(obj);
        }


        public static bool operator ==(DynamicArray<Type>? left, DynamicArray<Type>? rigth)
        {
            return left.Equals(rigth);
        }
        public static bool operator !=(DynamicArray<Type>? left, DynamicArray<Type>? rigth)
        {
            return !left.Equals(rigth);
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is DynamicArray<Type>))
            {
                return false;
            }

            DynamicArray<Type>? list = ( obj as DynamicArray<Type> );
            if (Length != list.Length || Capacity != list.Capacity)
            {
                return false;
            }

            for (int iIndx = 0; iIndx < Length; iIndx++)
            {
                if (!this[iIndx].Equals(_array[iIndx]))
                {
                    return false;
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            int res = 0x228;
            foreach (var item in this)
            {
                res = res * 31 + (item == null ? 0 : item.GetHashCode());
            }
            return res;
        }


        public IEnumerator<Type> GetEnumerator()
        {
            return new DynamicArrayEnumerator<Type>(_array, Length);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    foreach (var item in _array)
                    {
                        if(item is IDisposable)
                        {
                            ((IDisposable)item).Dispose();
                        }
                    }
                    Array.Clear(_array);
                    Length = 0;
                }
                _disposedValue = true;
            }
        }
        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
