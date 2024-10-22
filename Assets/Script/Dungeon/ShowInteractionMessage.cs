using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInteractionMessage : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject _interactMessage;
    [SerializeField] String  _interactMessageText;

    public void ToInteract(bool k)
    {
        //activate message
        _interactMessage.SetActive(k);
    }
}