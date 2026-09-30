namespace SunamoDevCode;

internal abstract class GeneratorCodeAbstract
{

    protected InstantSB sb = new(" ");
    public XmlDoc xmlDoc;

    public GeneratorCodeAbstract()
    {
        xmlDoc = new XmlDoc(sb);
    }

    // EN: Returns the generated code and resets the string builder
    // CZ: Vrátí vygenerovaný kód a resetuje string builder
    public override string ToString()
    {
        var result = sb.ToString();
        sb = new InstantSB(" ");
        return result;
    }

    public void AddTab(int tabCount)
    {
        //tabCount += 1;
        for (var i = 0; i < tabCount; i++) sb.AddRaw("\t");
    }
}
