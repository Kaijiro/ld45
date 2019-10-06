using UnityEngine;

public class QuestGiverInteractable : TalkingInteractable
{
    public QuestLog playerQuestLog;
    public Quest quest;
    public Inventory playerInventory;

    public Dialogue waitingForQuestItemDialogue;
    public Dialogue endQuestDialogue;

    public override void OnInteract()
    {
        if (playerQuestLog.Contains(quest))
        {
            Dialogue questDialogue;
            if (playerInventory.Contains(quest.requiredObjectId))
            {
                questDialogue = endQuestDialogue;
            }
            else
            {
                questDialogue = waitingForQuestItemDialogue;
            }
            
            FindObjectOfType<DialogueDisplayer>().StartDialogue(questDialogue);
        }
        else
        {
            base.OnInteract(); // Display dialog line
            playerQuestLog.Accept(quest);
        }
    }
}
