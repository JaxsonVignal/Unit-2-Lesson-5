// Gives access to List
using System.Collections.Generic;
// Gives access to MonoBehaviour and Debug
using UnityEngine;
// Gives access to Keyboard.current
using UnityEngine.InputSystem;

// Shows how a List works: it grows and shrinks while the game runs
public class ListDemo : MonoBehaviour
{
    // A list of names that starts with 2 members; it shows in the Inspector like an array
    [SerializeField] private List<string> party = new List<string> { "Knight", "Archer" };

    // Used to give each new recruit a different number
    private int recruitNumber = 1;

    // Runs once when you press Play
    private void Start()
    {
        // Count is how many items are in the list right now
        Debug.Log("Party size: " + party.Count);
    }

    // Runs every frame
    private void Update()
    {
        // Space: someone joins the party
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Make a name like "Recruit 1"
            string newMember = "Recruit " + recruitNumber;
            // The next recruit gets the next number
            recruitNumber++;
            // Add puts it at the end of the list; the list grows by 1
            party.Add(newMember);
            // Show what happened
            Debug.Log(newMember + " joined. Party size: " + party.Count);
        }

        // Backspace: the first member leaves
        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
        {
            // Nobody to remove: stop here, or RemoveAt would cause an error
            if (party.Count == 0)
            {
                // Say so
                Debug.Log("The party is empty");
                // Stop here
                return;
            }

            // Remember who's in slot 0 before removing them
            string leaving = party[0];
            // Remove slot 0; everyone else moves up one slot
            party.RemoveAt(0);
            // Show what happened
            Debug.Log(leaving + " left. Party size: " + party.Count);
        }

        // P: print everyone in the party
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            // foreach visits every item in the list, one at a time
            foreach (string member in party)
            {
                // Print this member
                Debug.Log(member);
            }
        }
    }
}