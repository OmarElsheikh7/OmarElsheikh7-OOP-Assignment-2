namespace SrpLab.srpLabRefactor
{
    public class TranscriptPrinter
    {
        public string TranscriptPlain(string id, string name, decimal avg, string letter, bool honor) =>
            $"TRANSCRIPT\nStudent: {name} ({id})\nAverage: {avg}\nLetter: {letter}\nHonor: {honor}\n";
    }
}
