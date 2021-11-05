using System;
using System.Runtime.InteropServices;

namespace UnsafeUtils
{
    public static class UnsafeUtils
    {
        static unsafe bool ByteCompare<T>(T s1, T s2) where T : struct
        {
            var s1chars = Marshal.AllocHGlobal(Marshal.SizeOf(s1));
            Marshal.StructureToPtr(s1,s1chars,false);
            var s2chars = Marshal.AllocHGlobal(Marshal.SizeOf(s1));
            Marshal.StructureToPtr(s1,s1chars,false);
            var span1 = new Span<char>(s1chars.ToPointer(), Marshal.SizeOf(s1));
            var span2 = new Span<char>(s2chars.ToPointer(), Marshal.SizeOf(s2));
            bool result = MemoryExtensions.SequenceEqual(span1, span2);
            Marshal.FreeHGlobal(s1chars);
            Marshal.FreeHGlobal(s2chars);
            return result;
        }

        static unsafe int HashCode<T>(T s) where T : struct
        {
            var size = Marshal.SizeOf(s);
            var schars = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(s,schars,false);
            int[] intArray = new int[(int) (Math.Ceiling((float) size) / 4)];
            //var span = new Span<char>(schars.ToPointer(), Marshal.SizeOf(s));
            Marshal.Copy(schars, intArray, 0, size);
            HashCode hashCode = new HashCode();
            foreach (var i in intArray)
            {
                hashCode.Add(i);
            }
            Marshal.FreeHGlobal(schars);
            return hashCode.ToHashCode();
        }
    }
    
}

public class Class1
{
}