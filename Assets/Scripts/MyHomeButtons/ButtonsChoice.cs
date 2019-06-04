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
        // опасно, лучше отталкиваться от float значения
        // и его уже в текст переводить для отображения.
        // это важно для простоты настройки, верификации данных
        // и в будущем локализации.
        // ScriptableObject отменно подойдёт для хранения этих данных,
        // а компонент пускай устанавливает тексты сам.
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