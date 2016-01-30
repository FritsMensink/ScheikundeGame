using UnityEngine;
using System;
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
	TileMap t;
	InputField inpf;
	public int gametype;
	// Use this for initialization
	void Start () {
		targets = new int[18];
		simpleTargets = new int[10];
		end = GameObject.FindWithTag("end").GetComponent<Text>();
		end.text = "";
		score = GameObject.FindWithTag("Score").GetComponent<Text>();
		score.text = "Score: 0";
		bestscore = GameObject.FindWithTag("bestscore").GetComponent<Text>();
		bestscore.text = "Laatste score: "+PlayerPrefs.GetInt ("bestscore");
		hint = GameObject.FindWithTag("hint").GetComponent<Text>();
		hint.text = "";
		t = GetComponent<TileMap> ();
		string hintText= "Doel: ";
		if (gametype == 1) {
			for (int i = 0; i < targets.Length; i++) {
				int randInt = UnityEngine.Random.Range (0, 161);
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
		}
		if(gametype == 0){
			for (int i = 0; i < simpleTargets.Length; i++) {
				int randInt = UnityEngine.Random.Range (0, 161);
				if (!(t.terrainTiles[randInt].name.Equals("NONE"))) {
					simpleTargets [i] = randInt;
					string name="";
					for (int a = 0; a < PeriodiekSysteem.Elementen.Count; a++) {
						if(PeriodiekSysteem.Elementen[a].Afkorting.ToUpper().Equals(t.terrainTiles[randInt].name.ToUpper())&&PeriodiekSysteem.Elementen[a].LeerstofVmbo){
							name=PeriodiekSysteem.Elementen[a].Afkorting;
						}
					}
					if (name != "") {
						hintText += name + ", ";
					} else {
						i--;
					}
				} else {
					i--;
				}
			}
		}
		hint.text = hintText.Substring(0,hintText.Length-2);
	}
	public void giveHint(){
		score = GameObject.FindWithTag("Score").GetComponent<Text>();
		int totalscore = System.Int32.Parse(score.text.Substring(7));
		totalscore += -40;
		score.text="Score: "+totalscore;
	}
	void changeDoel(){
		string doelText="Doel: ";
		string name="";
		if (gametype == 0) {
			foreach (int i in simpleTargets) {
				//print (i);
				if (i != 163) {
					
					for (int a = 0; a < PeriodiekSysteem.Elementen.Count; a++) {
						name="";
						if(PeriodiekSysteem.Elementen[a].Afkorting.ToUpper().Equals(t.terrainTiles[i].name.ToUpper())&&PeriodiekSysteem.Elementen[a].LeerstofVmbo){
							name=PeriodiekSysteem.Elementen[a].Afkorting;
						}
						if (name != "") {
							doelText += name + ", ";
						}
					}
				}
			}
		}
		if (gametype == 1) {
			foreach (int i in targets) {
				if (i != 163) {
					for (int a = 0; a < PeriodiekSysteem.Elementen.Count; a++) {
						name="";
						if (PeriodiekSysteem.Elementen [a].Afkorting.ToUpper ().Equals (t.terrainTiles [i].name.ToUpper ())) {
							name = PeriodiekSysteem.Elementen [a].Afkorting;
						}
						if (name != "") {
							doelText += name + ", ";
						}
					}
				}
			}
		}
		hint.text = doelText.Substring(0,doelText.Length-2);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown ("enter")||Input.GetKeyDown ("return")) {
			this.search ();
		}
	}
	public void search(){
		input = GameObject.FindWithTag("Input").GetComponent<Text>();
		inpf = GameObject.FindWithTag("inpf").GetComponent<InputField>();
		result = GameObject.FindWithTag("Result").GetComponent<Text>();
		score = GameObject.FindWithTag("Score").GetComponent<Text>();
		TileMap t = GetComponent<TileMap> ();
		bool found = false;
		string resultText = "Resultaat: ";
		int totalscore = System.Int32.Parse(score.text.Substring(7));
		for (int i=0; i<PeriodiekSysteem.Elementen.Count; i++) {
			if(PeriodiekSysteem.Elementen[i].Naam.ToUpper()==input.text.ToUpper()){
				int tileNum = t.getPosOFTerrainTile(input.text.ToUpper());
				if(tileNum>=2){
					found=true;
					tileNum = tileNum - 3;
					if (this.is_a_hit(tileNum)) {
						t.changeTile (tileNum,1);
						resultText += "Goed zo! U heeft een gesloopt element hersteld.";
						totalscore += 20;
						changeDoel ();
						if (gametype==1) {
							int pos = Array.IndexOf(targets, tileNum);
							if(pos>-1){
								targets[pos]=163;
							}
						}
						if (gametype==0) {
							int pos = Array.IndexOf(simpleTargets, tileNum);
							if(pos>-1){
								simpleTargets[pos]=163;
							}
						}
						if (has_won ()) {
							PlayerPrefs.SetInt ("bestscore", totalscore);
							end.text = "Gefeliciteerd, U heeft gewonnen!\nScore: "+totalscore;
							inpf.enabled = false;
						}
					} else {
						t.changeTile (tileNum,2);
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
		score.text="Score: "+totalscore;
		inpf.text = "";
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
			if (count == targets.Length) {
				return true;
			}
		}
		if (gametype == 0) {
			for (int i = 0; i < simpleTargets.Length; i++) {
				if (simpleTargets [i] == 163) {
					count++;
				}
			}
			if (count == simpleTargets.Length) {
				return true;
			}
		}
		return false;
	}
	public void won(){
		
	}
}
