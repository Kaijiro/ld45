using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour
{
    public List<Quest> Quests;

    private void Start()
    {
        Quests = new List<Quest>();
    }

    public void Accept(Quest quest)
    {
        if (!Quests.Contains(quest))
        {
            Quests.Add(quest);
        }
    }

    public bool Contains(Quest quest)
    {
        return Quests.Contains(quest);
    }

    public void FinishQuest(Quest quest)
    {
        if (Quests.Contains(quest))
        {
            quest.isFinished = true;
        }
    }
}
