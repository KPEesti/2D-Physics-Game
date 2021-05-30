using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Rigidbody2D.bodyType != RigidbodyType2D.Dynamic)
            Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
}
