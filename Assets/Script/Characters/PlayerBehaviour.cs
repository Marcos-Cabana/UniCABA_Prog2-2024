using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private ItemObject item;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        item = other.GetComponent<ItemObject>();
        
        if(item != null && item.IsCollectable)
            {
                Debug.Log("I Try to get one");
                item.OnPickUp();
            }
  
    }

}
