using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerProgress : MonoBehaviour
    {
        public int highScore;
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
