using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Le Canvas ou le panneau du menu pause
    private bool isPaused = false; // État du jeu (en pause ou non)

    public void Update()
    {
        // Vérifier si la touche "Échap" est pressée
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Fonction pour reprendre le jeu
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Désactiver le menu pause
        Time.timeScale = 1f; // Reprendre le temps
        isPaused = false;
    }

    // Fonction pour mettre le jeu en pause
    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Activer le menu pause
        Time.timeScale = 0f; // Arrêter le temps
        isPaused = true;
    }

    public void QuitButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}