using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class StoryTimerOne : MonoBehaviour
    {
        public float Timer;

        private void Update()
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                SceneManager.LoadScene("Story 2");
            }
        }
    }
}
