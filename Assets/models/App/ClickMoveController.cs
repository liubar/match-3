using UnityEngine;

namespace App
{
    public class ClickMoveController : BaseMoveController
    {
        protected override bool InputIsActive()
        {
            return Input.GetMouseButtonUp(0);
        }

        protected override Vector3 GetPosition()
        {
            return Input.mousePosition;
        }
    }
}