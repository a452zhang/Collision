using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour {
    [SerializeField]
    private float speed = 1.0f;
    private Transform trans;
    private void Awake()
    {
        trans = GetComponent<Transform>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        trans.Translate(Vector3.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

}
