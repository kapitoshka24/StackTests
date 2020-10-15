using System;
using NUnit.Framework;
using Lab1_Stack;
using System.Collections;

namespace NUnitStackTests
{
    public class StackTests
    {
        private MyStack<string> myStack;

        [SetUp]
        public void Setup()
        {
            myStack = new MyStack<string>();
        }

        [Test]
        public void IsEmpty_StackIsEmpty_ReturnTrue()
        {
            var result = myStack.IsEmpty;

            Assert.IsTrue(result, "Stack should be empty");
        }

        [Test]
        public void Count_StackWith3Elem_Returns3()
        {
            myStack.Push("a");
            myStack.Push("b");
            myStack.Push("c");

            var result = myStack.Count;

            Assert.AreEqual(3, result);
        }

        [TestCase("a")]
        [TestCase("1")]
        [TestCase("Natasha")]
        public void Push_EnterValue_ReturnThatValue(string value)
        {
            myStack.Push(value);

            var result = myStack.Peek();

            Assert.AreEqual(value, result);
        }

        [TestCase("Natasha")]
        [TestCase("Prog")]
        [TestCase("19")]
        public void Pop_DeleteValue_ReturnThatValue(string value)
        {
            myStack.Push(value);
           
            var result = myStack.Pop();

            Assert.AreEqual(value, result);
        }

        [Test]
        public void Peek_ReturnStackPeek()
        {
            myStack.Push("a");
            myStack.Push("b");
            myStack.Push("c");

            string[] actualArray = new string[3];
            myStack.CopyTo(actualArray, 0);
            
            var result = myStack.Peek();

            Assert.AreEqual(actualArray[2], result);
        }
        [Test]
        public void ReturnEmpty_StackIsEmpty_ExpectedInvalidOperationException()
        {
            try
            { 
                myStack.ReturnEmpty();
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "Stack is empty!");
                return;
            }
            Assert.Fail("No exception was thrown!");
        }
        [Test]
        public void ReturnEmptyForPop_StackIsEmpty_ExpectedInvalidOperationException()
        {
            try
            {
                var res = myStack.Pop();
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "Stack is empty!");
                return;
            }
            Assert.Fail("No exception was thrown!");
        }
        [Test]
        public void ReturnEmptyForPeek_StackIsEmpty_ExpectedInvalidOperationException()
        {
            try
            {
                myStack.Peek();
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "Stack is empty!");
                return;
            }
            Assert.Fail("No exception was thrown!");
        }
        [Test]
        public void IEnumerator_ReturnsActualValuesInStack()
        {
            myStack.Push("a");
            myStack.Push("b");
            myStack.Push("c");

            int index = 0;
            string[] expectedArray = new string[3];

            myStack.CopyTo(expectedArray, 0);

            foreach (var item in myStack)
            {
                Assert.AreEqual(expectedArray[expectedArray.Length - ++index], item);
            }

        }
    }
}