using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {
    private BoxCollider2D coll;
    private AudioSource goldAudio;
    private Renderer rend;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        goldAudio = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
    }
    private void Start() { }
    private void Update() { }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coll.enabled = false;
            goldAudio.Play();
            rend.enabled = false;
            LevelDirector.Instance.Score += 10;
            Destroy(this.gameObject,goldAudio.clip.length);
        }
    }
}
