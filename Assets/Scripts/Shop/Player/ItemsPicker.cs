using UnityEngine;

public class ItemsPicker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] pickedItems;

    private int itemsCount = 0;

    void Start()
    {
        foreach (var item in pickedItems)
        {
            item.SetActive(false);
        }
    }

    public void AddItem()
    {
        if (pickedItems.Length <= itemsCount)
        {
            return;
        }

        pickedItems[itemsCount].SetActive(true);

        ++itemsCount;
    }
}