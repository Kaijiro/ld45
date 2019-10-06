using System;
using System.Linq;
using UnityEngine;

public class EndLevelScript : MonoBehaviour
{
    public QuestLog QuestLog;
    public int numberOfQuestNeeded;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (QuestLog.Quests.Count(quest => quest.isFinished) >= numberOfQuestNeeded)
        {
            Debug.Log("Victory !");
        }
        else
        {
            Debug.Log("Someone still needs you !");
        }
    }
}
