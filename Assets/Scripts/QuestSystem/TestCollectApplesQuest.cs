using UnityEngine;

public class TestCollectApplesQuest : Quest
{
    private int appleId = 0;
    private int requiredAppleQuantity = 5;
    private int _currentApplesCount = 0;
    private InventoryHandler _inventoryHandler;

    private void Start()
    {
        _inventoryHandler = GetComponent<InventoryHandler>();
    }

    public override bool CompleteQuest()
    {
        _currentApplesCount = _inventoryHandler.GetItemCount(appleId);
        if (_currentApplesCount >= requiredAppleQuantity) 
        {
            _inventoryHandler.RemoveItem(appleId, requiredAppleQuantity);
            Debug.Log("Done");
            Destroy(this);
            return true;
        }
        Debug.Log("Not done");
        return false;
    }
}
