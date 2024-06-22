using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectApplesQuestStep : QuestStep
{
    private int applesCollected = 0;
    private int applesToComplete = 5;
    private int appleId = 0;

    private void OnEnable()
    {
        EventsManager.instance.InventoryEvents.onInventoryChange += OnInventoryUpdate;
    }

    private void OnDisable()
    {
        EventsManager.instance.InventoryEvents.onInventoryChange -= OnInventoryUpdate;
    }

    public void OnInventoryUpdate(int itemId, InventoryEvent kind)
    {
        if(itemId == appleId && kind == InventoryEvent.AddItem)
        {
            applesCollected++;
        }
        if(itemId == appleId && kind == InventoryEvent.RemoveItem)
        {
            applesCollected--;
        }
        if(applesCollected >= applesToComplete)
        {
            FinishQuestStep();
        }
    }
}
