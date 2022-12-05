using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace BallGame.Animals.Imp
{
    public class Dog: Animal
    {
        private enum State
        {
            Peaceful,
            Angry,
            Crazy
        }
        
        [SerializeField] private float peacefulDistance;
        [SerializeField] private float angryDistance;
        [SerializeField] private float crazyDistance;

        private class StagesBehaviour
        {
            public class StageBehaviour
            {
                public State State { get; private set; }
                public Action Action { get; private set; }
                public float Distance { get; private set; }

                public StageBehaviour(State state, Action action, float distance)
                {
                    State = state;
                    Action = action;
                    Distance = distance;
                }
            }
            
            private List<StageBehaviour> StageBehaviours;

            public StagesBehaviour()
            {
                StageBehaviours = new List<StageBehaviour>();
            }

            public StagesBehaviour(List<StageBehaviour> stageBehaviours)
            {
                StageBehaviours = stageBehaviours;
                StageBehaviours = StageBehaviours.OrderBy(behaviour => behaviour.Distance).ToList();
            }

            [CanBeNull]
            public StageBehaviour GetStageBehaviour(State state)
            {
                return StageBehaviours.FirstOrDefault(behaviour => behaviour.State == state);
            }
            
            [CanBeNull]
            public StageBehaviour GetStageBehaviour(float distance)
            {
                return StageBehaviours.FirstOrDefault(behaviour => behaviour.Distance > distance);
            }
        }

        private StagesBehaviour _behaviour;
        private State _currentState;
        

        protected override void Check()
        {
            var distance = Vector3.Distance(transform.position, _target.transform.position);
            var state = _behaviour.GetStageBehaviour(distance);
            if (state != default && _currentState != state.State)
                state.Action.Invoke();
        }

        protected override void BreakCheck()
        {
            Idle();
        }

        protected override void SubclassInit() =>
            _behaviour = new StagesBehaviour(new List<StagesBehaviour.StageBehaviour>
            {
                new(State.Peaceful, Idle, peacefulDistance),
                new(State.Angry, Angry, angryDistance),
                new(State.Crazy, Crazy, crazyDistance),
            });

        private void Idle()
        {
            Debug.Log($"{name} is peaceful");
            _currentState = State.Peaceful;
        }

        private void Angry()
        {
            Debug.Log($"{name} is argry");
            _currentState = State.Angry;
        }

        private void Crazy()
        {
            Debug.Log($"{name} is crazy");
            _currentState = State.Crazy;
        }
    }
}