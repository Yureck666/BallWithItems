using System;
using System.Collections.Generic;

namespace BallGame
{
    public static class TargetClassDetection
    {
        public static Dictionary<DetectionType, Type> DetectionType { get; } = new Dictionary<DetectionType, Type>
        {
            {BallGame.DetectionType.Player, typeof(PlayerMove)}
        };
    }
}