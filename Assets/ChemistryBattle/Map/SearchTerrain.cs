using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SearchTerrain : MonoBehaviour {
	Text input;
	Text result;
	// Use this for initialization
	void Start () {
	
	}	
	// Update is called once per frame
	void Update () {
	
	}
	public void search(){
		input = GameObject.FindWithTag("Input").GetComponent<Text>();
		result = GameObject.FindWithTag("Result").GetComponent<Text>();
		TileMap t = GetComponent<TileMap> ();
		bool found = false;
		string resultText = "Result: ";
		for (int i=0; i<PeriodiekSysteem.Elementen.Count; i++) {
			if(PeriodiekSysteem.Elementen[i].Naam.ToUpper()==input.text.ToUpper()){
				int tileNum = t.getPosOFTerrainTile(input.text.ToUpper());
				Debug.Log (tileNum);
				if(tileNum>=2){
					found=true;
					var up = transform.TransformDirection (Vector3.up);
					if (Physics.Raycast (t.transform.position, up, 10)) {
						t.changeTile (tileNum - 3,1);
						resultText += "Raak! Gefeliciteerd, deel van reageerbuis gevonden!";
					} else {
						t.changeTile (tileNum - 3,2);
						resultText += "Mis! voer een ander element in.";
					}
				}else if(tileNum==1){
					resultText+="Op dit element is al gezocht, probeer een ander.";
					found=true;
				}
			}
		}
		if (!found) {
			resultText+="Dit is geen geldig element!";
		}
		result.text=resultText;
	}
}
