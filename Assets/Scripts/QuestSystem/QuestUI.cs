using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private TMP_Text titleTxt;
    //[SerializeField] private TMP_Text descriptionTxt;
    [SerializeField] private TMP_Text statusTxt;
    [SerializeField] private Button markQuestBtn;
    [SerializeField] private Button showInfoBtn;

    public void Initialize(string title, string description, string status, int index, MarkQuestDel markQuestDel)
    {
        titleTxt.text = title;
        //descriptionTxt.text = description;
        statusTxt.text = status;
        markQuestBtn.onClick.AddListener(() => markQuestDel(index));
    }
}
