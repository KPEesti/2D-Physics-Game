using System.Collections;
using UnityEngine;

public class SpawnSmth : MonoBehaviour
{
    [SerializeField] private int amount;
    [SerializeField] private GameObject dropPrefab;
    [SerializeField] private float delay;

    public void StartSpawning()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        for (var i = 0; i < amount; i++)
        { 
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
}
