using System.Collections;
using Domain;
using UnityEngine;

namespace App
{
    public class SpawnCell : MonoBehaviour, ISpawnCell
    {
        public IGridCell UpperCell { get; set; }
        public IPieceGenerator PieceGenerator { get; set; }
        public IPiece Piece { get; set; }
        
        private bool beingHandled = false;
        
        void Update()
        {
            if (!beingHandled)
            {
                StartCoroutine(HandleIt());
            }
        }

        /// <summary>
        ///     Creating chip
        /// </summary>
        /// <returns>waiting time</returns>
        private IEnumerator HandleIt()
        {
            beingHandled = true;
            yield return new WaitForSeconds(0.3f);

            if (UpperCell.Piece == null)
            {
                PieceGenerator.GeneratePiece(this);
            }

            beingHandled = false;
        }
    }
}