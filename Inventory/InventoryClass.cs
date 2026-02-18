namespace CRUD;

//class
class Inventory
{
    //private fields
    private string ItemName;
    private int ItemQuantity;
    private double ItemPrice;

    //constructor
    public Inventory(string itemName, int itemQuantity, double itemPrice)
    {
        ItemName = itemName;
        ItemQuantity = itemQuantity;
        ItemPrice = itemPrice;
    }

    //setters
    public void setItemName(string itemName)
    {
        ItemName = itemName;
    }

    public void setItemQuantity(int itemQuantity)
    {
        ItemQuantity = itemQuantity;
    }

    public void setItemPrice(double itemPrice)
    {
        ItemPrice = itemPrice;
    }

    //display items and overides
    public override string ToString()
    {
        return $"{ItemName}, Quantity: {ItemQuantity}, Price: ${ItemPrice:F2}";
    }
    //display menu
    public static void Menu()
    {
        Console.WriteLine("\n=== INVENTORY SYSTEM MENU ===");
        Console.WriteLine("1. Add Item");
        Console.WriteLine("2. List Items");
        Console.WriteLine("3. Update Item");
        Console.WriteLine("4. Delete Item");
        Console.WriteLine("0. Exit");
    }
}
