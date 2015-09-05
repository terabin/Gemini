using System.IO;
using System.Text;
using IronRuby.Builtins;
using Microsoft.Scripting.Hosting;
using zlib;

namespace Gemini
{
  abstract class Ruby
  {
    private static ScriptRuntime _rubyRuntime;
    private static ScriptEngine _rubyEngine;
    private static ScriptScope _rubyScope;

    /// <summary>
    /// Creates instances of the Ruby engine and Ruby scope
    /// </summary>
    public static void CreateRuntime()
    {
      _rubyRuntime = IronRuby.Ruby.CreateRuntime();
      _rubyEngine = IronRuby.Ruby.GetEngine(_rubyRuntime);
      _rubyScope = _rubyEngine.CreateScope();
      _rubyEngine.Execute(@"load_assembly 'IronRuby.Libraries', 'IronRuby.StandardLibrary.Zlib'", _rubyScope);
    }

    public static byte[] MarshalDump(object data)
    {
      _rubyScope.SetVariable("data", data);
      MutableString result = _rubyEngine.Execute(@"Marshal.dump(data)", _rubyScope);
      _rubyScope.RemoveVariable("data");
      return result.ToByteArray();
    }

    public static object MarshalLoad(byte[] data)
    {
      _rubyScope.SetVariable("data", MutableString.CreateBinary(data));
      object result = _rubyEngine.Execute(@"Marshal.load(data)", _rubyScope);
      _rubyScope.RemoveVariable("data");
      return result;
    }

    /// <summary>
    /// Inflates the compressed string using Ruby's Zlib module
    /// </summary>
    /// <param name="data">The Ruby string to decompress</param>
    /// <returns>The decompressed Ruby string as a System.String</returns>
    public static string ZlibInflate(MutableString data)
    {
      _rubyScope.SetVariable("data", data);
      MutableString result = _rubyEngine.Execute(@"Zlib::Inflate.inflate(data)", _rubyScope);
      _rubyScope.RemoveVariable("data");
      return ConvertString(result);
    }

    /// <summary>
    /// Deflate a string using zlib.net library since IronRuby's Deflate module is buggy, fuck
    /// </summary>
    /// <param name="data">The string to compress</param>
    /// <returns>The decompressed string as a Ruby string</returns>
    public static MutableString ZlibDeflate(string data)
    {
      using (MemoryStream outMemoryStream = new MemoryStream())
      using (ZOutputStream outZStream = new ZOutputStream(outMemoryStream, zlibConst.Z_BEST_COMPRESSION))
      {
        byte[] bytes = Encoding.UTF8.GetBytes(data);
        outZStream.Write(bytes, 0, bytes.Length);
        outZStream.finish();
        return MutableString.CreateBinary(outMemoryStream.ToArray());
      }
    }

    public static string ConvertString(MutableString rubyString)
    {
      return rubyString.ToString(Encoding.UTF8);
    }

    public static MutableString ConvertString(string csString)
    {
      return MutableString.Create(csString, RubyEncoding.UTF8);
    }
  }
}