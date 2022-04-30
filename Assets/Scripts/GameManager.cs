using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
 
    private static GameManager _singleton;

    public static GameManager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
            {
                _singleton = value;
                return;
            }

            Destroy(value.gameObject);
        }
    }

    //public SnapController controller;

    public int totalMoves;
    public Text movesText;
    public int scores;
    public int moves;
    public bool win = false;
    public bool lose = false;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject loseText;
    [SerializeField] GameObject ItemParent;
    Vector3[] pos = new Vector3[18];
    private void Start()
    {
        Singleton = this;

        

    }

    private void Update()
    {

        for (int i = 0; i < ItemParent.transform.childCount; i++)
        {
            
                pos[i] = ItemParent.transform.GetChild(i).transform.position;
                    
            
        }


        movesText.text = "Moves  " + moves + "/" + totalMoves;
        if (scores >= 18)
        {
            win = true;
        }

        
        if (win)
        {
            winText.SetActive(true);
        }
        else if (lose)
        {
            loseText.SetActive(true);  
        }

        if (win || lose)
        {
            //controller.enabled = false;
        }
    }

    
}