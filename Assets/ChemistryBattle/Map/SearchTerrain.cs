using UnityEngine;
using System.Collections;

public class SearchTerrain : MonoBehaviour {
	public GUIText input;
	public GUIText result;
	// Use this for initialization
	void Start () {
	
	}	
	// Update is called once per frame
	void Update () {
	
	}
	public void search(){
		input = GameObject.FindWithTag("Input").GetComponent<GUIText>();
		result = GameObject.FindWithTag("Result").GetComponent<GUIText>();
		bool found = false;
		for (int i=0; i<PeriodiekSysteem.Elementen.Count; i++) {
			if(PeriodiekSysteem.Elementen[i].Naam.ToUpper()==input.text.ToUpper()){
				result.text="Result: Raak!";
				found=true;
			}
		}
		if (!found) {
			result.text="Result: Mis!";
		}
	}
}
