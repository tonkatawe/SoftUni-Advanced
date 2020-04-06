using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

public class Box<T>
{
    private Stack<T> data;

    public Box()
    {
        this.data = new Stack<T>();
    }
    public int Count
    {
        get
        {
            return this.data.Count;
        }
    }
    public void Add(T item)
    {
        this.data.Push(item);
    }

    public T Remove()
    {
        return this.data.Pop();
    }
}

