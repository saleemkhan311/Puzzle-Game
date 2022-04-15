using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip instructions;
    [SerializeField] Image Seek;
    [SerializeField] Button button;
    [SerializeField] Sprite play;
    [SerializeField] Sprite pause;
    AudioSource Source;
    bool Pause = true;
    float timer = 0;
    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Source.clip = instructions;

        float value = Source.time / Source.clip.length;
        
        timer += Time.deltaTime;
        Seek.fillAmount = Mathf.Lerp(Seek.fillAmount, value , timer);
        

    }

    public void PlayInstruction()
    {
        if(Pause)
        {
            Pause = false;
            button.image.sprite = pause;
            Source.Play();
            Debug.Log("Pause");
        }
        else if(!Pause)
        {
            Pause = true;
            button.image.sprite = play;
            Debug.Log("Play");
            Source.Pause();
        }

        
    }
}
