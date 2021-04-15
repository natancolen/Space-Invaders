using UnityEngine;
using System.Collections;

public class TiroBonusScript : MonoBehaviour {


    int velTiroBonus = 5;

    // Update is called once per frame
    void Update() {

        this.transform.position -= this.transform.up * velTiroBonus;

        if (this.transform.position.y < -8) {
            Destroy(this.gameObject);
        }

    }
    
    void OnTriggerEnter(Collider outroCollisor) {
        if (this.tag != outroCollisor.tag) {
            if (outroCollisor.tag == "Escudo") {
                Destroy(outroCollisor.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
