using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LVLselector : MonoBehaviour
{
    public int index;

    private void Start()
    {
        
    }
    public void OpenScene()
    {
        SceneManager.LoadScene("LVL " + index.ToString());
    }
}