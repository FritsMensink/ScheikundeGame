using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SearchTerrain : MonoBehaviour {
	public Text input;
	public Text result;
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
				Debug.Log(tileNum);
				if(tileNum>=2){
					found=true;
					//check if colliding with a tube
					//true then
					t.changeTile(tileNum-3);
					resultText+="Gefeliciteerd, deel van reageerbuis gevonden!";
					//else
					//text =  Helaas, geen reageerbuis gevonden!
				}else if(tileNum==1){
					resultText+="Op dit element is al gezocht!";
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
