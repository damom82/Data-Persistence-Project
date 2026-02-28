using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenuUI : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void StartGame()
    {
        MainManager.Instance.playerName = nameInput.text;
        SceneManager.LoadScene("MainGame");
    }
}