using System;
using System.Collections.Generic;
using System.Threading;
namespace CRUD;

class Program
{
    static void Main(string[] args)
    {
        //list to store all inventory items
        List<Inventory> inv = new List<Inventory>();
        string? choice; //user menu choice
        do
        {
            Inventory.Menu(); //show menu
            choice = Console.ReadLine();

            switch (choice)
            {
                //ADD ITEMS
                case "1":
                    Console.Write("Item Name: ");
                    string? itemName = Console.ReadLine();
                    
                    //Quantity input validation
                    int amount;
                    Console.Write("Amount of items: ");
                    while (!int.TryParse(Console.ReadLine(), out amount) || amount < 0)
                    {
                        Console.WriteLine("Please enter a valid positive number for quantity.");
                    }
                    
                    //Price input validation
                    double price;
                    Console.Write("Price per item: ");
                    while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
                    {
                        Console.WriteLine("Please enter a valid positive number for price.");
                    }
                    
                    //add item to inventory
                    inv.Add(new Inventory(itemName, amount, price));
                    Console.WriteLine("Item added successfully!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    
    
                    break;
                
                //List items
                case "2":
                    if (inv.Count == 0)
                    {
                        Console.WriteLine("No items found!");
                    }
                    else
                    {
                        var idx = 1;
                        foreach (Inventory invs  in inv)
                        {
                            Console.WriteLine($"{idx}: {invs}");
                            idx++;
                        }
                    }
                    
                    break;
                //Update item
                case "3":
                    if (inv.Count == 0)
                    {
                        Console.WriteLine("No items to update!");
                        break; //exit case
                    }
                    Console.Write("Enter items to update:");
                    int index;
                    while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > inv.Count)
                    {
                        Console.WriteLine("Please enter a valid number!");
                    }

                    if (index >= 0 && index < inv.Count)
                    {
                        //Get correct item and subtract 1 for 0 base index
                        Inventory itemToUpdate = inv[index - 1];
                        
                        //update name
                        Console.Write("New Item Name: ");
                        string? newName = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(newName) || newName.Any(char.IsDigit))
                        {
                            Console.WriteLine("Please enter a valid item name.");
                        }
                        itemToUpdate.setItemName(newName);
                        
                        //update quantity
                        Console.Write("New Quantity: ");
                        int newQuantity;
                        while (!int.TryParse(Console.ReadLine(), out newQuantity) || newQuantity < 1 || newQuantity > inv.Count)
                        {
                            Console.WriteLine("Please enter a valid number!");
                        }
                        itemToUpdate.setItemQuantity(newQuantity);
                        
                        //update price
                        Console.Write("New Item Price: ");
                        int newPrice;
                        while (!int.TryParse(Console.ReadLine(), out newPrice) || newPrice < 1 || newPrice > inv.Count)
                        {
                            Console.WriteLine("Please enter a valid number!");
                        }
                        itemToUpdate.setItemPrice(newPrice);
                    }

                    break;
                
                case "4": //delete item
                    Console.WriteLine("What do you want to delete? ");
                    int indexDel;
                    while (!int.TryParse(Console.ReadLine(), out indexDel) || indexDel < 1 || indexDel > inv.Count)
                    {
                        Console.WriteLine("Please enter a valid number!");
                    }

                    if (indexDel >= 0 && indexDel < inv.Count)
                    {
                        // Remove the item at the index subtract 1 for 0 index
                        inv.RemoveAt(indexDel - 1);
                        Console.WriteLine("Item deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid!");
                    }

                    break;
                case "0": //exit
                    //simple loading screen
                    for (int cycle = 0; cycle < 3; cycle++)
                    {
                        for (int dot = 1; dot <= 3; dot++)
                        {
                            Console.Clear();
                            Console.WriteLine($"Exiting{new string('.', dot)}");
                            Thread.Sleep(400);
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Bye!");
                    Thread.Sleep(500);
                    Console.Clear();
                    break;
            }
        } while (choice != "0");
    }
}
