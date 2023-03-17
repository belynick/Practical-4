using System;
using System.Collections.Generic;

namespace Fourth
{

    class Action1 { }
    class Action2 { }
    class Action3 { }

    enum State
    {
        Start,
        Action1Completed,
        Action2Completed,
        Action3Completed,
        End
    }

    delegate void WorkflowEvent();

    class Workflow
    {
        private State currentState = State.Start;

        private Dictionary<State, WorkflowEvent> eventHandlers = new Dictionary<State, WorkflowEvent>();

        public void AddEventHandlers()
        {
            eventHandlers[State.Start] = () => { Console.WriteLine("Starting workflow"); currentState = State.Action1Completed; };
            eventHandlers[State.Action1Completed] = () => { Console.WriteLine("Action 1 completed"); currentState = State.Action2Completed; };
            eventHandlers[State.Action2Completed] = () => { Console.WriteLine("Action 2 completed"); currentState = State.Action3Completed; };
            eventHandlers[State.Action3Completed] = () => { Console.WriteLine("Action 3 completed"); currentState = State.End; };
            eventHandlers[State.End] = () => { Console.WriteLine("Workflow completed"); };
        }

        public void TriggerWorkflow()
        {
            while (currentState != State.End)
            {
                eventHandlers[currentState]?.Invoke();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Workflow workflow = new Workflow();
            workflow.AddEventHandlers();

            workflow.TriggerWorkflow();

            Console.ReadLine();
        }
    }
}