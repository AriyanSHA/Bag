using System;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
namespace OOPAssignment
{
    public class Bag
    {
        //All Exceptions
        public class MatchFailedException : Exception { }
        public class ListEmptyException : Exception { }

        //All Fields
        private List<Element> seq = new List<Element>();
        public Element mostFrequent = null;
        //All Getters... I wrote them but they are not needed it seems.
        public List<Element> GetSeq() {
            return seq;
        }
        //All Constructors
        public Bag() { }
        public Bag(Element elem)
        {
            insertElem(elem);
        }
        //All Methods
        public void insertElem(Element elem)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Added " + elem.element);
            if (!newContains(seq, elem))
                seq.Add(elem); 
            else
            { 
                for(int i=0; i<seq.Count; i++)
                {
                    if (seq[i].Equals(elem))
                        seq[i].freq++;
                }
            }
            if (mostFrequent == null)
                mostFrequent = elem;
            for (int i = 0; i < seq.Count; i++)
            {
                if (seq[i].freq > mostFrequent.freq)
                    mostFrequent = seq[i];
            }
        }
        public void removeElem(Element elem)
        {
            Console.WriteLine("------------------------------");
            if (isEmpty()) throw new ListEmptyException();
            if (!newContains(seq, elem))
                throw new MatchFailedException();
            else
            {
                for (int i = 0; i < seq.Count; i++)
                {
                    if (seq[i].Equals(elem) && seq[i].freq > 1)
                    {
                        Console.WriteLine("{0} is REMOVED!", seq[i].element);
                        seq[i].freq--;
                        break;
                    }
                    else if (seq[i].Equals(elem) && seq[i].freq == 1)
                    {
                        Console.WriteLine("{0} is REMOVED!", seq[i].element);
                        seq.RemoveAt(i);
                    }
                }
            }
            if (mostFrequent == null)
                mostFrequent = elem;
            for (int i = 0; i < seq.Count; i++)
            {
                if (seq[i].freq > mostFrequent.freq)
                    mostFrequent = seq[i];
            }
        }
        public void showBag()
        {
            Console.WriteLine("------------------------------");
            Console.Write("Bag contains: ");
            if (seq.Count == 0) throw new ListEmptyException();
            for (int i = 0; i < seq.Count; i++)
                Console.Write(seq[i].element + " ");
            Console.WriteLine();
        }
        public void elementFrequency()
        {
            Console.WriteLine("------------------------------");
            if (seq.Count == 0) throw new ListEmptyException();
            foreach (Element e in seq)
                Console.WriteLine("Element {0} ==> {1}.", e.element, e.freq);
        }
        public int mostFrequentElem()
        {
            Console.WriteLine("------------------------------");
            if (seq.Count == 0) throw new ListEmptyException();
            Console.Write("Most frequent element is: ");
            return mostFrequent.element;
        }
        public bool isEmpty()
        {
            if (seq.Count == 0) return true;
            return false;
        }
        public bool newContains(List<Element> seq, Element e)
        {
            for (int i = 0; i < seq.Count; i++)
            {
                if (seq[i].element == e.element)
                    return true;
            }
            return false;
        }
    }
    public class Element
    {
        public int element;
        public int freq;
        public Element() { }
        public Element(int element)
        {
            this.element = element;
            this.freq = 1;
        }
        public int getElement()
        {
            return element;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Element))
                return false;

            Element other = (Element)obj;
            if (other.element == this.element)
                return true;
            else
                return false;
        }
        
    }
}
