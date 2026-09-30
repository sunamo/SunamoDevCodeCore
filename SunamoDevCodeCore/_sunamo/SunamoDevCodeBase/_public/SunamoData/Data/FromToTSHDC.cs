namespace SunamoDevCodeCore._sunamo.SunamoDevCodeBase._public.SunamoData.Data;

internal class FromToTSHDC<T>
{
    protected long fromL;
    // A3 true = DateTime, A3 False = None
    public FromToUseDC ftUse = FromToUseDC.DateTime;
    protected long toL;

    public FromToTSHDC()
    {
        var type = typeof(T);
        if (type == typeof(int)) ftUse = FromToUseDC.None;
    }

    public T from
    {
        get => (T)(dynamic)fromL;
        set => fromL = (long)(dynamic)value!;
    }

    public T to
    {
        get => (T)(dynamic)toL;
        set => toL = (long)(dynamic)value!;
    }
}