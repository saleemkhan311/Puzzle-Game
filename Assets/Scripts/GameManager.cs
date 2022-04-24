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
    public bool win = false;
    public bool lose = false;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject loseText;

    private void Start()
    {
        Singleton = this;
    }

    private void Update()
    {
       // var moves = controller.moves;
       // movesText.text = "Moves  " + moves + "/" + totalMoves;
        // Debug.Log("Scores = " + scores);
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
            ;
        }

        if (win || lose)
        {
            //controller.enabled = false;
        }
    }
}