using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class ControladorJogo : MonoBehaviour {
    public static ControladorJogo Singleton;

    public bool podeGerarInimigoBonus = true;
    public bool temJogador = true;

    public int score = 0;
    public int highScore = 0;

    private void Awake() {
        if (Singleton == null) {
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {

            if (Singleton != this) {
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    private void Update() {
        if (score > 999) {
            score = 999;
        }

        if (highScore > 999) {
            highScore = 999;
        }
    }

    public void GanharPontos(int pontos) {
        if (score < 1000 && temJogador == true) {
            score += pontos;
        }
        if (pontos == 0) {
            score = 0;
        }
    }

    public void GameOver() {
        temJogador = podeGerarInimigoBonus = false;

        score = 0;

        if (highScore == 999) {
            score = highScore = 0;
        }

        //Debug.Log("GameOver / score: " + score);
        //Debug.Log("GameOver / highScore: " + highScore);

        MudarDeCena();
    }

    public void Vitoria() {
        podeGerarInimigoBonus = false;

        if (score > highScore) {
            highScore = score;
            //Debug.Log("Vitoria / higscore: " + highScore);
        }

        MudarDeCena();
    }

    public void MudarDeCena() {
        //Debug.Log("MudarDeCena / highScore && score = " + score);
        temJogador = podeGerarInimigoBonus = true;

        SceneManager.LoadScene(1);
    }
}
