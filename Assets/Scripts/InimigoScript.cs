using UnityEngine;
using System.Collections;

public class InimigoScript : MonoBehaviour {
    public GameObject tiroInimigo;

    public int pontos = 0;

    float horaTiro;
    float intervalo;
    
    // Use this for initialization
    void Start() {

        horaTiro = Time.time;
        intervalo = Random.Range(6, 12);

        //Debug.Log ("Start InimigoScript");	
    }
    // Update is called once per frame
    void Update() {
        if (ControladorJogo.Singleton.temJogador == true) {
            if (Time.time - horaTiro >= intervalo) {
                Instantiate(tiroInimigo, this.transform.position, this.transform.rotation);
                horaTiro = Time.time;
            }

            //Limitador do Bloco de Inimigos informando o que fazer quando chegar no limite da direita
            if (this.transform.position.x >= 50) {
                if (this.transform.parent.GetComponent<BlocoScript>().sentido == 1) {
                    this.transform.parent.GetComponent<BlocoScript>().sentido = -1;
                    this.transform.parent.position -= new Vector3(0, 10, 0);
                }

            }
            //Limitador do Bloco de Inimigos informando o que fazer quando chegar no limite da esquerda
            if (this.transform.position.x <= -50) {
                if (this.transform.parent.GetComponent<BlocoScript>().sentido == -1) {
                    this.transform.parent.GetComponent<BlocoScript>().sentido = 1;
                    this.transform.parent.position -= new Vector3(0, 10, 0);
                }

                //Chamando audio passo_Inimigo no script ControladorAudio
                ControladorAudio.Singleton.passoInimigo.Play();
            }
        }
        else {
            this.transform.parent.GetComponent<BlocoScript>().sentido = 0;
        }
    }
    // Evento quando houver colisão com outro objeto
    void OnTriggerEnter(Collider jogadorCollisor) {
        if (this.gameObject.tag != jogadorCollisor.tag) {
            if (jogadorCollisor.tag == "Escudo" && this.gameObject.GetComponent<InimigoScript>()) {
                Destroy(jogadorCollisor.gameObject);
            }

            if (jogadorCollisor.tag == "Jogador" && jogadorCollisor.gameObject.GetComponent<JogadorScript>()) {
                //ControladorJogo.Singleton.GameOver();
                
                Destroy(jogadorCollisor.gameObject);

                //ControladorJogo.Singleton.jogador.numeroVida = 0;
                ControladorJogo.Singleton.temJogador = false;

                //Debug.Log("InimigoScript / Matou Jogador");
                ControladorJogo.Singleton.GanharPontos(0);
                ControladorJogo.Singleton.GameOver();
            }
        }
    }

    void OnDestroy() {
        if (ControladorJogo.Singleton.temJogador) {
            ControladorJogo.Singleton.GanharPontos(pontos);
        }
        this.transform.parent.GetComponent<BlocoScript>().ReduzirNumeroInimigos();
        ControladorAudio.Singleton.explosaoInimigo.Play();
    }

    public void Descer() {
        this.transform.position -= new Vector3(0, 10, 0);
    }
}


