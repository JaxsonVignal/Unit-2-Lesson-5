
using UnityEngine;
using UnityEngine.InputSystem;


public class ArrayDemo : MonoBehaviour
{
   
    [SerializeField] private string[] weapons = { "Sword", "Bow", "Staff" };

    private int currentIndex = 0;

   
    private void Start()
    {
        
        Debug.Log("The array has " + weapons.Length + " slots");
        
        Debug.Log("Slot 0 holds " + weapons[0]);

        
        for (int i = 0; i < weapons.Length; i++)
        {
            
            Debug.Log("Slot " + i + ": " + weapons[i]);
        }
    }

    
    private void Update()
    {
        
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            
            currentIndex++;

            
            if (currentIndex >= weapons.Length)
            {
               
                currentIndex = 0;
            }

            
            Debug.Log("Equipped: " + weapons[currentIndex]);
        }
    }
}