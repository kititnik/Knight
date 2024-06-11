using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void MarkQuestDel(int index);

public class QuestBoard : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Quest> questList;
    [SerializeField] private GameObject questUI;
    [SerializeField] private GameObject questBoardUI;
    private Transform questBoardUIContent;
    private GameObject _player;
    private GameObject _interactionUI;
    private QuestGiver _questGiver;
    private MarkQuestDel _markQuestDel;
    public void Invoke(GameObject player, GameObject interactionUI)
    {
        _player = player;
        _interactionUI = interactionUI;
        _questGiver = new QuestGiver(questList);
        _markQuestDel = MarkQuest;
        CreateUIContent();
    }

    private void CreateUIContent()
    {
        GameObject board = Instantiate(questBoardUI, _interactionUI.transform);
        questBoardUIContent = board.transform.GetChild(0);
        for(int i = 0; i < questList.Count; i++)
        {
            var quest = questList[i];
            var go = Instantiate(questUI, questBoardUIContent);
            go.GetComponent<QuestUI>().Initialize(quest.Title, quest.Description, quest.Status.ToString(), i, _markQuestDel);
        }
    }

    public void MarkQuest(int questIndex)
    {
        var questStatus = questList[questIndex].Status;
        if(questStatus == QuestStatus.NotStarted)
            _questGiver.StartQuest(_player, questIndex);
        else if(questStatus == QuestStatus.InProgress)
            _questGiver.CompleteQuest(_player, questIndex);
    }
}
