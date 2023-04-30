using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        private string state;

        public string CodeName { get; }
        public string State 
        {
            get { return state; }
            private set
            {
                state = "inProgress";
            }
        }

        public void CompleteMission()
        {
            State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
