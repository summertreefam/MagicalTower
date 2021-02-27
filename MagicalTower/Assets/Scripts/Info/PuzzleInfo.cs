using UnityEngine;

using NGame.NType;

namespace NGame.NInfo
{
    public class PuzzleInfo
    {
        public int Index { get; set; }
        public EPuzzleType EPuzzleType { get; set; }
        public EPuzzleState EPuzzleState { get; set; }
        public Vector2Int Position { get; set; }

        public static PuzzleInfo Create()
        {
            return new PuzzleInfo()
            {
                Index = 0,
                EPuzzleType = EPuzzleType.Disable,
                EPuzzleState = EPuzzleState.Show,
                Position = Vector2Int.zero,
            };
        }
    }
}

