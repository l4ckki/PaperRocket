using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireChanger : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    public Sprite[] sprites;
    private float timeChange = 5f;
    private float time;
    private int count;

    private void Start()
    {
        count = 0;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        float change = 1 / timeChange;
        if (time >= change)
        {
            ChangeFire();
            time = 0f;
        }
    }

    private void ChangeFire()
    {   
        if (count > sprites.Length - 2)
        {
            count = 0;
        }
        else
        {
            count++;
        }
        spriteRend.sprite = sprites[count];
    }


}
