using OOPAssignment;
using System.Runtime.Intrinsics;
using static OOPAssignment.Bag;

namespace TestBag
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Test_getElem()
        {
            Element e1 = new Element(1);
            Element e2 = new Element(4);

            Assert.IsTrue(e1.getElement() == 1); //(1 == 1) Passed!
            Assert.IsTrue(e2.getElement() != 10); //(4 == 4) Passed!
            Assert.AreNotEqual(e1, e2); //(4 != 1) Passed

            Element e3 = new Element(5);
            Element e4 = new Element(5);

            Assert.IsTrue(e3.getElement() == e4.getElement()); //(5 == 5) Passed!
            Assert.AreEqual(e3, e4);

            Element e5 = new Element(1);
            Element e6 = new Element(5);

            Assert.IsTrue(e5.getElement() != e6.getElement());
            Assert.AreNotEqual(e5, e6);

        }
        [TestMethod]
        public void Test_insertElem()
        {
            Bag bag = new Bag();
            Element e10 = new Element(1);
            bag.insertElem(e10);
            //This test will be proven when we're inserting elements to check most frequent element.
        }
        [TestMethod]
        public void Test_removeElem() //This method has two exceptions!
        {
            Bag bag = new Bag();
            try
            {
                Element e10 = new Element(1);
                bag.removeElem(e10);
                Assert.Fail("No exception thrown...");
            }
            catch (Exception ex1)
            {
                Assert.IsTrue(ex1 is ListEmptyException); //1 is not in bag so list is empty. Passed!
            }
            try
            {
                Element e20 = new Element(2);
                Element e30 = new Element(3);
                bag.insertElem(e20); 
                bag.removeElem(e30);
                Assert.Fail("No exception thrown...");
            }
            catch (Exception ex2)
            {
                Assert.IsTrue(ex2 is MatchFailedException); //Adding 2 but removing 3 so matching failed. Passed!
            }
            //Items testing
            Element e1;
            Element e2;
            Element e3;
            Element e4;
            Bag b1 = new Bag();

            b1.insertElem(e1 = new Element(6));
            b1.insertElem(e2 = new Element(72));
            b1.insertElem(e3 = new Element(59));
            b1.insertElem(e4 = new Element(51));
            //To test remove function we add some elements then remove them.
            b1.removeElem(e1);
            b1.removeElem(e2);
            b1.removeElem(e3);
            b1.removeElem(e4);

            Assert.IsTrue(b1.isEmpty()); //So remove method is working. Passed! //Also isEmpty method is working.
        }
        [TestMethod]
        public void Test_showBag()
        {
            Bag bag = new Bag();
            try
            {
                bag.showBag();
                Assert.Fail("No exception thrown...");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ListEmptyException);  //Bag is empty. Passed!
            }
            //Function is void can't test items.
        }
        [TestMethod]
        public void Test_elementFrequency()
        {
            Bag bag = new Bag();
            try
            {
                bag.elementFrequency();
                Assert.Fail("No exception thrown...");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ListEmptyException); //Bag is empty. Passed!
            }
            //Function is void can't test items.
        }
        [TestMethod]
        public void Test_mostFrequentElement()
        {
            Bag bag = new Bag();
            try
            {
                bag.mostFrequentElem();
                Assert.Fail("No exception thrown...");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ListEmptyException); //Bag is empty. Passed!
            }
            //Item testing
            Element e1;
            Element e2;
            Element e3;
            Element e4;
            Bag b1 = new Bag();
            b1.insertElem(e1 = new Element(1));
            b1.insertElem(e2 = new Element(2));
            b1.insertElem(e3 = new Element(5));
            b1.insertElem(e4 = new Element(5));

            Bag b2 = new Bag();
            b2.insertElem(e1 = new Element(1));
            b2.insertElem(e2 = new Element(2));
            b2.insertElem(e3 = new Element(5));
            b2.insertElem(e4 = new Element(5));

            Assert.IsTrue(b1.mostFrequentElem() == b2.mostFrequentElem()); //(5 != 2) Passed!

            Bag b3 = new Bag();
            b3.insertElem(e1 = new Element(5));
            b3.insertElem(e2 = new Element(2));
            b3.insertElem(e3 = new Element(5));
            b3.insertElem(e4 = new Element(7));

            Bag b4 = new Bag();
            b4.insertElem(e1 = new Element(7));
            b4.insertElem(e2 = new Element(2));
            b4.insertElem(e3 = new Element(5));
            b4.insertElem(e4 = new Element(7));

            Assert.IsTrue(b3.mostFrequentElem() != b4.mostFrequentElem());

            Bag b5 = new Bag();
            b5.insertElem(e1 = new Element(5));
            b3.insertElem(e2 = new Element(5));
            b3.insertElem(e3 = new Element(5));
            b3.insertElem(e4 = new Element(5));

            Assert.IsTrue(b5.mostFrequentElem() == 5); // Only 5 is in the list, so most frequent is 5); Passed!
            //Assert.Equals(b5.mostFrequentElem(), b3.mostFrequentElem());
        }
    }
}