using UnityEngine;
using System.Collections;

public class ElementTile : MonoBehaviour {
    public Element Element;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetText()
    {
        TextMesh tm = this.GetComponentInChildren<TextMesh>();
        tm.text = "" + Element.AtomischNummer + "\n" + Element.Afkorting + "\n" + Element.Naam + "\n" + Element.AtomischeZwaarte;
    }

    //TODO
    bool IsInGoodPosition(int x, int y)
    {
        bool goodPosition = false;
        Vector3 position = new Vector3(2 * x, 0.5f, (-2 * y));
        return goodPosition;
    }

    /*
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsSocket)
            {
                GetComponentInParent<Systeembord>().StartConnecting(this);
            }
        }
        else
        {
            if (IsSocket)
            {
                GetComponentInParent<Systeembord>().EndConnecting(this);
            }
        }
    }
    */
}
