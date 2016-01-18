using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SearchTerrain : MonoBehaviour {
	Text input;
	Text result;
	Text score;
	Text bestscore;
	int[] targets;
	int[] simpleTargets;
	Text end;
	Text hint;
	public int gametype;
	// Use this for initialization
	void Start () {
		targets = new int[10];
		simpleTargets = new int[5];
		end = GameObject.FindWithTag("end").GetComponent<Text>();
		end.text = "";
		score = GameObject.FindWithTag("Score").GetComponent<Text>();
		score.text = "Score: 0";
		bestscore = GameObject.FindWithTag("bestscore").GetComponent<Text>();
		bestscore.text = "Topscore: "+PlayerPrefs.GetInt ("bestscore");
		hint = GameObject.FindWithTag("hint").GetComponent<Text>();
		hint.text = "";
		string hintText= "Hint: ";
		TileMap t = GetComponent<TileMap> ();
		if (gametype == 1) {
			for (int i = 0; i < targets.Length; i++) {
				int randInt = Random.Range (0, 161);
				if (!(t.terrainTiles[randInt].name.ToUpper().Equals("NONE")) ) {
					targets [i] = randInt;
					string name="";
					for (int a = 0; a < PeriodiekSysteem.Elementen.Count; a++) {
						if(PeriodiekSysteem.Elementen[a].Afkorting.ToUpper().Equals(t.terrainTiles[randInt].name.ToUpper())){
							name=PeriodiekSysteem.Elementen[a].Naam;
						}
					}
					if (name != "") {
						hintText += name.Substring(0,2) + ", ";
					} else {
						i--;
					}
				} else {
					i--;
				}
			}
		} else {
			for (int i = 0; i < simpleTargets.Length; i++) {
				int randInt = Random.Range (0, 161);
				if (!(t.terrainTiles[randInt].name.Equals("NONE"))) {
					simpleTargets [i] = randInt;
					string name="";
					for (int a = 0; a < PeriodiekSysteem.Elementen.Count; a++) {
						if(PeriodiekSysteem.Elementen[a].Afkorting.ToUpper().Equals(t.terrainTiles[randInt].name.ToUpper())){
							name=PeriodiekSysteem.Elementen[a].Naam;
						}
							}
							hintText += name.Substring(0,2)+", ";
				} else {
					i--;
				}
			}
		}
		hint.text = hintText;
		print (targets[0]);
	}	
	// Update is called once per frame
	void Update () {
	
	}
	public void search(){
		input = GameObject.FindWithTag("Input").GetComponent<Text>();
		result = GameObject.FindWithTag("Result").GetComponent<Text>();
		score = GameObject.FindWithTag("Score").GetComponent<Text>();
		TileMap t = GetComponent<TileMap> ();
		bool found = false;
		string resultText = "Result: ";
		int totalscore = System.Int32.Parse(score.text.Substring(7));
		for (int i=0; i<PeriodiekSysteem.Elementen.Count; i++) {
			if(PeriodiekSysteem.Elementen[i].Naam.ToUpper()==input.text.ToUpper()){
				int tileNum = t.getPosOFTerrainTile(input.text.ToUpper());
				if(tileNum>=2){
					found=true;
					tileNum = tileNum - 3;
					if (this.is_a_hit(tileNum)) {
						t.changeTile (tileNum,1);
						resultText += "Goedzo! U heeft een verloren element gevonden";
						totalscore += 20;
						if (has_won ()) {
							if (PlayerPrefs.GetInt ("bestscore")!=0||PlayerPrefs.GetInt ("bestscore") < totalscore) {
								PlayerPrefs.SetInt ("bestscore", totalscore);
							}
							end.text = "Gefeliciteerd U heeft gewonnen!\nScore: "+totalscore;
						}
					} else {
						t.changeTile (tileNum,2);
						resultText += "Mis! voer een ander element in.";
						totalscore += -1;
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
		score.text="Score: "+totalscore;
	}
	public bool is_a_hit(int tileNum){
		if (this.gametype == 1) {
			for (int i = 0; i < this.targets.Length; i++) {
				if (this.targets [i] == tileNum) {
					this.targets [i] = 163;
					return true;
				}
			}
			return false;
		}
		else{
			for (int i = 0; i < this.simpleTargets.Length; i++) {
				if (this.simpleTargets [i] == tileNum) {
					this.simpleTargets [i] = 163;
					return true;
				}
			}
			return false;
		}
	}
	public bool has_won(){
		int count = 0;
		if (gametype == 1) {
			for (int i = 0; i < targets.Length; i++) {
				if (targets [i] == 163) {
					count++;
				}
			}
			if (count == 10) {
				return true;
			}
		}
		if (gametype == 2) {
			for (int i = 0; i < simpleTargets.Length; i++) {
				if (simpleTargets [i] == 163) {
					count++;
				}
			}
			if (count == 5) {
				return true;
			}
		}
		return false;
	}
	public void won(){
		
	}
}
