using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RTS
{
    public class StateMachine
    {
        protected State currentState;

        protected Dictionary<Type, List<Transition>> transitions = new Dictionary<Type, List<Transition>>();
        protected List<Transition> currentTransitions = new List<Transition>();
        protected List<Transition> anyTransitions = new List<Transition>();
        protected List<Transition> emptyTransitions = new List<Transition>(0);

        public void Tick()
        {
            var transition = GetTransition();
            if (transition != null)
                SetState(transition.To);
            
            currentState?.Tick();
        }

        public void AddTransition(State from, State to, Func<bool> condition)
        {
            if (transitions.TryGetValue(from.GetType(), out var listTransitions) == false)
            {
                listTransitions = new List<Transition>();
                transitions[from.GetType()] = listTransitions;
            }
            listTransitions.Add(new Transition(to, condition));
        } 
        public void AddAnyTransition(State state, Func<bool> condition) 
            => anyTransitions.Add(new Transition(state, condition));

        public void SetState(State state)
        {
            if(currentState == state)
                return;
            Debug.Log($"{currentState?.GetType().Name} -> {state.GetType().Name}");
            currentState?.Exit();
            currentState = state;

            transitions.TryGetValue(currentState.GetType(), out currentTransitions);
            if (currentTransitions == null)
                currentTransitions = emptyTransitions;
            
            currentState.Enter();
        }

        Transition GetTransition()
        {
            foreach (var transition in anyTransitions)
                if (transition.Condition())
                    return transition;

            foreach (var transition in currentTransitions)
                if (transition.Condition())
                    return transition;
            return null;
        }
        
        protected class Transition
        {
            public Func<bool> Condition { get; }
            public State To { get; }

            public Transition(State to, Func<bool> condition)
            {
                To = to;
                Condition = condition;
            }
        }
    }
}