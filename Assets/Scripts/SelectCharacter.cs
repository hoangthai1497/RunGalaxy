using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public GameObject[] characters;
    public int selectCharacter = 0;
    private Animator _anim;
    private void Start()
    {
        characters[0].SetActive(true);
        
    }
    public void OnClickNextButton()
    {
        characters[selectCharacter].SetActive(false);
        selectCharacter = (selectCharacter + 1) % characters.Length;
        characters[selectCharacter].SetActive(true);

    }
    public void OnClickPreviousButton()
    {
        characters[selectCharacter].SetActive(false);
        selectCharacter--;
        if (selectCharacter < 0)
        {
            selectCharacter += characters.Length;
        }
        characters[selectCharacter].SetActive(true);
    }

    
    public void StartGameButton()
    {
        PlayerPrefs.SetInt("selectCharacter", selectCharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
