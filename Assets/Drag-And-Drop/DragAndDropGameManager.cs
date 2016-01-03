using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DragAndDropGameManager : MonoBehaviour {
    public Transform ElementTilePrefab;
    public GameObject ElementObject;

	// Use this for initialization
	void Start () {
        //create all elementTiles
        List<Element> Elements = PeriodiekSysteem.Elementen;
        foreach (Element e in Elements)
        {
            Vector3 position = new Vector3();
            if (e.LeerstofVmbo)
            {
                //set random location
                position = new Vector3(2*e.x, 0.5f, (-2 * e.y));
            } else
            {
                //set proper location
                position = new Vector3((2*e.x),0.5f, (-2 * e.y));
            }
            Object o = Instantiate(ElementTilePrefab, position, Quaternion.identity);
            Transform t = (Transform)o;
            t.parent = ElementObject.transform;
            ElementTile ETile = t.GetComponent<ElementTile>();
            ETile.Element = e;
            ETile.SetText();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
