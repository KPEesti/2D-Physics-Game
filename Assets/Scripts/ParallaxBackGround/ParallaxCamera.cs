using System;
using UnityEngine;

public class ParallaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float deltaMovement);

    public ParallaxCameraDelegate onCameraTranslate;
    private float oldPosition;

    private void Start()
    {
        oldPosition = transform.position.x;
    }

    private void Update()
    {
        if (Math.Abs(transform.position.x - oldPosition) > 10e-10)
        {
            if (onCameraTranslate != null)
            {
                var delta = oldPosition - transform.position.x;
                onCameraTranslate(delta);
            }

            oldPosition = transform.position.x;
        }
    }
}