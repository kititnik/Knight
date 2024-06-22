using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class QuestPoint : MonoBehaviour, IInteractable
{
    [SerializeField] private QuestInfoSO questInfoForPont;
    [SerializeField] private bool startPoint;
    [SerializeField] private bool finishPoint;
    private string questId;
    private QuestState currentQuestState;

    private void Awake()
    {
        questId = questInfoForPont.Id;
        
    }

    private void OnEnable()
    {
        EventsManager.instance.QuestEvents.OnQuestStateChange += QuestStateChange;
    }
    private void OnDisable()
    {
        EventsManager.instance.QuestEvents.OnQuestStateChange -= QuestStateChange;
    }

    private void QuestStateChange(Quest quest)
    {
        if(quest.Info.Id == questId)
        {
            currentQuestState = quest.State;
        }
    }

    public void Invoke(GameObject player, GameObject interactionUI)
    {
        if(currentQuestState == QuestState.CanStart && startPoint)
        {
            EventsManager.instance.QuestEvents.StartQuest(questId);
        }
        else if(currentQuestState == QuestState.CanFinish && finishPoint)
        {
            EventsManager.instance.QuestEvents.FinishQuest(questId);
        }
    }
}
