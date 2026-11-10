// Gives access to MonoBehaviour, Rigidbody2D, Vector2 and Random
using UnityEngine;
// Gives access to Keyboard.current
using UnityEngine.InputSystem;

// Pushes a random box up when Space is pressed, using an array
public class ArrayForces : MonoBehaviour
{
    // The boxes' Rigidbody 2Ds; drag them in, in the Inspector
    [SerializeField] private Rigidbody2D[] bodies;
    // How hard to push
    [SerializeField] private float force = 8f;

    // Runs every frame
    private void Update()
    {
        // Space was pressed this frame
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Pick a random slot (the max is never picked, so it's always a real slot)
            int index = Random.Range(0, bodies.Length);
            // Push that box straight up with one quick shove
            bodies[index].AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}