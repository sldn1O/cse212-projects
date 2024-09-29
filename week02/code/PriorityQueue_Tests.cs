using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add a single item to the queue and then dequeue it.
    // Expected Result: The value of the dequeued item should match the enqueued item.
    // Defect(s) Found: If the dequeued item does not match the enqueued item, it indicates a failure in the enqueue or dequeue logic.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", result);
    }

    [TestMethod]
    // Scenario: Add multiple items with different priorities and dequeue them.
    // Expected Result: Dequeue should return items in order of highest priority.
    // Defect(s) Found: If the order of dequeued items does not match the expected order based on priority, there is a defect in priority handling.
    public void TestPriorityQueue_MultiplePriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1); // Lowest priority
        priorityQueue.Enqueue("Item2", 3); // Highest priority
        priorityQueue.Enqueue("Item3", 2); // Medium priority
        
        var result1 = priorityQueue.Dequeue(); // Should be Item2
        var result2 = priorityQueue.Dequeue(); // Should be Item3
        var result3 = priorityQueue.Dequeue(); // Should be Item1

        Assert.AreEqual("Item2", result1);
        Assert.AreEqual("Item3", result2);
        Assert.AreEqual("Item1", result3);
    }

    [TestMethod]
    // Scenario: Add multiple items with the same priority and dequeue them.
    // Expected Result: Dequeue should return items in the order they were added (FIFO).
    // Defect(s) Found: If the order of dequeued items does not follow the FIFO strategy among items with the same priority, it indicates a defect.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 2);
        priorityQueue.Enqueue("Item3", 2);

        var result1 = priorityQueue.Dequeue(); // Should be Item1
        var result2 = priorityQueue.Dequeue(); // Should be Item2
        var result3 = priorityQueue.Dequeue(); // Should be Item3

        Assert.AreEqual("Item1", result1);
        Assert.AreEqual("Item2", result2);
        Assert.AreEqual("Item3", result3);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: An exception should be thrown indicating that the queue is empty.
    // Defect(s) Found: If no exception is thrown or if the message is incorrect, there is a defect in the empty queue handling.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("Queue is empty.", e.Message);
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception type: {e.GetType()} with message: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Enqueue and dequeue items with negative and zero priorities.
    // Expected Result: Items should be dequeued based on their priority (0 and negative should be treated as valid priorities).
    // Defect(s) Found: If the handling of negative and zero priorities is incorrect, it indicates a defect in the priority handling logic.
    public void TestPriorityQueue_NegativeZeroPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 0); // Priority 0
        priorityQueue.Enqueue("Item2", -1); // Negative priority
        priorityQueue.Enqueue("Item3", 2); // Higher priority
        
        var result1 = priorityQueue.Dequeue(); // Should be Item3
        var result2 = priorityQueue.Dequeue(); // Should be Item1
        var result3 = priorityQueue.Dequeue(); // Should be Item2

        Assert.AreEqual("Item3", result1);
        Assert.AreEqual("Item1", result2);
        Assert.AreEqual("Item2", result3);
    }
}
