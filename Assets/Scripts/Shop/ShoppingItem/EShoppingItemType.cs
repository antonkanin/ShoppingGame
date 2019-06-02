using System;

public enum EShoppingItemType
{
    Empty,
    Milk,
    Toy01,
    Toy02
}

public class ItemUtils
{
    public static string ItemName(EShoppingItemType itemType)
    {
        switch (itemType)
        {
            case EShoppingItemType.Empty:
                return "Empty";
            case EShoppingItemType.Milk:
                return "Milk";
            case EShoppingItemType.Toy01:
                return "Toy01";
            case EShoppingItemType.Toy02:
                return "Toy02";
            default:
                throw new Exception("Shopping item " + itemType + " not supported");
        } 
    }
}
