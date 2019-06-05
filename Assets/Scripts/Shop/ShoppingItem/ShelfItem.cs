using UnityEngine;
using UnityEngine.EventSystems;

public class ShelfItem : MonoBehaviour
{
    public ShoppingItemEvent pickupEvent;

    public EShoppingItemType itemType;

    public MeshRenderer itemBody;

    public TextMesh nameText;

    public GameObject emptySlot;

    private void Start()
    {
        nameText.text = ItemUtils.ItemName(itemType);
    }

    public void SetItemType(EShoppingItemType itemType)
    {
        this.itemType = itemType;

        if (itemType == EShoppingItemType.Empty)
        {
            nameText.gameObject.SetActive(false);
            MakeTransparent(true);
            emptySlot.SetActive(true);
        }
        else
        {
            nameText.text = ItemUtils.ItemName(itemType);
            nameText.gameObject.SetActive(true);
            MakeTransparent(false);
            emptySlot.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            pickupEvent.Raise(itemType);

            SetItemType(EShoppingItemType.Empty);
        }
    }

    void MakeTransparent(bool isTransparent)
    {
        var color = itemBody.material.color;

        if (isTransparent)
        {
            itemBody.material.color =
                new Color(color.r, color.g, color.b, 0.01f);
        }
        else
        {
            itemBody.material.color =
                new Color(color.r, color.g, color.b, 1.0f);
        }
    }
}