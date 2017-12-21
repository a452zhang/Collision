using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRoll : MonoBehaviour {
    private Renderer rend;
    private Material mat;
    [SerializeField]
    private float speed = 1f;
	
	private void Awake () {
        rend = GetComponent<Renderer>();
        mat = rend.material;
	}
	
	private void Start () {
		
	}	
	
	private void Update () {
        mat.SetTextureOffset("_MainTex", new Vector2(0,Time.time*speed));
    }
}
