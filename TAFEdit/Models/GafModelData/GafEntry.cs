using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFEdit.Models.GafModelData
{
    class GafEntry
    {
        private short frames;

        public short Unknown1; //Always 1
        public int Unknown2; //Always 0
        public char[] Name;
        public GafFrameEntry[] FrameEntries;

        public short Frames
        {
            get { return frames; }
            set
            {
                frames = value;
                FrameEntries = new GafFrameEntry[value];
            }
        }
    }
}
