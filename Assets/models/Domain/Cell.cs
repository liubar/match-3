using UnityEngine;

namespace Domain
{
    public class Cell : MonoBehaviour, ICell
    {
        private CellState state = CellState.free;
        private Collider colider;
        private bool dragging;
        private Vector3 lastMousePosition;

        public IPiece Piece { get; set; }

        public IGridPosition GridPosition { get; set; }

        public CellState CellState
        {
            get { return state; }
            set { state = value; }
        }

        public IPieceProvider PieceProvider { get; set; }

        public bool ContainsPiece(ICell piece)
        {
            return Piece.Equals(piece.Piece);
        }

        void OnMouseDown()
        {
            lastMousePosition = Input.mousePosition;
            dragging = true;
        }

        void OnMouseDrag()
        {
            Vector3 distance = Input.mousePosition - lastMousePosition;
            if(!dragging || dragging && distance.magnitude < 30) return;

            var piece = GetPiece();
            if (piece == null) return;




            PieceProvider.Move(this, distance);

            //piece.Clear();




            dragging = false;
        }

        void OnTriggerEnter(Collider other)
        {
            colider = other;
            Piece = GetPiece();
        }

        /*
        void OnTriggerStay(Collider other)
        {
            colider = other;
        }
        */
        private IPiece GetPiece()
        {
            if (colider == null) return null;
            var gObj = colider.gameObject;

            //gObj.GetComponent<Rigidbody>().AddForce(distance, ForceMode.Impulse);

            if (gObj == null) return null;
            return gObj.GetComponent<IPiece>();
        }
    }
}