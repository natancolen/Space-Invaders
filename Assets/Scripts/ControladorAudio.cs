using UnityEngine;
using System.Collections;

public class ControladorAudio : MonoBehaviour {

	public static ControladorAudio Singleton;

	public AudioSource tiroJogador;
	public AudioSource explosaoInimigo;
	public AudioSource explosaoBonus;
	public AudioSource explosaoJogador;
	public AudioSource passoBonus;
	public AudioSource passoInimigo;
	public AudioSource music;



	// Use this for initialization
	void Start () {


		//Debug.Log ("Start Controlador Audio");
	
	}
	void Awake (){


		Singleton = this;
		DontDestroyOnLoad (this.gameObject);


		//Debug.Log ("Awake Controlador Audio");
	}
	
	// Update is called once per frame
	void Update () {



	}
}
