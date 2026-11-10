using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QueueDemo : MonoBehaviour
{

    [SerializeField] private float trainTime = 2f;

  
    private Queue<string> buildQueue = new Queue<string>();
 
    private float timer;

 
    private void Update()
    {
     
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
        
            AddToQueue("Villager");
        }

        
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            
            AddToQueue("Soldier");
        }

        
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            
            AddToQueue("Archer");
        }

        
        if (buildQueue.Count > 0)
        {
           
            timer += Time.deltaTime;

           
            if (timer >= trainTime)
            {
                
                string unit = buildQueue.Dequeue();
              
                Debug.Log(unit + " is ready! Still waiting: " + buildQueue.Count);
               
                timer = 0f;
            }
        }
    }

    
    private void AddToQueue(string unit)
    {
        
        buildQueue.Enqueue(unit);
       
        Debug.Log(unit + " ordered. Next up: " + buildQueue.Peek() + ". Waiting: " + buildQueue.Count);
    }
}