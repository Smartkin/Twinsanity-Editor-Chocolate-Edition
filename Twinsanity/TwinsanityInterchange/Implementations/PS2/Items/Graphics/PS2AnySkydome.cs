﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twinsanity.TwinsanityInterchange.Enumerations;
using Twinsanity.TwinsanityInterchange.Interfaces.Items;

namespace Twinsanity.TwinsanityInterchange.Implementations.PS2.Items.Graphics
{
    public class PS2AnySkydome : ITwinSkydome
    {
        UInt32 id;

        public Int32 Header; // Unused by the game
        public List<UInt32> Meshes;

        public PS2AnySkydome()
        {
            Meshes = new List<UInt32>();
        }

        public UInt32 GetID()
        {
            return id;
        }

        public int GetLength()
        {
            return 4 + Meshes.Count * Constants.SIZE_UINT32;
        }

        public void Read(BinaryReader reader, int length)
        {
            Header = reader.ReadInt32();
            var meshes = reader.ReadInt32();
            for (int i = 0; i < meshes; ++i)
            {
                Meshes.Add(reader.ReadUInt32());
            }
        }

        public void SetID(UInt32 id)
        {
            this.id = id;
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Header);
            for (int i = 0; i < Meshes.Count; ++i)
            {
                writer.Write(Meshes[i]);
            }
        }
    }
}
