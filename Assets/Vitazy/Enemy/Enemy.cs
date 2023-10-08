using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public GameObject player;
    private float speed = 5.0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerPos = player.GetComponent<Transform>();
        transform.LookAt(playerPos.position);
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        if (transform.position == playerPos.position)
        {
            Destroy(this.gameObject);
            player.GetComponent<TowerControl>().HP -= 1;
        };
    }
}
