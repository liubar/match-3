﻿using UnityEngine;

namespace Domain
{
    public class Piece : MonoBehaviour, IPiece
    {
        public PieceType type;

        private bool _isDisposed = false;

        public PieceType Type
        {
            get { return type; }
        }
        
        public void Clear()
        {
            Destroy(gameObject);
            _isDisposed = true;
        }

        public bool Equals(IPiece other)
        {
            if (other == null || _isDisposed)
                return false;

            return type == other.Type;
        }

        public override int GetHashCode()
        {
            return type.GetHashCode();
        }
    }
}