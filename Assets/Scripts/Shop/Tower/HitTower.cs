using System.Collections;
using UnityEngine;

public class HitTower : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer head;

    public float shockDuration = 3.0f;

    private Shooting shooting;

    private void Start()
    {
        shooting = GetComponent<Shooting>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PickedItem"))
        {
            StartCoroutine("TowerShock");
        }
    }

    IEnumerator TowerShock()
    {
        Disable();

        yield return new WaitForSeconds(shockDuration);

        Enable();
    }

    void Disable()
    {
        head.material.color = Color.gray;
        shooting.enabled = false;
    }

    void Enable()
    {
        head.material.color = Color.green;
        shooting.enabled = true;
    }
}