using System;
using System.ComponentModel;

namespace Redux
{
    public class Store: INotifyPropertyChanged
    {
        public interface IAction { }
        public class ActionPlus : IAction { }
        public class ActionMinus : IAction { }

        private State _state;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public State State
        { 
            get{ return _state; }
            set
            {
                _state = value;

                OnPropertyChanged("State");
            }
        }

        public Store(State state)
        {
            State = state;
        }

        public void Dispather(IAction action, State state)
        {

                if( action is ActionPlus)
                {
                    State = ReducerPlus(state);
                }
                else if(action is ActionMinus)
                {
                    State = ReducerMinus(state);
                }
                else
                { 
                    throw new InvalidOperationException();
                }
        }

        private State ReducerPlus(State state)
        {
            return new State(state.Count + 1);
        }

        private State ReducerMinus(State state)
        {
            return new State(state.Count - 1);
        }
    }
}