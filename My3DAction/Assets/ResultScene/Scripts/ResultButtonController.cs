using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButtonController : MonoBehaviour
{

    public void OnClick()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
