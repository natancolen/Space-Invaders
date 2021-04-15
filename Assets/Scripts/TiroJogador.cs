using UnityEngine;
using System.Collections;

public class TiroJogador : MonoBehaviour {

    public int velocidadeTiro = 2;
    // Use this for initialization
    void Start() {
        Destroy(this.gameObject, 2);
    }
    // Update is called once per frame
    void Update() {

        this.transform.position += this.transform.up * velocidadeTiro;

        //Destruir tiro quando ultrapassar o jogador
        if (this.transform.position.y > 100) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider outroCollisor) {
        if (this.tag != outroCollisor.tag) {
            if (outroCollisor.tag == "Bonus") {
                ControladorJogo.Singleton.GanharPontos(100);

                ControladorAudio.Singleton.explosaoBonus.Play();
            }

            if (outroCollisor.tag == "Escudo" || outroCollisor.tag == "Inimigo") {
                if (outroCollisor.gameObject.GetComponent<InimigoScript>()) {
                    ControladorAudio.Singleton.explosaoInimigo.Play();
                }
            }
            Destroy(outroCollisor.gameObject);
            Destroy(this.gameObject);
        }
    }
}
