using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ParallaxBackground : MonoBehaviour
{
    public ParallaxCamera parallaxCamera;
    readonly List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer>();

    private void Start()
    {
        if (parallaxCamera == null)
            parallaxCamera = UnityEngine.Camera.main.GetComponent<ParallaxCamera>();
        if (parallaxCamera != null)
            parallaxCamera.onCameraTranslate += Move;
        SetLayers();
    }

    private void SetLayers()
    {
        parallaxLayers.Clear();
        for (var i = 0; i < transform.childCount; i++)
        {
            var layer = transform.GetChild(i).GetComponent<ParallaxLayer>();

            if (layer != null)
            {
                parallaxLayers.Add(layer);
            }
        }
    }

    private void Move(float delta)
    {
        foreach (var layer in parallaxLayers) layer.Move(delta);
    }
}