using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text EnergyTxt;
    public Text ScoreTxt;

    private static int energy = 100;
    private static int score = 0;

    private float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if(counter > 2) {
            counter = 0;
            energy--;
        }
        if(energy < 1) {
            GameOver();
        }
        EnergyTxt.text = "" + energy;
        ScoreTxt.text = "Score: " + score;
    }

    public static void DepleetEnergy(int energya) {
        energy -= energya;
    }

    public void AddEnergy(int energya) {
        energy += energya;
        if(energy > 100) {
            energy = 100;
        }
    }
    public void AddScore(int scorea) {
        score += scorea;
    }

    void GameOver() {

    }
}
