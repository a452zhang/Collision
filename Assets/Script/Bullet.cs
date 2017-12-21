using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField]
    private float speed = 1.0f;
    private Transform trans;
	
	private void Awake () {
        trans = GetComponent<Transform>();
    }
	
	private void Start () {
		
	}	
	
	private void Update () {
        trans.Translate(Vector3.up*Time.deltaTime*speed);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Monster")
        {
            Destroy(this.gameObject);
        }
    }
}
