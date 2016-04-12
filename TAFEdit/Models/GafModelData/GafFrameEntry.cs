using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFEdit.Models.GafModelData
{
    class GafFrameEntry
    {
        public int PtrFrameTable;
        public int Unknown; //Varies

        public GafFrameData FrameData;
    }
}
