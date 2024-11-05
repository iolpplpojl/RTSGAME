using System;
using UnityEngine;
using UnityEngine.Events;

public class SpriteButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    BoxCollider2D col;
    public UnityEvent func;

    void Start()
    {
        col = GetComponent <BoxCollider2D>();
    }

    private void OnMouseUpAsButton()
    {
        // Runs when button is released
        func.Invoke();
    }

}
