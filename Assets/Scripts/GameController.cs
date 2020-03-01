using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Text EnergyTxt;
    public Text ScoreTxt;

    public static bool playing = true;

    public GameObject endScreen;

    private static int energy = 100;
    private static int score = 0;

    public AudioClip hurt, powerup;
    private AudioSource aus;

    public static bool endgame = false;

    public static bool playHurt = false;
    public static bool playPowerup = false;

    private static float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        endScreen.SetActive(false);
        energy = 100;
        score = 0;
        counter = 0;
        aus = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playHurt) {
            aus.PlayOneShot(hurt);
            playHurt = false;
        }

        if (playPowerup) {
            aus.PlayOneShot(powerup);
            playPowerup = false;
        }

        if (endgame) {
            Play();
        }
        counter += Time.deltaTime;

        if(counter > 2) {
            counter = 0;
            if (playing) {
                energy--;
            }
        }
        if(energy < 1) {
            GameOver();
        }
        EnergyTxt.text = "" + energy;
        ScoreTxt.text = "" + score;
    }

    public static void DepleetEnergy(int energya) {
        energy -= energya;
    }

    public static void AddEnergy(int energya) {
        energy += energya;
        if(energy > 100) {
            energy = 100;
        }
    }
    public static void AddScore(int scorea) {
        score += scorea;
    }

    void GameOver() {
        playing = false;
        endScreen.SetActive(true);
    }

    public void Play() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        endScreen.SetActive(false);
        energy = 100;
        score = 0;
        counter = 0;
        playing = true;
        endgame = false;
    }

    public void Menu() {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
