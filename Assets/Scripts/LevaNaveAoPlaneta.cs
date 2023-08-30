using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevaNaveAoPlaneta : MonoBehaviour
{

    public PlayerController player;
    public GameObject planeta;
    public float forcaAoPlaneta = 200;
    public Seguir_Jogador seguir_Jogador;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        Vector3 direcaoAoPlaneta = planeta.transform.position - player.transform.localPosition;
        if (direcaoAoPlaneta.magnitude < 25.0f)
        {
            this.enabled = false;
            player.rb.velocity = new Vector3(0, 0, 0);
            return;
        }
        direcaoAoPlaneta.Normalize();
        player.rb.AddForce(direcaoAoPlaneta * Time.fixedDeltaTime * forcaAoPlaneta);
    }

    public void LeveNaveAoPlaneta()
    {
        this.enabled = true;
        seguir_Jogador.enabled = false;
        player.rb.velocity = new Vector3(0, 0, 0);
        player.enabled = false;
    }
        
}
