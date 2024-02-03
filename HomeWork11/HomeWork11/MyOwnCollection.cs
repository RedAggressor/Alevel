using System.Collections;

namespace HomeWork11
{
    public class MyOwnCollection<T> : IEnumerator, IComparer<T>
    {
        private T[] _list = Array.Empty<T>();
        private int _index = -1;
        public int Count { get => _list.Length; }

        public object Current
        {
            get
            {
                if (_index == -1 || _index >= _list.Length)
                {
                    throw new ArgumentException();
                }
                return _list[_index];
            }
        }

        public MyOwnCollection(T[] listValue)
        {
            _list = listValue;
        }

        public MyOwnCollection(List<T> listList)
        {
            _list = listList.ToArray();
        }

        public MyOwnCollection(T value)
        {
            _list = new T[1];
            _list[0] = value;
        }

        public MyOwnCollection()
        {
            _list = Array.Empty<T>();
        }

        public void SetDefaultAt(int indexElement)
        {
            if (indexElement < 0 || indexElement > Count)
            {
                return;
            }

            T[] tempList = new T[Count];

            T? defaultValue = default(T);

            for (int i = 0; i < Count; i++)
            {
                if (i == indexElement)
                {
                    continue;

                }
                tempList[i] = _list[i];
            }

            tempList[indexElement] = defaultValue;

            _list = tempList;
        }

        public void Add(T addValue)
        {
            T[] tempList = new T[Count + 1];

            for (int i = 0; i < Count; i++)
            {
                tempList[i] = _list[i];
            };

            tempList[Count] = addValue;

            _list = tempList;
        }

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public bool MoveNext()
        {
            if (_index < Count - 1)
            {
                _index++;
                return true;
            }
            else
                return false;
        }

        public void Reset() => _index = -1;

        public void Sort(int firstIndex = 0, int lastIndex = 0, int jumperSort = -1)
        {
            lastIndex = lastIndex == 0 ? Count : lastIndex;

            int lenght = Count;

            T[] TempList = new T[lenght];

            T switchValue;

            for (int i = 0; i < firstIndex; i++)
            {
                TempList[i] = _list[i];
            }

            for (int i = firstIndex + 1; i < lastIndex; i++)
            {
                for (int j = firstIndex; j < lastIndex - i; j++)
                {
                    if (Compare(_list[j], _list[j + 1]) == jumperSort)
                    {
                        switchValue = _list[j];
                        _list[j] = _list[j + 1];
                        _list[j + 1] = switchValue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            for (int i = lastIndex; i < lenght; i++)
            {
                TempList[i] = _list[i];
            }
        }

        public int Compare(T? x, T? y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }
    }
}