using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    [SerializeField]
    private float time = 1f;	
	private void Awake () {
		
	}
	
	private void Start () {
        Destroy(this.gameObject,time);
	}	
	
	private void Update () {
		
	}
}
