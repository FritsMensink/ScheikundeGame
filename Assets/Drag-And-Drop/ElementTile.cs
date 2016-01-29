using UnityEngine;
using System.Collections;

public class ElementTile : MonoBehaviour {
    public Element Element;
    private bool dragging = false;

    // Use this for initialization
    void Start () {
	    
	}

    public void SetText(bool complete)
    {
        TextMesh tm = this.GetComponentInChildren<TextMesh>();
        if (complete)
            tm.text = "" + Element.AtomischNummer + "\n" + Element.Afkorting + "\n" + Element.Naam + "\n" + System.Math.Round(Element.AtomischeZwaarte, 4);
        else
            tm.text = " " + "\n" + Element.Afkorting + "\n" + Element.Naam;
    }

    public bool IsInGoodPosition()
    {
        if (transform.position.x <  (2 * Element.x + 0.5) 
            && transform.position.x > (2 * Element.x - 0.5)
            && transform.position.z < (-2 * Element.y + 0.5)
            && transform.position.z > (-2 * Element.y - 0.5))
        {
            return true;
        } else
        {
            return false;
        }
    }

    void OnMouseDown()
    {
        if (!IsInGoodPosition())
        {
            dragging = true;
        }
    }

    void OnMouseUp()
    {
        dragging = false;
        if (IsInGoodPosition())
        {
            Vector3 position = new Vector3(2 * Element.x, 0.5f, (-2 * Element.y));
            transform.position = position;
        }
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray);
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                if (hit.transform.CompareTag("terrain"))
                {
                    Vector3 rayPoint = ray.GetPoint(hit.distance);
                    Vector3 newPosition = new Vector3(rayPoint.x, transform.position.y, rayPoint.z);
                    transform.position = newPosition;
                    break;
                }
            }
        }
    }
}
