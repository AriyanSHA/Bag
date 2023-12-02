using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPAssignment.Bag;
namespace OOPAssignment
{
    internal class Menu
    {
        Bag bag = new Bag();
        public void Start()
        {
            bool toggle = true;
            while (toggle)
            {
                int entry;
                do
                {
                    Console.WriteLine("------------------------------\n" +
                      "Choose an option: \n\n" +
                      "1: Add an element.\n" +
                      "2: Remove an element.\n" +
                      "3: Show bag contents.\n" +
                      "4: Show element frequencies.\n" +
                      "5: Show most frequent element.\n" +
                      "0: EXIT. \n" +
                      "↓");
                    try
                    {
                        entry = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException) { entry = -1; }
                } while (entry < 0 || entry > 5);

                if (entry == 1)
                {
                    Console.WriteLine("------------------------------");
                    Console.Write("Which element you want added? ");
                    int add;
                    while (!int.TryParse(Console.ReadLine(), out add))
                    {
                        Console.Write("Invalid input. Please enter a valid integer: ");
                    }
                    bag.insertElem(new Element(add));
                }
                else if (entry == 2)
                {
                    Console.WriteLine("------------------------------");
                    Console.Write("Which element you want removed? ");

                    Element e = new Element();
                    while (!int.TryParse(Console.ReadLine(),out e.element))
                    {
                        Console.Write("Invalid input. Please enter a valid integer: ");
                    }
                    try
                    {
                        bag.removeElem(e);
                    }
                    catch (MatchFailedException) { Console.WriteLine("Element does not exist!"); }
                    catch (ListEmptyException) { Console.WriteLine("Bag is empty"); }
                }
                else if (entry == 3)
                {
                    try { bag.showBag(); }
                    catch (ListEmptyException) { Console.WriteLine("Nothing!"); }
                }
                
                else if (entry == 4)
                {
                    try { bag.elementFrequency(); }
                    catch (ListEmptyException) { Console.WriteLine("Bag is empty!"); }
                }               
                else if (entry == 5)
                {
                    try { Console.WriteLine(bag.mostFrequentElem()); }
                    catch (ListEmptyException) { Console.WriteLine("Bag is empty!"); }
                }
                else if (entry == 0)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Goodbye.");
                    toggle = false;
                }
                else
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Invalid input");
                    break;
                }
            }
        }
    }
}
