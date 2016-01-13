using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
    public string text;
    public string matchingText;
    public bool Clickable = true;
    public bool ShowText = false;

    private int FlipHash = Animator.StringToHash("Flip");
    private int FlipBackHash = Animator.StringToHash("FlipBack");

    public void SetTexts(string txt, string mTxt)
    {
        text = txt;
        matchingText = mTxt;
    }

    public void Flip()
    {
        ShowText = !ShowText;
        Animator anim = this.gameObject.GetComponent<Animator>();
        if (ShowText)
        {
            anim.SetTrigger(FlipHash);
        } else
        {
            anim.SetTrigger(FlipBackHash);
        }
        
        //TextMesh textObject = this.gameObject.GetComponentInChildren<TextMesh>();
        //textObject.GetComponent<Renderer>().enabled = ShowText;
    }

    // Use this for initialization
    void Start () {
        //Animator anim = this.gameObject.GetComponent<Animator>();
        //anim.Play(FlipHash, 0, 1.0F);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
