using System;
using System.Collections;
using UnityEngine;

public class HitReaction : MonoBehaviour
{
    public InputController input;

    public float slowDownTime;

    void OnCollisionEnter(Collision other)
    {
        // я бы вместо тега использовал компоненты 
        // (повесил на все патроны компонент Bullet)
        // тег на объект можно поставить только один,
        // да и строки сравнивать - дело такое.
        // всегда кто-то может ошибиться и не такой тег написать, например.
        const string BULLET_TAG = "Bullet";

        if (other.gameObject.CompareTag(BULLET_TAG))
        {
            // здесь сделал бы так, опять же строки - дело гиблое
            StartCoroutine(SlowDown());
        }
    }

    IEnumerator SlowDown()
    {
        // вообще playerSpeed кажется свойством персонажа, не контроллера
        var originalSpeed = input.playerSpeed;
        input.playerSpeed = 0;

        // здесь есть проблема; что если playerSpeed поменяется в это время?
        yield return new WaitForSeconds(slowDownTime);

        // мы потеряем эти изменения, перезапишем на сохранённое значение
        input.playerSpeed = originalSpeed;

        // чтобы этого избежать, предлагаю хранить два значения скорости: 
        // одним управляет игрок, другим игра
        // здесь менять второе. Для движения применять их произведение.
    }
}