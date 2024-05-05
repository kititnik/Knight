using System.Collections.Generic;

public class Inventory
{
    private Dictionary<int, int> inventory;

    public Inventory()
    {
        inventory = new Dictionary<int, int>();
    }
    public int GetItem(int itemId)
    {
        if(!inventory.ContainsKey(itemId)) return -1;
        if(inventory[itemId] == 0) return -1;
        inventory[itemId]--;
        return itemId;
    }
    public void AddItem(int itemId)
    {
        if(inventory.ContainsKey(itemId)) inventory[itemId]++;
        else inventory[itemId] = 1;
    }
}
