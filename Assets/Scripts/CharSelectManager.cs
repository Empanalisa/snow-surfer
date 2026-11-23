using UnityEngine;

public class CharSelectManager : MonoBehaviour
{

    [SerializeField] GameObject scoreCanvas; //score canvas ref
    [SerializeField] GameObject dinoSprite;
    [SerializeField] GameObject frogSprite;
    void Start()
    {
        Time.timeScale=0; //Pause, it usually runs at 1. 
    }

    void BeginGame()
    {
        Time.timeScale=1f; //unpause
        scoreCanvas.SetActive(true); //show score
        // desable character select cavas
        gameObject.SetActive(false); //THIS IS GOING TO REFERENCE THE OBJECT THAT IS HOLDING THE SCRIPT (gameObject starting lower case)
    }

    public void ChooseDino()
    {
        dinoSprite.SetActive(true);
        BeginGame();
    }

    public void ChooseFrog()
    {
        frogSprite.SetActive(true);
        BeginGame();
    }

    
}
