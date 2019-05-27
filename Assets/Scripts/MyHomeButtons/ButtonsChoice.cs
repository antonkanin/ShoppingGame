using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsChoice : MonoBehaviour
{
    [SerializeField] private Sprite furniture = null;
    [SerializeField] private GameObject buttonFurniture = null;
    [SerializeField] private Text money = null;
    [SerializeField] private Text price = null;
    [SerializeField] private GameObject panelNoMany = null;
    private float _couterMoney;

    public void ChoiceFurniture() 
    {
       if (float.Parse(money.text) >= float.Parse(price.text))
        {
            buttonFurniture.GetComponent<Image>().sprite = furniture;
            _couterMoney = float.Parse(money.text) - float.Parse(price.text);
            
            money.text = _couterMoney.ToString();
        }
        else
        {
            panelNoMany.gameObject.SetActive(true);
            StartCoroutine(Wait());
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1);
            panelNoMany.gameObject.SetActive(false);
        }
      
    }
}