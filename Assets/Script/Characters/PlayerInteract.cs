using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private IInteractable _interactable;
    private IAction _interactiveObject;


    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E) && _interactiveObject != null)
        {
           _interactiveObject.Activate();
           //Debug.Log("try to open the door");
        }   
    }


   private void OnTriggerEnter(Collider other) 
   {
        _interactable = other.gameObject.GetComponent<IInteractable>();
        _interactiveObject = other.gameObject.GetComponent<IAction>();

        if (_interactable != null)
        {
            _interactable.ToInteract(true);
           // Debug.Log("Show Interactive Message");
        }
      
   }

   private void OnTriggerStay(Collider other) 
   {
        _interactiveObject = other.gameObject.GetComponent<IAction>();
      
   }

   private void OnTriggerExit(Collider other) 
   {
        _interactable = other.gameObject.GetComponent<IInteractable>();
        
        if (_interactable != null)
        {
           // Debug.Log("Off Interactive Message");
            _interactable.ToInteract(false);
            _interactable = null;
       
        } 
        
        if(_interactiveObject != null) _interactiveObject = null;
   }
}
