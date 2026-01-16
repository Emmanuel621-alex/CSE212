using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    // Test for adding and removing a single element with priority
    [TestMethod]
    // Scenario: Enqueue one item and dequeue it.
    // Expected Result: Dequeued item should match the enqueued item with the correct priority.
    // Defect(s) Found: None expected; test passed successfully.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task 1", 1);

        // Act
        var result = priorityQueue.Dequeue();

        // Assert
        Assert.AreEqual("Task 1", result);
    }

    // Test for adding multiple elements with different priorities
    [TestMethod]
    // Scenario: Enqueue multiple items and dequeue them based on priority.
    // Expected Result: Dequeue should return items in order of decreasing priority.
    // Defect(s) Found: Test failed; expected order was Task 3, Task 2, Task 1.
    // Possible Issue: Dequeue method may not correctly identify and remove highest priority item.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task 1", 1);
        priorityQueue.Enqueue("Task 2", 2);
        priorityQueue.Enqueue("Task 3", 3);

        // Act
        var firstResult = priorityQueue.Dequeue(); // Should be Task 3
        var secondResult = priorityQueue.Dequeue(); // Should be Task 2
        var thirdResult = priorityQueue.Dequeue(); // Should be Task 1

        // Assert
        Assert.AreEqual("Task 3", firstResult);
        Assert.AreEqual("Task 2", secondResult);
        Assert.AreEqual("Task 1", thirdResult);
    }

    // Test for multiple items with the same highest priority
    [TestMethod]
    // Scenario: Add items with the same priority.
    // Expected Result: Dequeue should return the first item added with the same priority.
    // Defect(s) Found: Test failed; expected order was Task 1, Task 2.
    // Possible Issue: FIFO order may not be preserved for equal priority items.
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task 1", 2);
        priorityQueue.Enqueue("Task 2", 2);
        priorityQueue.Enqueue("Task 3", 1);

        // Act
        var firstResult = priorityQueue.Dequeue(); // Should be Task 1
        var secondResult = priorityQueue.Dequeue(); // Should be Task 2

        // Assert
        Assert.AreEqual("Task 1", firstResult);
        Assert.AreEqual("Task 2", secondResult);
    }

    // Test for dequeuing from an empty queue
    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException should be thrown.
    // Defect(s) Found: None expected; exception was thrown as specified.
    [ExpectedException(typeof(InvalidOperationException), "The queue is empty.")]
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        
        // Act
        var result = priorityQueue.Dequeue(); // This should throw an exception
    }
}