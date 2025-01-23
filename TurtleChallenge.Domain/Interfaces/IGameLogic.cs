﻿using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Enums;
using TurtleChallenge.Domain.ValueObjects;

namespace TurtleChallenge.Domain.Interfaces
{
    public interface IGameLogic
    {
        GameOutcome EvaluateTurtleState(Turtle turtle);
    }
}
