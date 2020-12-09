using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomColorComponent : MonoBehaviour
{
    [SerializeField] private Gradient[] gradients;

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int randomGradient = Random.Range(0,gradients.Length);
        Gradient gradient = gradients[randomGradient];
        spriteRenderer.color = gradient.Evaluate(Random.Range(0,1));
    }

}
