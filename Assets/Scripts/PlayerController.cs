using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;
  public int forcaEmX;
  public int forcaEmZ;
  public GameController gameController;
  public float velocidadeMaximaZ = 150;
  public GameObject FXExplosaoPrefab;
  public float anguloAlvo = 30;
  public float velocidaDeRotacao = 5; 

    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame

    void FixedUpdate()
    {
      if (rb.velocity.z < velocidadeMaximaZ)
      {
        rb.AddForce(0, 0, forcaEmZ * Time.deltaTime);
      }
      if(Input.GetKey("a") == true)
      {
        rb.AddForce(-forcaEmX * Time.fixedDeltaTime, 0, 0);
        
        Quaternion rotacaoAtual = rb.rotation;
        Quaternion rotacaoAlvo = Quaternion.Euler(0, 0, anguloAlvo);
        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidaDeRotacao);
        rb.MoveRotation(novaRotacao);
      }

      else if(Input.GetKey("d") == true)
      {
        rb.AddForce(forcaEmX * Time.fixedDeltaTime, 0, 0);

        Quaternion rotacaoAtual = rb.rotation;
        Quaternion rotacaoAlvo = Quaternion.Euler(0, 0, -anguloAlvo);
        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidaDeRotacao);
        rb.MoveRotation(novaRotacao);
      }

      else
      {
        Quaternion rotacaoAtual = rb.rotation;
        Quaternion rotacaoAlvo = Quaternion.Euler(0, 0, 0);
        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidaDeRotacao);
        rb.MoveRotation(novaRotacao);
      }


    }

  void OnCollisionEnter(Collision collision) 
  {
    
    Debug.Log("Eu colidi com algo" + collision.collider.name);

    if(collision.collider.CompareTag("Inimigo") == true)
    {
      GameObject.Instantiate(FXExplosaoPrefab, this.transform.position, this.transform.rotation);
      Destroy(this.gameObject);
      gameController.GameOver();
    }
  }

  void OnTriggerEnter(Collider trigger) {

    if (trigger.CompareTag("Planeta"))
    {
      gameController.VencerJogo();
    }   
  }
		
}
