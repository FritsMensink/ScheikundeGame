using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DragAndDropGameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
