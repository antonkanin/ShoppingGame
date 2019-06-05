using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsChoice : MonoBehaviour
{
    [SerializeField] private Sprite spriteFurniture = null;
    [SerializeField] private GameObject furniture = null;
    [SerializeField] private Text money = null;
    [SerializeField] private Text price = null;
    [SerializeField] private GameObject panelNoMany = null;
    [SerializeField] private int counter = 0;
    private float _couterMoney;

    public void ChooseFurniture() 
    {
        ++counter;
        furniture.GetComponent<Image>().sprite = spriteFurniture;
        if (counter % 2 == 0) 
        {    
            if (float.Parse(money.text) >= float.Parse(price.text))
            {
                furniture.GetComponent<Image>().sprite = spriteFurniture;
                _couterMoney = float.Parse(money.text) - float.Parse(price.text);
                
                price.text = "0";

                money.text = _couterMoney.ToString();
            }
            else
            {
                panelNoMany.gameObject.SetActive(true);
                StartCoroutine(Wait());
            }
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1);
            panelNoMany.gameObject.SetActive(false);
        }
      
    }
}