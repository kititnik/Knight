using System;
using UnityEngine;

public abstract class Quest : MonoBehaviour, ICloneable
{
    [field:SerializeField] public string Title {get; private set;}
    [field:SerializeField] public string Description {get; private set;}
    [field:SerializeField] public QuestStatus Status {get; private set;}

    public void SetStatus(QuestStatus newQuestStatus)
    {
        Status = newQuestStatus;
    }

    public abstract bool CompleteQuest();

    public object Clone()
    {
        return MemberwiseClone();
    }
}
