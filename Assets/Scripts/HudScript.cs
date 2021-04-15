using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScript : MonoBehaviour {

    public JogadorScript jogador;

    public Text melhorPontuacao;
    public Text pontos;
    public Text vida;

    // Start is called before the first frame update
    void Start() {
        vida.text = "LIFE: " + jogador.numeroVida.ToString();
        pontos.text = "SCORE: " + ControladorJogo.Singleton.score.ToString();
        melhorPontuacao.text = "HIGH-SCORE: " + ControladorJogo.Singleton.highScore.ToString();
    }

    // Update is called once per frame
    void Update() {
        vida.text = "LIFE: " + jogador.numeroVida.ToString();
        pontos.text = "SCORE: " + ControladorJogo.Singleton.score.ToString();
        melhorPontuacao.text = "HIGH-SCORE: " + ControladorJogo.Singleton.highScore.ToString();
    }
}
