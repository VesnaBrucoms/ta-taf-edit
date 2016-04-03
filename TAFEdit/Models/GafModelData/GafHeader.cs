using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFEdit.Models.GafModelData
{
    class GafHeader
    {
        public int IdVersion; //Always 0x00010100
        public int Entries;
        public int Unknown1; //Always 0
    }
}
