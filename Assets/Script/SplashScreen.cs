using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    [SerializeField]
    private string loadSceneName;

	private void Start () {
        UIManager.Instance.FadeOn(false, 1f);

	}

    private IEnumerator LoadFirstLevel()
    {
        yield return new WaitForSeconds(2f);
        UIManager.Instance.FadeOn(true,1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(loadSceneName);
    }
}
