﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
    /// <summary>
    /// WaveFormatExtensible
    /// http://www.microsoft.com/whdc/device/audio/multichaud.mspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 2)]	
    public class WaveFormatExtensible : WaveFormat
    {        
        short wValidBitsPerSample; // bits of precision, or is wSamplesPerBlock if wBitsPerSample==0
        int dwChannelMask; // which channels are present in stream
        Guid subFormat;

        public WaveFormatExtensible(int rate, int bits, int channels)
            : base(rate, bits, channels)
        {
            extraSize = 22;
            wValidBitsPerSample = (short) bits;
            for (int n = 0; n < channels; n++)
            {
                dwChannelMask |= (1 << n);
            }
            if (bits == 32)
            {
                // KSDATAFORMAT_SUBTYPE_IEEE_FLOAT
                subFormat = new Guid("00000003-0000-0010-8000-00aa00389b71");
            }
            else
            {
                // KSDATAFORMAT_SUBTYPE_PCM
                subFormat = new Guid("00000001-0000-0010-8000-00aa00389b71");
            }

        }

        public override string ToString()
        {
            return String.Format("{0} wBitsPerSample:{1} dwChannelMask:{2} subFormat:{3}",
                base.ToString(),
                wValidBitsPerSample,
                dwChannelMask,
                subFormat);
        }
    }
}