using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintVisualScript : MonoBehaviour
{
    private Color green;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        green = Color.green;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = green;
        Debug.Log("collision");
    }

}
