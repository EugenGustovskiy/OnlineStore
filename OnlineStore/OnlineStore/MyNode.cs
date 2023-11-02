namespace OnlineStore
{
    public class MyNode<T>
    {
        public T Data { get; set; }
        public MyNode<T> Next { get; set; }

        public MyNode(T data, MyNode<T> next)
        {
            Data = data;
            Next = next;
        }
    }
}
