using ModelsMatch3;
using ModelsMatch3.interfaces;
using UnityEngine;

namespace DomainLayer
{
    public class Cell : MonoBehaviour, ICell
    {
        private CellState state = CellState.free;
        private Collider colider;
        private bool dragging;
        
        public int CompareTo(ICell other)
        {
            return Piece.CompareTo(other.Piece);
        }

        public IPiece Piece { get; set; }

        public CellState CellState
        {
            get { return state; }
            set { state = value; }
        }


        private Vector3 lastMousePosition;

        void OnMouseDown()
        {
            lastMousePosition = Input.mousePosition;
            dragging = true;
        }

        void OnMouseDrag()
        {
            Vector3 distance = Input.mousePosition - lastMousePosition;

            if(!dragging || dragging && distance.magnitude < 30) return;
            
            if (colider == null) return;
            var gObj = colider.gameObject;

            //gObj.GetComponent<Rigidbody>().AddForce(distance, ForceMode.Impulse);

            if (gObj == null) return;
            var piece = gObj.GetComponent<IPiece>();

            if (piece == null) return;
            piece.Destroy();

            dragging = false;
        }

        void OnTriggerStay(Collider other)
        {
            colider = other;
        }
    }
}