using UnityEngine;

namespace App
{
    public class TouchMoveController : BaseMoveController
    {
        protected override Vector3 GetPosition()
        {
            return Input.touches[0].position;
        }

        protected override bool InputIsActive()
        {
            if (Input.touches.Length == 0)
                return false;

            return Input.touches[0].phase == TouchPhase.Began;
        }
    }
}
