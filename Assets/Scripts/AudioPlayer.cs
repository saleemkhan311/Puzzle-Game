using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip instructions;
    [SerializeField] private Image seek;
    [SerializeField] private Button button;
    [SerializeField] private Sprite play;
    [SerializeField] private Sprite pause;
    private AudioSource _source;
    private bool _pause = true;
    private float _timer = 0;
    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        _source.clip = instructions;

        var value = _source.time / _source.clip.length;
        
        _timer += Time.deltaTime;
        seek.fillAmount = Mathf.Lerp(seek.fillAmount, value , _timer);
        var _seconds = _source.time;
        
        if(_seconds ==0)
        {
            button.image.sprite = play;
        }

    }

    public void PlayInstruction()
    {
        switch (_pause)
        {
            case true:
                _pause = false;
                button.image.sprite = pause;
                _source.Play();
                Debug.Log("Pause");
                break;
            case false:
                _pause = true;
                button.image.sprite = play;
                Debug.Log("Play");
                _source.Pause();
                break;
        }
    }
}
