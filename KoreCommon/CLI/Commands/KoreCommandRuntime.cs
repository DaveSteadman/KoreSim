// <fileheader>

using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KoreCommon;

public class KoreCommandRuntime : KoreCommand
{
    public KoreCommandRuntime()
    {
        Signature.Add("runtime");
    }

    public override string Execute(List<string> parameters)
    {
        StringBuilder sb = new();

        sb.AppendLine($"Application runtime {KoreCentralTime.RuntimeSecs:F2} seconds");

        return sb.ToString();
    }
}


