using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFEdit.InputOutput
{
    /// <summary>
    /// Handles file serialization and deserialization.
    /// </summary>
    public class Serialization
    {
        #region Writing
        #endregion

        #region Reading
        /// <summary>
        /// Reads a single byte.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pnt"></param>
        /// <returns></returns>
        public static byte ReadByte(byte[] data, ref int pnt)
        {
            byte value = data[pnt];
            pnt++;
            return value;
        }

        /// <summary>
        /// Reads a short.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pnt"></param>
        /// <returns></returns>
        public static short ReadShort(byte[] data, ref int pnt)
        {
            short value = (short)((data[pnt + 1] << 8) | (data[pnt]));
            pnt = pnt + 2;
            return value;
        }

        /// <summary>
        /// Reads a single byte char.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pnt"></param>
        /// <returns></returns>
        public static char ReadChar(byte[] data, ref int pnt)
        {
            char value = (char)((data[pnt]));
            pnt = pnt + 1;
            return value;
        }

        /// <summary>
        /// Reads a 32-bit (4 bytes) integer.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pnt"></param>
        /// <returns></returns>
        public static int ReadInt(byte[] data, ref int pnt)
        {
            int value = ((data[pnt + 3] << 24) | (data[pnt + 2] << 16) | (data[pnt + 1] << 8) | (data[pnt]));
            pnt = pnt + 4;
            return value;
        }

        /// <summary>
        /// Reads a 64-bit (8 bytes) integer.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pnt"></param>
        /// <returns></returns>
        public static long ReadLong(byte[] data, ref int pnt)
        {
            int value = ((data[pnt + 7] << 56) | (data[pnt + 6] << 48) | (data[pnt + 5] << 40) | (data[pnt + 4] << 32) | 
                (data[pnt + 3] << 24) | (data[pnt + 2] << 16) | (data[pnt + 1] << 8) | (data[pnt]));
            pnt = pnt + 8;
            return value;
        }
        #endregion
    }
}
