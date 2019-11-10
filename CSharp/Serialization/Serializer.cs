using System;
using System.Runtime.InteropServices;

namespace CSharp.Serialization
{
    public class Serializer
    {
        // look like no simple way to get size of managed object, so just take big bytes count
        public static byte[] SerializeToBytes(object obj, int bytesCount)
        {
            var pointer = IntPtr.Zero;
            var buffer = new byte[bytesCount];

            try
            {
                pointer = Marshal.AllocCoTaskMem(bytesCount);
                Marshal.GetNativeVariantForObject(obj, pointer);
                Marshal.Copy(pointer, buffer, 0, bytesCount);
            }
            finally
            {
                Marshal.Release(pointer);
            }

            return buffer;
        }

        public static object DeserializeFromBytes(byte[] buffer)
        {
            var pDestination = IntPtr.Zero;

            try
            {
                pDestination = Marshal.AllocCoTaskMem(buffer.Length);
                Marshal.Copy(buffer, 0, pDestination, buffer.Length);
                object obj = Marshal.GetObjectForNativeVariant(pDestination);

                return obj;
            }
            finally
            {
                Marshal.Release(pDestination);
            }
        }
    }
}
