using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingInteractable : Interactable
{
    public Dialogue dialogue;

    public override void OnInteract()
    {
        FindObjectOfType<DialogueDisplayer>().StartDialogue(dialogue);
    }
}
