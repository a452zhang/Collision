using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTest : MonoBehaviour {
    public Image image1, image2;
    public Color color1, color2;
	private void Start () {
		
	}	
	
	private void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Test.FadeImage(image1,5f,color1));
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(Test.FadeImage(image2,5f,color2));
        }
	}
}
