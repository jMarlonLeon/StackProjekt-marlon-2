using System;

public class Sobject
{
    private object? content;

    public Sobject(object inputstr)
    {
        content = inputstr;
    }

    public object getContent()
    {
         return content;
    }

    public void setContent(object inputobject)
    {
        content = inputobject;
    }
}

public class Stack
{
    public Sobject[] data  = new Sobject[0];
    private int top;
    private int capacity;

    public Stack(int length)
    {
        capacity = length;
        data = new Sobject[capacity];
        top = -1;
        Console.WriteLine($"Initialized stack with capacity {capacity}");
    }

    public void Push(Sobject value)
    {
        if (top == capacity)
        {
            Console.WriteLine("Stack is full!");
            throw new OverflowException("Stack is full");
        }
        Console.WriteLine($"Pushed {value.getContent()} onto the stack");
        top++;
        data[top] = value;
    }
    public Sobject Pop()
    {
        if (top == -1)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        Sobject value = data[top];
        top--;
        Console.WriteLine($"Popped {value.getContent()} from the stack");
        return value;
    }

    public void Init(int length)
    {
        capacity = length;
        data = new Sobject[capacity];
        top = -1;
        Console.WriteLine($"Initialized stack with capacity {capacity}");
    }
    public int getCapacity()
    {
        return capacity;
    }

    public int getTop()
    {
        return top;
    }

    public void printelements()
    {
        if (top == -1)
        {
            Console.WriteLine("No elements in Stack!");
        }
        else
        {
            Console.WriteLine("(TOP)");
            for (int i = top; i >= 0; i--)
            {
                Sobject printObject = data[i];
                Console.Write(printObject.getContent());
                string obj_type = printObject.getContent().GetType().ToString();
                Console.Write($"    type:{obj_type.Split('.')[1]} \n");
            }
        }
    }
}
