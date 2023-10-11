using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField usernameInput;
    //public TMP_Text message;
    public Animator anim;

    public void OnStartButtonClick()
    {
        string username = usernameInput.text;
        if(username != "")
        {
            SceneManager.LoadScene("GameScene0");
        }
        else
        {
            //message.enabled = true;
            anim.SetFloat("Alpha", 0);
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string username = usernameInput.text;
        if (username != "" && anim.GetFloat("Alpha") == 0)
        {
            anim.SetFloat("Alpha", 1);
        }
    }
}
