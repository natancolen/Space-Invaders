using UnityEngine; // Biblioteca com funções da Unity
using System.Collections; // Biblioteca com funções do C#

// Classe Movimentar que herda os eventos do MonoBehavior
public class Movimentar : MonoBehaviour {
	// Variavel
	public GameObject projetil;


	// Evento do MonoBehavior para inicialização
	void Start () {
		Debug.Log ("Start");
	}
	// Evento do MonoBehavior para atualização a cada frame
	void Update () {

		// Verificar se a tecla direcional para cima foi pressionada
		if( Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			// Mover o objeto para frente (eixo local)
			this.transform.position += this.transform.forward;
			// Mover o objeto para frente mais rápido
			if (Input.GetKey (KeyCode.RightShift)) {
				// Mover o objeto para tras (eixo local)
				this.transform.position += this.transform.forward * 2;
			}
		}
		// Verificar se a tecla direcional para baixo foi pressionada
		if( Input.GetKey(KeyCode.DownArrow)  || Input.GetKey(KeyCode.S)) {

			// Mover o objeto para tras (eixo local)
			this.transform.position -= this.transform.forward;
		}
		//Se a tecla D for pressionada
		if( Input.GetKey(KeyCode.D) ) {
			// Mover para direita
			this.transform.position += this.transform.right;
		}
		//Se a tecla A for pressionada
		if( Input.GetKey(KeyCode.S) ) {
			// Mover para esquerda
			this.transform.position -= this.transform.right;
		}

		if( Input.GetKey(KeyCode.RightArrow)&& !Input.GetKey(KeyCode.UpArrow) ) {
			// Rotacionar a direita
			this.transform.Rotate (0, 5, 0);
		}
		if( Input.GetKey(KeyCode.LeftArrow) ) {
			// Rotacionar a esquerda
			this.transform.Rotate (0, -5, 0);
		}
		// Se a tecla espaço for pressionada
		if( Input.GetKey (KeyCode.Space)) {
			//Criar uma cópia  do prefab
			Instantiate(projetil, this.transform.position, this.transform.rotation);
		}

		Debug.Log ("Update");
	}
}
