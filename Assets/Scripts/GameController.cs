using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Text TextoPontuacao;
    public PlayerController player;
    Vector3 posicaoInicial;
    public float divisorDaPontuacao;
    public GameObject painelGameOver;
    public GameObject PainelVitoria;
    
    public AudioClip sfxVenceuJogo;
    public AudioController audioController;
    public LevaNaveAoPlaneta levaNaveAoPlaneta;
    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            return;
        }
        Vector3 distanciaPercorrida = player.transform.position - posicaoInicial;
        float pontuacao = distanciaPercorrida.z / divisorDaPontuacao;
        TextoPontuacao.text = pontuacao.ToString("0");
    }

    public void GameOver()
    {
        painelGameOver.SetActive(true);
    }

    public void VencerJogo()
    {
        audioController.ToqueSFX(sfxVenceuJogo);
        PainelVitoria.SetActive(true);
        levaNaveAoPlaneta.LeveNaveAoPlaneta();
        
    }

    public void RecarregarLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
