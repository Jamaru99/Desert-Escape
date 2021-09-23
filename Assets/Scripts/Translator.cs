using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Translator : MonoBehaviour
{
    public bool isPortuguese;

    public TextMeshPro continueButton;
    public TextMeshPro newGameButton;
    public TextMeshPro aboutButton;
    public Sprite resetBox;

    public TextMeshPro avoidCactusText;
    public TextMeshPro jumpSnakeText;
    public TextMeshPro punchText;
    public TextMeshPro avoidScorpionsText;

    public TextMeshPro gameOverText;
    public TextMeshPro watch;

    public TextMeshPro creditsText;

    public TextMeshPro endText;

    Scene scene;

    void Start()
    {
        isPortuguese = Application.systemLanguage == SystemLanguage.Portuguese;
        if (!isPortuguese)
        {
            scene = SceneManager.GetActiveScene();
            if (scene.name == "Menu")
            {
                continueButton.text = "CONTINUE";
                newGameButton.text = "NEW GAME";
                aboutButton.text = "CREDITS";
                GameObject.Find("resetbox").GetComponent<SpriteRenderer>().sprite = resetBox;
            }
            if (scene.name == "Sobre")
            {
                creditsText.text = "Songs: Vida de viajante and Asa branca\nby Luiz Gonzaga";
            }
            if (scene.name == "Level_2")
            {
                avoidCactusText.text = "Avoid cactus";
            }
            if (scene.name == "Level_4")
            {
                jumpSnakeText.text = "Jump on Snake's head";
            }
            if (scene.name == "Level_6")
            {
                punchText.text = "Touch on screen to punch";
            }
            if (scene.name == "Level_11")
            {
                avoidScorpionsText.text = "Avoid scorpions";
            }
            if (scene.name == "GameOver")
            {
                gameOverText.text = "No more life :(\nWatch a video to get more ^^";
                watch.text = "WATCH";
            }
            if(scene.name == "Fim")
            {
                endText.text = "THE END";
            }
        }
    }
}
