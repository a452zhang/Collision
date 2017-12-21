using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDestroy : MonoBehaviour {
    private Animator anima;
    private AudioSource audioDestroy;
    private float destroyTime = 0f;
	
	private void Awake () {
        anima = GetComponent<Animator>();
        audioDestroy = GetComponent<AudioSource>();

        if (anima)
            destroyTime = anima.GetCurrentAnimatorStateInfo(0).length;
        if (audioDestroy)
        {
            destroyTime = audioDestroy.clip.length > destroyTime ? audioDestroy.clip.length : destroyTime;
        }
        Destroy(this.gameObject, destroyTime);
    }
	
	private void Start () {
    }	
	
	private void Update () {
        
		
	}
}
