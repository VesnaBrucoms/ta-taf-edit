using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAFEdit.Models.GafModelData;

namespace TAFEdit.Models
{
    class GafModel
    {
        public GafHeader Header;
        public int[] PtrEntries;
        public GafEntry[] Entries;
    }
}
