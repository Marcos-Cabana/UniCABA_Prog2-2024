using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class DoorController : MonoBehaviour, IAction
{
    Animator animator;
    //[SerializeField] ShowInteractionMessage _showInteractionMessage;
    [SerializeField] private bool _needKey;
    [SerializeField] private bool _needSpecialKey;

    bool _open = false;

    public bool NeedKey{ get { return _needKey; } }
    
    private void Start() {
        animator = GetComponent<Animator>();
    }
    //solo  abrir y /o cerrar la puerta
    // Start is called before the first frame update
   /* public void ToInteract(bool showMessage)
    {
        _showInteractionMessage.ShowMessage(showMessage);
        //Show message
    }*/
    
    public void Activate()
    {
        //_open = !_open;

        animator.SetBool("DoorOpen",true);
    }

}
