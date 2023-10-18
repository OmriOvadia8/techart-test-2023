using UnityEngine;

namespace Communix.Techart.Test
{
    [RequireComponent(typeof(Animator))]
    public class PopupBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        private void Reset()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            animator.SetTrigger("Play");
        }
        
        public void OnClosePressed()
        {
            animator.SetTrigger("Close");
        }
    }
}