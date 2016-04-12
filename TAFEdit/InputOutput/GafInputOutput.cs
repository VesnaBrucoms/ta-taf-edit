using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAFEdit.Models;
using TAFEdit.Models.GafModelData;

namespace TAFEdit.InputOutput
{
    class GafInputOutput
    {
        #region Writing
        #endregion

        #region Reading
        public static GafModel Read(string filepath)
        {
            GafModel model = new GafModel();
            byte[] fileBytes = new byte[0];
            int filePtr = 0;

            if (filepath != "" && filepath != null)
            {
                fileBytes = System.IO.File.ReadAllBytes(filepath);
            }

            model.Header = readHeader(fileBytes, ref filePtr);
            model.PtrEntries = new int[model.Header.Entries];
            for (int i = 0; i < model.PtrEntries.Length; i++)
            {
                model.PtrEntries[i] = Serialization.ReadInt(fileBytes, ref filePtr);
            }

            model.Entries = new GafEntry[model.Header.Entries];
            for (int i = 0; i < model.Entries.Length; i++)
            {
                model.Entries[i] = readEntry(fileBytes, model.PtrEntries[i]);
            }

            return model;
        }

        private static GafHeader readHeader(byte[] fileBytes, ref int filePtr)
        {
            GafHeader header = new GafHeader();
            header.IdVersion = Serialization.ReadInt(fileBytes, ref filePtr);
            header.Entries = Serialization.ReadInt(fileBytes, ref filePtr);
            header.Unknown1 = Serialization.ReadInt(fileBytes, ref filePtr);

            return header;
        }

        private static GafEntry readEntry(byte[] fileBytes, int entryPtr)
        {
            GafEntry entry = new GafEntry();
            entry.Frames = Serialization.ReadShort(fileBytes, ref entryPtr);
            entry.Unknown1 = Serialization.ReadShort(fileBytes, ref entryPtr);
            entry.Unknown2 = Serialization.ReadInt(fileBytes, ref entryPtr);
            entry.Name = new char[32];
            for (int i = 0; i < entry.Name.Length; i++)
            {
                entry.Name[i] = Serialization.ReadChar(fileBytes, ref entryPtr);
            }

            for (int i = 0; i < entry.Frames; i++)
            {
                entry.FrameEntries[i] = new GafFrameEntry();
                entry.FrameEntries[i].PtrFrameTable = Serialization.ReadInt(fileBytes, ref entryPtr);
                entry.FrameEntries[i].Unknown = Serialization.ReadInt(fileBytes, ref entryPtr);

                entry.FrameEntries[i].FrameData = new GafFrameData();
                int framePtr = entry.FrameEntries[i].PtrFrameTable;
                entry.FrameEntries[i].FrameData.Width = Serialization.ReadShort(fileBytes, ref framePtr);
                entry.FrameEntries[i].FrameData.Height = Serialization.ReadShort(fileBytes, ref framePtr);
                entry.FrameEntries[i].FrameData.XPos = Serialization.ReadShort(fileBytes, ref framePtr);
                entry.FrameEntries[i].FrameData.YPos = Serialization.ReadShort(fileBytes, ref framePtr);
                entry.FrameEntries[i].FrameData.Unknown1 = Serialization.ReadChar(fileBytes, ref framePtr);
                entry.FrameEntries[i].FrameData.Compressed = Serialization.ReadChar(fileBytes, ref framePtr);
                entry.FrameEntries[i].FrameData.FramePointers = Serialization.ReadShort(fileBytes, ref framePtr);
                entry.FrameEntries[i].FrameData.Unknown2 = Serialization.ReadInt(fileBytes, ref framePtr);
                entry.FrameEntries[i].FrameData.PtrFrameData = Serialization.ReadInt(fileBytes, ref framePtr);
                entry.FrameEntries[i].FrameData.Unknown3 = Serialization.ReadInt(fileBytes, ref framePtr);

                if (entry.FrameEntries[i].FrameData.FramePointers == 0)
                {
                    int loopPtrPixels = entry.FrameEntries[i].FrameData.PtrFrameData;
                    //entry.FrameEntries[i].FrameData.Pixels = new PixelData();
                    entry.FrameEntries[i].FrameData.RawPixelData = new byte[entry.FrameEntries[i].FrameData.Width * entry.FrameEntries[i].FrameData.Height];
                    for (int y = 0; y < entry.FrameEntries[i].FrameData.Height; y++)
                    {
                        short lineLength = Serialization.ReadShort(fileBytes, ref loopPtrPixels);
                        int xPixel = 0;
                        for (int x = 0; x < lineLength; x++)
                        {
                            byte mask = Serialization.ReadByte(fileBytes, ref loopPtrPixels);
                            if ((mask & 0x01) == 0x01)
                            {
                                xPixel += (mask >> 1);
                            }
                            else if ((mask & 0x02) == 0x02)
                            {
                                int repeat = (mask >> 2) + 1;
                                for (int r = repeat; r > 0; r--)
                                {
                                    entry.FrameEntries[i].FrameData.AddPixel(entry.FrameEntries[i].FrameData.Width, xPixel++, y, mask);
                                }
                                x++;
                                loopPtrPixels++;
                            }
                            else
                            {
                                int repeat = (mask >> 2) + 1;
                                for (int r = repeat; r > 0; r--)
                                {
                                    int ptr = loopPtrPixels;
                                    entry.FrameEntries[i].FrameData.AddPixel(entry.FrameEntries[i].FrameData.Width, xPixel++, y, Serialization.ReadByte(fileBytes, ref ptr));
                                    x++;
                                    loopPtrPixels++;
                                }
                            }
                        }
                    }
                }
            }

            return entry;
        }
        #endregion
    }
}
