using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    private bool AbleToClickCards = true;
    private float TimeLeft = 0;
    private List<Element> ElementsInPlay = new List<Element>();
    private List<Card> Cards = new List<Card>();
    private Card ActiveCard;
    private List<TextMesh> TextsToHide = new List<TextMesh>();

    void Start ()
    {
        ElementsInPlay = ChooseElements();

        //create the cards
        foreach (Element e in ElementsInPlay)
        {
            print(e.Naam);
            Cards.Add(new Card(e.Naam, e.Afkorting));
            Cards.Add(new Card(e.Afkorting, e.Naam));
        }
        
        //shuffle the cards, so they're not in order
        Shuffle(Cards);

        //make sure the cards start hidden
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

        //put the cards on the board
        Card1.GetComponentInChildren<TextMesh>().text = Cards[0].text;
        Card2.GetComponentInChildren<TextMesh>().text = Cards[1].text;
        Card3.GetComponentInChildren<TextMesh>().text = Cards[2].text;
        Card4.GetComponentInChildren<TextMesh>().text = Cards[3].text;
        Card5.GetComponentInChildren<TextMesh>().text = Cards[4].text;
        Card6.GetComponentInChildren<TextMesh>().text = Cards[5].text;
        Card7.GetComponentInChildren<TextMesh>().text = Cards[6].text;
        Card8.GetComponentInChildren<TextMesh>().text = Cards[7].text;
        Card9.GetComponentInChildren<TextMesh>().text = Cards[8].text;
        Card10.GetComponentInChildren<TextMesh>().text = Cards[9].text;
    }

    private List<Element> ChooseElements()
    {
        List<Element> elementen = new List<Element>();
        //select random elements to be played
        for (int i = 0; i < NumberOfElements; i++)
        {
            int elementNummer = Random.Range(0, PeriodiekSysteem.Elementen.Count);
            Element e = PeriodiekSysteem.Elementen[elementNummer];
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

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0)
        {
            AbleToClickCards = true;
            //hide cards that need hiding
            if (TextsToHide.Count > 1)
            {
                print("hiding texts");
                foreach (TextMesh tm in TextsToHide)
                {
                    tm.GetComponent<Renderer>().enabled = false;
                }
                TextsToHide.Clear();
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
                    print("hit " + selected.name);
                    //make visible
                    TextMesh textObject = selected.GetComponentInChildren<TextMesh>();
                    textObject.GetComponent<Renderer>().enabled = true;

                    Card SelectedCard = null;
                    foreach (Card c in Cards)
                    {
                        if (textObject.text == c.text)
                        {
                            SelectedCard = c;
                            break;
                        }
                    }

                    if (ActiveCard == null)
                    {
                        ActiveCard = SelectedCard;
                        TextsToHide.Add(textObject);
                    } else
                    {
                        if (ActiveCard.matchingText == SelectedCard.text)
                        {
                            TextsToHide.Clear();
                            //leave them open and deselect active
                        } else
                        {
                            TextsToHide.Add(textObject);
                            AbleToClickCards = false;
                            TimeLeft = 5.0f;
                        }
                        ActiveCard = null;
                    }
                }
            }
        }
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

    public class Card
    {
        public string text;
        public string matchingText;
        public bool Clickable = true;

        public Card(string t, string t2)
        {
            text = t;
            matchingText = t2;
        }
    }
}
