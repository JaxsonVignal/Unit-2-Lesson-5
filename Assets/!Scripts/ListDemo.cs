using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ListDemo : MonoBehaviour
{
   
    [SerializeField] private List<string> party = new List<string> { "Knight", "Archer" };

    private int recruitNumber = 1;

   
    private void Start()
    {
      
        Debug.Log("Party size: " + party.Count);
    }

 
    private void Update()
    {
       
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            
            string newMember = "Recruit " + recruitNumber;
 
            recruitNumber++;
            
            party.Add(newMember);
            
            Debug.Log(newMember + " joined. Party size: " + party.Count);
        }

       
        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
        {
            
            if (party.Count == 0)
            {
                
                Debug.Log("The party is empty");
               
                return;
            }

            
            string leaving = party[0];
           
            party.RemoveAt(0);
            
            Debug.Log(leaving + " left. Party size: " + party.Count);
        }

       
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
           
            foreach (string member in party)
            {
               
                Debug.Log(member);
            }
        }
    }
}