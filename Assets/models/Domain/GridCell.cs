using UnityEngine;

namespace Domain
{
    public class GridCell : MonoBehaviour, IGridCell
    {
        private CellState state = CellState.free;
        private Collider colider;
        private bool dragging;
        private Vector3 lastMousePosition;

        public IGridPosition GridPosition { get; set; }

        public bool IsEmpty
        {
            get
            {
                if (Piece == null)
                    return true;
                
                return false;
            }
        }

        public IPiece Piece
        {
            get
            {
                if (colider == null) return null;
                return colider.GetComponent<IPiece>();
            }
        }

        public CellState CellState
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        ///     Checks for the presence of a chip in current cell
        /// </summary>
        /// <param name="piece">checkable chip</param>
        /// <returns>true == 'current cell contains piece'</returns>
        public bool ContainsPiece(IGridCell piece)
        {
            if (Piece == null || piece.Piece == null)
                return false;

            return Piece.Equals(piece.Piece);
        }

        void OnMouseDown()
        {
            lastMousePosition = Input.mousePosition;
            dragging = true;
        }

        /// <summary>
        ///     Move piece when dragging
        /// </summary>
        void OnMouseDrag()
        {
            Vector3 distance = Input.mousePosition - lastMousePosition;
            if (!(GameContext.Instance.State is WaitingState)) return;
            if (!dragging || dragging && distance.magnitude < 20) return;
            if (Piece == null) return;

            GameContext.Instance.State = new SwapState(this, distance);
            dragging = false;
        }
        
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