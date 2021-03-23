using System.Collections;
using UnityEngine;

public class SpawnSmth : MonoBehaviour
{
    [SerializeField] private int amount;
    [SerializeField] private GameObject dropPrefab;
    [SerializeField] private float delay;

    private Coroutine Do() => StartCoroutine(Spawn());

    private IEnumerator Spawn()
    {
        for (var i = 0; i < amount; i++)
        {
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }

    private void OnEnable() => Lever.LeverAction += Do;

    private void OnDisable() => Lever.LeverAction -= Do;
}
