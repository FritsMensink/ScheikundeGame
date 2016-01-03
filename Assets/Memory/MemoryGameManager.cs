using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MemoryGameManager : MonoBehaviour {
    public int NumberOfElements = 5;
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;
    public GameObject Card7;
    public GameObject Card8;
    public GameObject Card9;
    public GameObject Card10;
    public Text result;

    private bool AbleToClickCards = true;
    private float TimeLeft = 0;
    private List<Element> ElementsInPlay = new List<Element>();
    private List<Combinatie> Combinaties = new List<Combinatie>();
    private Card ActiveCard;
    private Card SelectedCard;
    private int NumberOfGuesses;
    private int NumberOfCombinationsFound;

    void Start ()
    {
        ElementsInPlay = ChooseElements();

        //create the cards
        foreach (Element e in ElementsInPlay)
        {
            print(e.Naam);
            Combinaties.Add(new Combinatie(e.Naam, e.Afkorting));
            Combinaties.Add(new Combinatie(e.Afkorting, e.Naam));
        }
        
        //shuffle the cards, so they're not in order
        Shuffle(Combinaties);

        //make sure the cards start hidden
        HideCards();

        //put the cards on the board
        AddCombinationsToCards();

        result = GameObject.FindWithTag("Result").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0)
        {
            AbleToClickCards = true;
            result.text = " ";
            //hide cards that need hiding
            if (SelectedCard != null && ActiveCard != null)
            {
                SelectedCard.Flip();
                ActiveCard.Flip();
                SelectedCard.Clickable = true;
                ActiveCard.Clickable = true;
                SelectedCard = null;
                ActiveCard = null;
            }
        }
        if (Input.GetMouseButtonDown(0) && TimeLeft < 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject selected = hit.transform.gameObject;
                if (selected.name.Contains("Card") && AbleToClickCards)
                {
                    SelectedCard = selected.GetComponentInChildren<Card>();
                    if (!SelectedCard.Clickable)
                    {
                        SelectedCard = null;
                    }
                    else { 
                        print("hit " + selected.name);
                        SelectedCard.Flip();

                        if (ActiveCard == null)
                        {
                            ActiveCard = SelectedCard;
                            ActiveCard.Clickable = false;
                            SelectedCard = null;
                        }
                        else
                        {
                            NumberOfGuesses++;
                            if (ActiveCard.matchingText == SelectedCard.text)
                            {
                                result.text = "Juiste combinatie!";
                                ActiveCard.Clickable = false;
                                SelectedCard.Clickable = false;
                                ActiveCard = null;
                                SelectedCard = null;
                                NumberOfCombinationsFound++;
                                if (NumberOfCombinationsFound == NumberOfElements)
                                {
                                    result.text = "Je hebt gewonnen!";
                                }
                            }
                            else
                            {
                                result.text = "De combinatie is niet juist.";
                            }
                            AbleToClickCards = false;
                            TimeLeft = 2.0f;
                        }
                    }
                }
            }
        }
    }

    private List<Element> ChooseElements()
    {
        List<Element> elementen = new List<Element>();
        //select random elements to be played
        for (int i = 0; i < NumberOfElements; i++)
        {
            int elementNummer = Random.Range(0, PeriodiekSysteem.VmboElementen.Count);
            Element e = PeriodiekSysteem.VmboElementen[elementNummer];
            if (!elementen.Contains(e))
            {
                elementen.Add(e);
            }
            else
            {
                i--;
            }
        }
        if (elementen.Count != NumberOfElements)
        {
            Debug.Log("Verkeerd aantal elementen in spel: " + ElementsInPlay.Count + " in plaats van " + NumberOfElements);
        }
        return elementen;
    }

    void HideCards()
    {
        /*
        Card1.GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = false;
        Card2.GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = false;
        Card3.GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = false;
        Card4.GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = false;
        Card5.GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = false;
        Card6.GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = false;
        Card7.GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = false;
        Card8.GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = false;
        Card9.GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = false;
        Card10.GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = false;
        */
    }

    void AddCombinationsToCards()
    {
        Card1.GetComponentInChildren<Card>().SetTexts(Combinaties[0].text, Combinaties[0].matchingText);
        Card2.GetComponentInChildren<Card>().SetTexts(Combinaties[1].text, Combinaties[1].matchingText);
        Card3.GetComponentInChildren<Card>().SetTexts(Combinaties[2].text, Combinaties[2].matchingText);
        Card4.GetComponentInChildren<Card>().SetTexts(Combinaties[3].text, Combinaties[3].matchingText);
        Card5.GetComponentInChildren<Card>().SetTexts(Combinaties[4].text, Combinaties[4].matchingText);
        Card6.GetComponentInChildren<Card>().SetTexts(Combinaties[5].text, Combinaties[5].matchingText);
        Card7.GetComponentInChildren<Card>().SetTexts(Combinaties[6].text, Combinaties[6].matchingText);
        Card8.GetComponentInChildren<Card>().SetTexts(Combinaties[7].text, Combinaties[7].matchingText);
        Card9.GetComponentInChildren<Card>().SetTexts(Combinaties[8].text, Combinaties[8].matchingText);
        Card10.GetComponentInChildren<Card>().SetTexts(Combinaties[9].text, Combinaties[9].matchingText);
        Card1.GetComponentInChildren<TextMesh>().text = Combinaties[0].text;
        Card2.GetComponentInChildren<TextMesh>().text = Combinaties[1].text;
        Card3.GetComponentInChildren<TextMesh>().text = Combinaties[2].text;
        Card4.GetComponentInChildren<TextMesh>().text = Combinaties[3].text;
        Card5.GetComponentInChildren<TextMesh>().text = Combinaties[4].text;
        Card6.GetComponentInChildren<TextMesh>().text = Combinaties[5].text;
        Card7.GetComponentInChildren<TextMesh>().text = Combinaties[6].text;
        Card8.GetComponentInChildren<TextMesh>().text = Combinaties[7].text;
        Card9.GetComponentInChildren<TextMesh>().text = Combinaties[8].text;
        Card10.GetComponentInChildren<TextMesh>().text = Combinaties[9].text;
    }

    public void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public class Combinatie {
        public string text;
        public string matchingText;

        public Combinatie(string txt, string mTxt)
        {
            this.text = txt;
            this.matchingText = mTxt;
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
