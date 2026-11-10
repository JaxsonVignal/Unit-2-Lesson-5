// Gives access to Queue
using System.Collections.Generic;
// Gives access to MonoBehaviour, Time and Debug
using UnityEngine;
// Gives access to Keyboard.current
using UnityEngine.InputSystem;

// A build queue like a strategy game: units are trained in the order they were ordered
public class QueueDemo : MonoBehaviour
{
    // Seconds it takes to train one unit
    [SerializeField] private float trainTime = 2f;

    // The units waiting to be trained, oldest at the front; Queues don't show in the Inspector
    private Queue<string> buildQueue = new Queue<string>();
    // Seconds spent on the unit at the front so far
    private float timer;

    // Runs every frame
    private void Update()
    {
        // 1: order a Villager
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            // Add it to the back of the line
            AddToQueue("Villager");
        }

        // 2: order a Soldier
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            // Add it to the back of the line
            AddToQueue("Soldier");
        }

        // 3: order an Archer
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            // Add it to the back of the line
            AddToQueue("Archer");
        }

        // Only count time while something is waiting
        if (buildQueue.Count > 0)
        {
            // Add the time since the last frame
            timer += Time.deltaTime;

            // The unit at the front is done
            if (timer >= trainTime)
            {
                // Dequeue takes the unit at the FRONT of the line
                string unit = buildQueue.Dequeue();
                // Show it
                Debug.Log(unit + " is ready! Still waiting: " + buildQueue.Count);
                // Start timing the next one from 0
                timer = 0f;
            }
        }
    }

    // Puts a unit at the back of the line
    private void AddToQueue(string unit)
    {
        // Enqueue adds it to the BACK of the line
        buildQueue.Enqueue(unit);
        // Peek shows who's at the front without removing them
        Debug.Log(unit + " ordered. Next up: " + buildQueue.Peek() + ". Waiting: " + buildQueue.Count);
    }
}