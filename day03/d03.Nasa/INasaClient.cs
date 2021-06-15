using Microsoft.VisualBasic;

namespace day03.d03.Nasa
{
    public interface INasaClient<in TIn, out TOut>
    {
        TOut GetAsync(TIn input);
    }
}