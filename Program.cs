using System;

namespace MyStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack myStack = new Stack(0);
            Console.WriteLine("Stack 1.0 - ready!");

            while (true)
            {
                Console.Write("Enter a command (init, push, pop, print or end): ");
                string? input = Console.ReadLine()?.Trim();

                if (input == "init")
                {
                    Console.Write("Enter stack size: ");
                    string? sizeInput = Console.ReadLine();
                    int.TryParse(sizeInput, out int size);

                    if (size == 0 || sizeInput == null)
                    {
                        Console.WriteLine("Cannot initialize Stack with length '0'");
                        size = 1;
                        Console.WriteLine("Set default Stack length to 1");
                    }
                    myStack.Init(size);
                    Console.Clear();
                }

                else if (input == "end")
                {
                    Console.Clear();
                    Console.WriteLine("Exiting program...");
                    break;
                }

                else if (input == "push")
                {
                    Console.Clear();
                    if (myStack.getCapacity() <= 0)
                    {
                        Console.WriteLine("Stack has not been initialized!");
                    }
                    else
                    {
                        Console.Write("Enter a value to push: ");
                        string? valueInput = Console.ReadLine()?.Trim();

                        Sobject value = new Sobject(valueInput);

                        bool valid_val = true;


                        if (int.TryParse((string?)value.getContent(), out int int_value))
                        {
                            value.setContent(int_value);
                        }
                        else if (float.TryParse((string?)value.getContent(), out float float_value))
                        {
                            value.setContent(float_value);
                        }
                        else if (double.TryParse((string?)value.getContent(), out double double_value))
                        {
                            value.setContent(double_value);
                        }
                        else if (char.TryParse((string?)value.getContent(), out char char_value))
                        {
                            value.setContent(char_value);
                        }
                        else if (value.getContent == null)
                        {
                            Console.WriteLine("Enter a valid value!");
                            valid_val = false;
                        }
                        else
                        {
                            value.setContent(valueInput);
                        }
                        Console.Clear();


                        if (valid_val == true)
                        {
                            try
                            {
                                myStack.Push(value);
                                //Console.WriteLine($"Value {value.getContent()} pushed to the stack.");
                                Console.WriteLine("Elements in stack:");
                                myStack.printelements();
                            }
                            catch(OverflowException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No valid value was given, try again!");
                        }
                    }
                }

                else if (input == "pop")
                {
                    Console.Clear();
                    if (myStack.getCapacity() > 0)
                    {
                        try
                        {
                            Sobject value = myStack.Pop();
                            //Console.WriteLine($"Value {value} popped from the stack.");
                            Console.WriteLine("Elements in stack:");
                            myStack.printelements();
                        }
                        catch(InvalidOperationException iop)
                        {
                            Console.WriteLine(iop.Message);
                        }
                    }
                    else if (myStack.getCapacity() <= 0)
                    {
                        Console.WriteLine("Stack has not been initialized!");
                        //throw new InvalidOperationException("Stack has not been initialized!");
                    }
                    else
                    {
                        Console.WriteLine("Stack is empty.");
                    }
                }

                else if (input == "print")
                {
                    Console.WriteLine("printing Elements in Stack:");
                    myStack.printelements();
                }

                else
                {
                    Console.WriteLine("Invalid command. Please enter push, pop, print or end.");
                }
            }
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
