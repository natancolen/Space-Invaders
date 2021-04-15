using UnityEngine;
using System.Collections;

public class TiroInimigoScript : MonoBehaviour {


    int velTiroInimigo = 3;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        this.transform.position -= this.transform.up * velTiroInimigo;

        if (this.transform.position.y < -8) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider outroCollisor) {
        if (outroCollisor.tag == "Escudo") {
            Destroy(outroCollisor.gameObject);
            Destroy(this.gameObject);
        }

        //if (outroCollisor.tag == "Jogador") {
        //    if (outroCollisor.gameObject.GetComponent<JogadorScript>().numeroVida > 0) {
        //        outroCollisor.gameObject.GetComponent<JogadorScript>().SofrerDano();
        //    }
        //    else {
        //        Destroy(outroCollisor.gameObject);
        //        Destroy(this.gameObject);
        //    }
        //}
    }
}
