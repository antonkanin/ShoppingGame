using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyAccount : MonoBehaviour
{
    //public float counterMoney {get; set;} = 0;
    public float counterMoney;

    public float CounterMoney
    {
        get{return counterMoney;}
        set{counterMoney = value;}
    }
}
