using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler topHandler = new Handler();
            Handler foodHandler = new FoodHandler();
            Handler drinkHandler = new DrinkHandler();

            topHandler.Add(foodHandler);
            topHandler.Add(drinkHandler);

            topHandler.Handle("Beer");
            topHandler.Handle("Burger");
            topHandler.Handle("Pancakes");

            Console.ReadKey();
        }
    }

    class Handler
    {
        Handler next;

        public void Add(Handler h)
        {
            if (next == null)
            {
                next = h;
            }
            else
            {
                next.Add(h);
            }

        }

        public virtual void Handle(String s)
        {
            if (next != null) next.Handle(s);
            else Console.WriteLine($"Can't process {s}.");
        }
    }

    class FoodHandler : Handler
    {
        public override void Handle(String s)
        {
            if (s.Equals("Burger"))
            {
                Console.WriteLine($"Eating {s}.");
            }

            else base.Handle(s);
        }
    }

    class DrinkHandler : Handler
    {
        public override void Handle(String s)
        {
            if (s.Equals("Beer"))
            {
                Console.WriteLine($"Drinking {s}.");
            }

            else base.Handle(s);
        }
    }
}
