using System.Collections.Generic;

public class Inventory
{
    private Dictionary<Item, int> inventory;

    public Inventory()
    {
        inventory = new Dictionary<Item, int>();
    }
    public Item GetItem(Item item)
    {
        if(!inventory.ContainsKey(item)) return null;
        if(inventory[item] == 0) return null;
        inventory[item]--;
        return item;
    }
    public int AddItem(Item item)
    {
        if(inventory.ContainsKey(item)) inventory[item]++;
        else inventory[item] = 1;
        return inventory[item];
    }
}
