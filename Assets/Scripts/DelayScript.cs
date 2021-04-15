using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Biblioteca para trabalhar com troca de cena


public class DelayScript : MonoBehaviour {

	float horaStart;
	public float intervalo;
	public bool pulaLogo;

	// Use this for initialization
	void Start () {
		horaStart = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (pulaLogo) {
			SceneManager.LoadScene (1);
		}

		if (Time.time - horaStart >= intervalo) {
			SceneManager.LoadScene (1);
		}

		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Space) || Input.anyKey) {
			SceneManager.LoadScene (1);

		}

	
	}
}
