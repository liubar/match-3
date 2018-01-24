using UnityEngine;

namespace Domain
{
    public class PieceTrigger : MonoBehaviour
    {
        public Collider colider;

        void OnTriggerStay(Collider other)
        {
            colider = other;
        }

        void OnTriggerExit(Collider other)
        {
            colider = null;
        }
    }
}