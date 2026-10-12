namespace SrpLab.srpLabRefactor
{
    public class DecisionLetterGenerator
    {
        public string DecisionLetter(string name, decimal amount, decimal risk, bool eligible, IEnumerable<string> docs) =>
            eligible ? $"Dear {name},\nYour request for {amount:C} is pre-approved (risk {risk:0}).\nPlease upload: {string.Join("; ", docs)}.\n" :
                       $"Dear {name},\nWe are unable to approve {amount:C} at this time.\nReference risk={risk:0}. You may reapply after improving documentation.\n";
    }
}
