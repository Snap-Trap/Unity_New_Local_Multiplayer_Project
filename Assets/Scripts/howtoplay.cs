using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class howtoplay : MonoBehaviour
{
    // Start is called before the first frame update
    public void back()
    {
        SceneManager.LoadScene("scene2");
    }
}
