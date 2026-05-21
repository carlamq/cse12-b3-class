using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue A(1), B(1), C(1). Check if the elements are added at the end to the correct FIFO
    // Expected Result: ToString() shows FIFO order: A, B, C
    // Defects Found:None. Enqueue was already working correctly
    public void TestPriorityQueue_FIFO()
    {
        var priorityQ = new PriorityQueue();
        priorityQ.Enqueue("A", 1);
        priorityQ.Enqueue("B", 1);
        priorityQ.Enqueue("C", 1);

        Assert.AreEqual("[A (Pri:1), B (Pri:1), C (Pri:1)]", priorityQ.ToString());
    }

    [TestMethod]
    // Scenario: A(1), B(5), C(3). This test checks that Dequeue returns the item with the highest priority
    // Expected Result: Dequeue returns B
    // Defects Found: The original loop skipped the last element and used >= instead of >, causing incorrect priority selection.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var removed = priorityQueue.Dequeue();
        Assert.AreEqual("B", removed);
    }

    [TestMethod]
    // Scenario: A(5), B(5), C(5). FIFO when multiple items share the same highest priority
    // Expected Result: Dequeue should return A first, then B, then C.
    // Defects Found: Original code used >= which broke FIFO in ties
    public void TestPriorityQueue_TieFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }
    [TestMethod]
    // Scenario: After removing the highest priority item, Dequeue
    // Expected Result: After Dequeue(), the removed item is gone and the remaining items stay in order.
    // Defects Found: The original code returned the value but never removed the item from the list
    public void TestPriorityQueue_RemovesItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        var removed = priorityQueue.Dequeue(); // should remove B
        Assert.AreEqual("B", removed);

        Assert.AreEqual("[A (Pri:1), C (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Calling Dequeue on an empty queue
    // Expected Result: Throws InvalidOperationException with the correct message.
    // Defects Found: None. The logic was already correct.
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected an InvalidOperationException to be thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }


}