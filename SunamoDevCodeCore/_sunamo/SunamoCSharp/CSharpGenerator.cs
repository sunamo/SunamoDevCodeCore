namespace SunamoCSharp;

internal partial class CSharpGenerator : GeneratorCodeAbstract //, ICSharpGenerator
{

    private void WriteAccessModifiers(AccessModifiers accessModifier)
    {
        if (accessModifier == AccessModifiers.Public)
        {
            sb.AddItem("public");
        }
        else if (accessModifier == AccessModifiers.Protected)
        {
            sb.AddItem("protected");
        }
        else if (accessModifier == AccessModifiers.Private)
        {
            // Private is default - no keyword needed
        }
        else if (accessModifier == AccessModifiers.Internal)
        {
            sb.AddItem("public");
        }
        else
        {
            ThrowEx.NotImplementedCase(accessModifier);
        }
    }

    public void Field(int tabCount, AccessModifiers accessModifier, bool isStatic, VariableModifiers variableModifiers, string type, string name, bool isAddingHyphensToValue, string value)
    {
        var initializationOption = ObjectInitializationOptions.Original;
        if (isAddingHyphensToValue)
            initializationOption = ObjectInitializationOptions.Hyphens;
        Field(tabCount, accessModifier, isStatic, variableModifiers, type, name, initializationOption, value);
    }

    public void Field(int tabCount, AccessModifiers accessModifier, bool isStatic, VariableModifiers variableModifiers, string type, string name, ObjectInitializationOptions initializationOption, string value)
    {
        AddTab(tabCount);
        ModifiersField(accessModifier, isStatic, variableModifiers);
        ReturnTypeName(type, name);
        sb.AddItem("=");
        if (initializationOption == ObjectInitializationOptions.Hyphens)
            value = "\"" + value + "\"";
        else if (initializationOption == ObjectInitializationOptions.NewAssign)
            value = "new " + type + "()";
        var statement = value + ";";
        sb.AddItem(statement);
        sb.AppendLine();
    }

    private void ModifiersField(AccessModifiers accessModifier, bool isStatic, VariableModifiers variableModifiers)
    {
        WriteAccessModifiers(accessModifier);
        if (variableModifiers == VariableModifiers.Mapped)
        {
            sb.AddItem("const");
        }
        else
        {
            if (isStatic && variableModifiers == VariableModifiers.ReadOnly)
            {
                sb.AddItem("const");
            }
            else
            {
                if (isStatic)
                    sb.AddItem("static");
                if (variableModifiers == VariableModifiers.ReadOnly)
                    sb.AddItem("readonly");
            }
        }
    }
}