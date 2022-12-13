using ATEA_coding_challenge.Extensions.Interfaces;

namespace ATEA_coding_challenge.Extensions;

public class ExtensionWrapper : IWrapper
{
    private readonly string[] _args;
    public ExtensionWrapper(string[] args)
    {
        _args = args;
    }
    public void WriteResult(string[] args)
    {
        args.SumFirstTwoArgs();
    }
}