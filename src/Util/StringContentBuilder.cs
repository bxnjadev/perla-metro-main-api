using System.Text;
using System.Text.Json;

namespace perla_metro_main_api.Util;

public class StringContentBuilder
{
    private string _body = string.Empty;
    private string _contentType = string.Empty;
    private Encoding _encoding = Encoding.UTF8;

    public StringContentBuilder()
    {
    }

    public static StringContentBuilder Builder()
    {
        return new StringContentBuilder();
    }


    public StringContentBuilder SetEncoding(Encoding encoding)
    {
        _encoding = encoding;
        return this;
    }

    public StringContentBuilder ContentTypeJson()
    {
        _contentType = "application/json";
        return this;
    }

    public StringContentBuilder ContentTypeTextPlain()
    {
        _contentType = "text/plain";
        return this;
    }

    public StringContentBuilder Body(Object obj)
    {
        _body = JsonSerializer.Serialize(obj);
        return this;
    }

    public StringContent Build()
    {
        return new StringContent(_body, _encoding, _contentType);
    }
}