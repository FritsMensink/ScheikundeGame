using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragAndDropGameManager : MonoBehaviour {
    public Transform ElementTilePrefab;
    public GameObject ElementObject;
    public Text result;

    public bool Won = false;

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
                float randX = Random.Range(-5, -1);
                float randZ = Random.Range(-15, 0);
                position = new Vector3(randX, 0.5f, randZ);
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
            ETile.SetText(false);
            Color c = GetElementColor(e);
            t.GetComponent<Renderer>().material.color = c;
        }
        result = GameObject.FindWithTag("Result").GetComponent<Text>();
    }

    private Color GetElementColor(Element e)
    {
        Color c = new Color(0, 0, 0, 0);
        if (e.MetaalSoort == Element.Metaal.Aardalkalimetaal) { c = new Color(1,1,0); }
        else if(e.MetaalSoort == Element.Metaal.Actinide) { c = new Color(0.94f, 0.66f, 0.88f); }
        else if (e.MetaalSoort == Element.Metaal.Alkalimetaal) { c = new Color(1, 0.66f, 0); }
        else if (e.MetaalSoort == Element.Metaal.Edelgas) { c = new Color(0, 0.66f, 1); }
        else if (e.MetaalSoort == Element.Metaal.Halogeen) { c = new Color(0.5f, 1, 0.8f); }
        else if (e.MetaalSoort == Element.Metaal.Lanthanide) { c = new Color(0.9f, 0.4f, 0.7f); }
        else if (e.MetaalSoort == Element.Metaal.Metalloïde) { c = new Color(0.61f, 1, 0); }
        else if (e.MetaalSoort == Element.Metaal.NietMetaal) { c = new Color(0, 1, 0); }
        else if (e.MetaalSoort == Element.Metaal.Overgangsmetaal) { c = new Color(0.7f, 0.4f, 0.9f); }
        else if (e.MetaalSoort == Element.Metaal.PostTransitionMetaal) { c = new Color(0, 1, 0.7f); }
        return c;
    }

    private float TimeLeft = 0;

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0)
        {
            CheckWinConditions();
            TimeLeft = 3.0f;
        }
    }

    void CheckWinConditions()
    {
        Won = true;
        ElementTile[] tiles = ElementObject.GetComponentsInChildren<ElementTile>();
        foreach (ElementTile tile in tiles)
        {
            if (!tile.IsInGoodPosition())
            {
                Won = false;
                break;
            }
        }
        if (Won)
        {
            result.text = "Je hebt gewonnen!";
            foreach (ElementTile tile in tiles)
            {
                tile.SetText(true);
            }
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
