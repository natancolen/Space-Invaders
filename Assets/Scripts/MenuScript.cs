using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ControladorAudio.Singleton.music.loop = true;
		ControladorAudio.Singleton.music.Play ();

			
	}

	//Metodo para GUI devem ser sempre publicos
	public void BotaoAutor(){
		SceneManager.LoadScene (2);

	}

	public void BotaoJogar(){
		ControladorAudio.Singleton.music.Stop ();
		SceneManager.LoadScene (3);

	}

    public void BotaoMenu() {
        SceneManager.LoadScene(1);

    }

    public void BotaoSair(){
		Application.Quit ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
