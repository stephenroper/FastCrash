using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class StoryTimer : MonoBehaviour
    {
        public float Timer;

        private void Update()
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                SceneManager.LoadScene("Story 1");
            }
        }
    }
}
