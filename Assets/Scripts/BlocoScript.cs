using UnityEngine;
using System.Collections;

public class BlocoScript : MonoBehaviour {
	public float sentido = 1;
	public int numInimigos = 15;

    public bool jogoAcabou = false;

	// Use this for initialization
	void Start () {
		numInimigos = 15;
	}
	
	// Update is called once per frame
	void Update () {
        if (numInimigos > 0) {
            if (Time.frameCount % numInimigos == 0) {
                //Script movimentar Bloco					
                this.transform.position += this.transform.right * sentido;
            }
        }

        if (numInimigos == 0 && jogoAcabou == false) {
            //Debug.Log("BlocoScript / Vitoria do jogador");
            ControladorJogo.Singleton.Vitoria();
            jogoAcabou = true;
        }
	}

    public void ReduzirNumeroInimigos() {
        if (numInimigos > 0) {
            numInimigos--;
        }
    }
}
