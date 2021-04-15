using UnityEngine;
using System.Collections;

public class JogadorScript : MonoBehaviour {

    //Variaveis
    public GameObject tiro;
    public GameObject mira;
    
    public int velocidadeFrame = 2;
    public int numeroVida = 3;

    // Use this for initialization
    void Start() {
        ControladorJogo.Singleton.temJogador = true;
    }
    // Update is called once per frame
    void Update() {
        //Movimentar com as setas ate determinada posiçao da direita
        if (Time.frameCount % velocidadeFrame == 0) {
            if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > -50) {
                this.transform.position = this.transform.position - this.transform.right;
            }
        }
        //Movimentar com as setas ate determinada posiçao da esquerda
        if (Time.frameCount % velocidadeFrame == 0) {
            if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < 50) {
                this.transform.position = this.transform.position + this.transform.right;

            }
        }
        //Instanciar o tiro
        //horaTiroJogador -= Time.time;

        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(tiro, mira.transform.position, mira.transform.rotation);

            ControladorAudio.Singleton.tiroJogador.Play();
        }
    }

    void OnDestroy() {
        //Quando objeto for destruido tocar o audio explosaoJogador
        ControladorAudio.Singleton.explosaoJogador.Play();

        ControladorJogo.Singleton.temJogador = false;

        //Debug.Log("Jogador Destruido");
    }

    private void OnTriggerEnter(Collider outroColisor) {
        //Caso colide com objeto com a tag inimigo ou bonus
        if (outroColisor.tag != this.tag) {
            if (outroColisor.tag == "Inimigo" || outroColisor.tag == "Bonus") {
                //Destroy(outroColisor.gameObject);
                //se o numero de vida for maior que zero sofre dano se nao é destruido 
                if (numeroVida > 0) {
                    SofrerDano();
                }
                else {
                    //ControladorAudio.Singleton.explosaoJogador.Play();
                    Destroy(this.gameObject);
                }
            }
        }
    }

    public void SofrerDano() {
        numeroVida--;
    }
}
