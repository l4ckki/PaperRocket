using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource coinPickup;
    private float minPosX;
    private float minPosY;
    private float maxPosX;
    private float maxPosY;
    private Manager manager;

    private void Start()
    {
        manager = GameObject.Find("Main Camera").GetComponent<Manager>();
        minPosX = -5;
        maxPosX = 7;
        minPosY = -3;
        maxPosY = 3;
        coinPickup = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            manager.timer += 1f;
            coinPickup.Play();
            manager.SpawnCoin(minPosX, maxPosX, minPosY, maxPosY);
            manager.ChangeScore();
            Destroy(gameObject);
        }
    }
}
