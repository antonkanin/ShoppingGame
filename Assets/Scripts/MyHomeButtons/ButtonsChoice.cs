using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsChoice : MonoBehaviour
{
    [SerializeField] private Sprite spriteFurniture = null;
    [SerializeField] private GameObject imageFurniture = null;
    [SerializeField] private Text money = null;
    [SerializeField] private Text price = null;
    [SerializeField] private GameObject panelNoMany = null;
    [SerializeField] private int counter = 0;
    private float _couterMoney;

    //[SerializeField] private GameObject panel = null;
    //private bool objectActive = false;
    //[SerializeField] private Sprite newImageFurniture = null;
    //[SerializeField] private int newImageFurnit = 0;

    public void ChooseFurniture() 
    {   
        //newImageFurniture =  imageFurniture.GetComponent<Image>().sprite;
        ++counter;
        imageFurniture.GetComponent<Image>().sprite = spriteFurniture;
        if (counter % 2 == 0) 
        {    
            if (float.Parse(money.text) >= float.Parse(price.text))
            {
                imageFurniture.GetComponent<Image>().sprite = spriteFurniture;
                _couterMoney = float.Parse(money.text) - float.Parse(price.text);
                
                price.text = "0";

                money.text = _couterMoney.ToString();
                //++newImageFurnit; 
                
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

     /*public void showhidePannel()
    {
        if (newImageFurnit%2 == 0) print(" newImageFurnit false");
        else if (newImageFurnit%2 != 0) print(" newImageFurnit true");

        if (objectActive == true && newImageFurnit%2 != 0) 
        {   
            print("цвет изменен");
            panel.gameObject.SetActive(false);
            objectActive = false;
        }
        else if (objectActive == true && newImageFurnit%2 == 0)
        {
            //imageFurniture.GetComponent<Image>().sprite = newImageFurniture;
            print("цвет не изменен");
            panel.gameObject.SetActive(false);
            objectActive = false;
        }
        else if (objectActive == false)
        {
            panel.gameObject.SetActive(true);
            objectActive = true;
        }
    }*/
}