using UnityEngine;
using UnityEngine.SceneManagement;

public class NextMapLoader : MonoBehaviour
{
    [SerializeField] private string nextLevelName = "Level1";
    public void LoadNextMap(){
        SceneManager.LoadScene(nextLevelName);
    }
}

