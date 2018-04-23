using UnityEngine;

namespace Assets.Scripts
{
    public class Explosion : MonoBehaviour
    {
        public float _delay;

        private void Start()
        {
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
