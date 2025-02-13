﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//public UnityEngine.UI.Button graphicsButton = null;

public class ButtonB : Interactable
{
    Animator animator;
    Door linkedDoorScript;
    public UnityEngine.UI.Button graphicsButton = null;

    public GameObject panelOff, panelOn, linkedDoor;
    //UnityEngine.UI.Button btn = yourButton.GetComponent<Button>();

    enum Type {Door, PlayerMove};
    [SerializeField]
    Type type;
    public PlayerMover playerMover;

    protected override void Start()
    {
        base.Start();
        if (linkedDoor != null) linkedDoorScript = linkedDoor.GetComponent<Door>();
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        base.Interact();
        animator.SetTrigger("Press");

        if (type == Type.PlayerMove) playerMover.MovePlayer();
        else HandleDoor();
    }

    void HandleDoor()
    {
        panelOff.SetActive(!hasInteracted);
        panelOn.SetActive(hasInteracted);
        linkedDoorScript.DoorAction(hasInteracted);
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.collider.tag == "Object") Interact();
    }
}
