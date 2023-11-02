namespace OnlineStore
{
    public class MyList<T>
    {
        public MyNode<T> Head { get; set; }

        //1.2.1
        public void Add(T data)
        {
            if (Head == null)
            {
                Head = new MyNode<T>(data, null);
            }
            else
            {
                Head = new MyNode<T>(data, Head);
            }
        }

        //1.2.2
        public int FindPosition(T targetData)
        {
            MyNode<T> actual = Head;
            int index = 0;

            while (actual != null)
            {
                if (Equals(actual.Data, targetData))
                {
                    return index;
                }
                actual = actual.Next;
                index++;
            }
            return -1; 
        }

        //1.2.3
        public int AmountOfElements()
        {
            MyNode<T> actual = Head;
            int amount = 0;

            while (actual != null)
            {
                amount++;
                actual = actual.Next;
            }
            return amount;
        }
        
        //1.2.4
        public T ReturnElement(int index)
        {
            MyNode<T> actual = Head;
            int position = 0;

            while (actual != null)
            {
                if (position == index)
                {  
                    return actual.Data;
                }
                actual = actual.Next;
                position++;
            }
            throw new IndexOutOfRangeException("Index is out of range");
        }

        //1.2.5
        public MyList<T> RemoveElement(T targetData)
        {
            MyList<T> newList = new MyList<T>();
            MyNode<T> actual = Head;
            MyNode<T> previous = null;

            while (actual != null)
            {
                if (Equals(actual.Data, targetData))
                {
                    if (previous == null)
                    {
                        Head = actual.Next;
                    }
                    else
                    {
                        previous.Next = actual.Next;
                    }
                }
                else
                {
                    newList.Add(actual.Data);
                }
                previous = actual;
                actual = actual.Next;
            }
            return newList;
        }

        //2
        public void DisplayInformation(MyList<T> orders)
        {
            MyNode<T> current = orders.Head;

            while (current != null)
            {
                if (current.Data is Order order)
                {
                    Console.WriteLine(order.GetFullInformation());
                }

                current = current.Next;
            }
        }
    }
}