using System;
using System.Collections.Generic;

class Item               // ➊ A tiny class = our OOP showcase
{
    public string Name { get; }
    public int Qty { get; private set; }

    public Item(string name, int qty) { Name = name; Qty = qty; }
    public void Add(int qty) => Qty += qty;
    public override string ToString() => $"{Name} × {Qty}";
}

class Program
{
    static List<Item> list = new();          // our in‑memory “database”

    static void Main()
    {
        Console.WriteLine("🛒  Mini Shopping List — A(add)  L(list)  R(remove)  Q(quit)");
        while (true)
        {
            Console.Write("> "); var cmd = Console.ReadLine()?.Trim().ToUpper();
            if (cmd == "Q") break;

            if (cmd == "A")
            {
                Console.Write("Item? "); var name = Console.ReadLine();
                Console.Write("Qty?  "); int.TryParse(Console.ReadLine(), out int qty);
                var it = list.Find(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (it != null) it.Add(qty); else list.Add(new Item(name, qty));
            }
            else if (cmd == "L")
            {
                if (list.Count == 0) Console.WriteLine("(empty)");
                else list.ForEach(i => Console.WriteLine(" • " + i));
            }
            else if (cmd == "R")
            {
                Console.Write("Remove which item? "); var name = Console.ReadLine();
                list.RemoveAll(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
