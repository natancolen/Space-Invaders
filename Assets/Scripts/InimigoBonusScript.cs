using UnityEngine;
using System.Collections;

public class InimigoBonusScript : MonoBehaviour {

    public GameObject tiroBonusInimigo;

    public int numInimBonus = 2;

    float horaTiroBonusInimigo;
	float intervaloBonusInimigo;

	// Use this for initialization
	void Start () {
		
		horaTiroBonusInimigo = Time.time;
		intervaloBonusInimigo = Random.Range (0.3f, 1.5f);

		ControladorAudio.Singleton.passoBonus.loop = true;
		ControladorAudio.Singleton.passoBonus.Play ();

		//Debug.Log ("Start Inimigo Bonus");
	
	}	

	// Update is called once per frame
	void Update () {

		if (this.transform.position.x >= 50) {
			Destroy (this.gameObject);
		}		

		if (Time.frameCount % numInimBonus == 0) {
			
			this.transform.position = this.transform.position += this.transform.right;

			if (Time.time - horaTiroBonusInimigo >= intervaloBonusInimigo) {
				
				horaTiroBonusInimigo = Time.time;
				intervaloBonusInimigo = Random.Range (0.2f, 1.1f);
				Instantiate (tiroBonusInimigo, this.transform.position, this.transform.rotation);
			}
		}
	}

	void OnDestroy(){

		ControladorAudio.Singleton.passoBonus.Stop ();

		//Debug.Log ("OnDestroy Inimigo Bonus");
	}

}
