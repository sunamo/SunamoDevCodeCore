namespace SunamoDevCodeCore._sunamo.SunamoDevCodeBase;

internal abstract class GeneratorCodeAbstract
{

    protected InstantSB sb = new(" ");
    public XmlDoc xmlDoc;

    public GeneratorCodeAbstract()
    {
        xmlDoc = new XmlDoc(sb);
    }

    // Returns the generated code and resets the string builder
    public override string ToString()
    {
        var result = sb.ToString();
        sb = new InstantSB(" ");
        return result;
    }

    public void AddTab(int tabCount)
    {
        for (var index = 0; index < tabCount; index++) sb.AddRaw("\t");
    }
}