using System.Collections;
using UnityEngine;

public class HitTower : MonoBehaviour
{
    public MeshRenderer head;

    public float shockDuration = 3.0f;

    public GameEvent fightModeOffEvent;

    private Shooting shooting;

    private bool isAcceptingHits = false;

    private void Start()
    {
        shooting = GetComponent<Shooting>();
    }

    public void AcceptHitsEnable()
    {
        isAcceptingHits = true;
    }

    public void AcceptHitsDisable()
    {
        isAcceptingHits = false;
    }

    private void OnMouseDown()
    {
        if (isAcceptingHits)
        {
            Debug.Log("Tower was hit");
            fightModeOffEvent.Raise();
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