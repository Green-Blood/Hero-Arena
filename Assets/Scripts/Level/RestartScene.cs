using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class RestartScene : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
        }
    }
}
