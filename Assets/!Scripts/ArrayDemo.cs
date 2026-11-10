// Gives access to MonoBehaviour and Debug
using UnityEngine;
// Gives access to Keyboard.current
using UnityEngine.InputSystem;

// Shows how an array works: a fixed number of numbered slots
public class ArrayDemo : MonoBehaviour
{
    // An array of words with 3 slots; you can change them in the Inspector
    [SerializeField] private string[] weapons = { "Sword", "Bow", "Staff" };

    // Which slot is equipped right now
    private int currentIndex = 0;

    // Runs once when you press Play
    private void Start()
    {
        // Length is how many slots the array has
        Debug.Log("The array has " + weapons.Length + " slots");
        // Slots start at 0, so [0] is the first one
        Debug.Log("Slot 0 holds " + weapons[0]);

        // Go through every slot, one at a time, starting at 0
        for (int i = 0; i < weapons.Length; i++)
        {
            // Print the slot number and what's in it
            Debug.Log("Slot " + i + ": " + weapons[i]);
        }
    }

    // Runs every frame
    private void Update()
    {
        // Space switches to the next weapon
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Move to the next slot
            currentIndex++;

            // Past the last slot: go back to slot 0
            if (currentIndex >= weapons.Length)
            {
                // Back to the first weapon
                currentIndex = 0;
            }

            // Show what's equipped now
            Debug.Log("Equipped: " + weapons[currentIndex]);
        }
    }
}