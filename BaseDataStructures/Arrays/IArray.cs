namespace ConsoleTester.Arrays
{
    public interface IArray<T>
    {
        int Size();
        void Add(T els);
        void Add(T els, int index);
        T Remove(int index);
        T Get(int index);
    }
}