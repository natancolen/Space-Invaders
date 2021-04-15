using UnityEngine;
using System.Collections;

public class RespawInimigoBonusScript : MonoBehaviour {

    public GameObject inimigoBonus;
    public float intervalo;
    public float fireRate;

    // Use this for initialization
    void Start() {
        //Gravar o tempo inicial
        fireRate = Time.time;
    }

    // Update is called once per frame
    void Update() {
        if (ControladorJogo.Singleton.temJogador == true) {
            if (ControladorJogo.Singleton.podeGerarInimigoBonus == true) {
                if (Time.time - fireRate >= intervalo) {

                    Instantiate(inimigoBonus, this.transform.position, this.transform.rotation);

                    //Atualizando tempo do ultimo respaw
                    fireRate = Time.time;
                }
            }
        }
        //Debug.Log("Update Inimigo Bonus");	
    }
}