using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue 3 Elements with different priorities: A(1), B(3), C(2).
    // Expected Result: Dequeue return B first (higher priority)
    // Defect(s) Found: The Dequeue method does not remove the element from the list, it only returns it.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A",1);
        priorityQueue.Enqueue("B",3);
        priorityQueue.Enqueue("C",2);
        
        var result =priorityQueue.Dequeue();
        Assert.AreEqual("B", result);   
    }

    [TestMethod]
    // Scenario: Enqueue 2 items with the same priority: A(5), B(5).
    // Expected Result: Dequeue returns A first (FIFO).
    // Defect(s) Found: The loop in Dequeue uses >= and selects the last one with that priority, breaking FIFO. 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Try to Dequeue from an empty queue.
    // Expected Result:  InvalidOperationException with message "The queue is empty".
    // Defect(s) Found:  The code threw an exception with message "The queue is empty." instead of the required Spanish message.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch  (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
    [TestMethod]
    // Scenario: Enqueue multiple elements and perform multiple Dequeues.
    // Expected Result: Elements are returned in order of priority and FIFO.
    // Defect(s) Found: The loop in Dequeue ignored the last element due to incorrect loop condition (< _queue.Count - 1).
    public void TestPriorityQueue_MultipleDequeues()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

}