using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class QuestGiver
{
    private List<Quest> _quests;

    public QuestGiver(List<Quest> quests)
    {
        _quests = quests;
    }

    public void StartQuest(GameObject player, int questIndex)
    {
        var a = player.AddComponent(_quests[questIndex].GetType()) as Quest;
        a.Title = "Test";
        a = (Quest)_quests[questIndex].Clone();
        _quests[questIndex].SetStatus(QuestStatus.InProgress);
    }

    public bool CompleteQuest(GameObject player, int questIndex)
    {
        Quest playerQuest = player.GetComponents<Quest>()
            .Where(q => q.GetType() == _quests[questIndex].GetType())
            .First();
        bool success = playerQuest.CompleteQuest();
        if(!success) return false;
        _quests.RemoveAt(questIndex);
        return true;
    }
}