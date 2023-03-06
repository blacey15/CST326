using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animatedSprites;

    public float time = 1f;

    private SpriteRenderer sr;
    public System.Action killed;

    private int frame;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(animateSprite), time, time);
    }

    private void animateSprite()
    {
        frame++;
        if (frame >= animatedSprites.Length)
        {
            frame = 0;
        }

        sr.sprite = animatedSprites[frame];
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            killed.Invoke();
            gameObject.SetActive(false);
        }
    }
}
