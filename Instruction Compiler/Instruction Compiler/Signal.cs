using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instruction_Compiler
{
    public abstract class Signal
    {
        public string Name { get; set; } = "";
        public string FullName { get; set; } = "";
        public int Chip { get; set; } = 0;

        public abstract byte GetBits();
        public abstract byte GetShiftOffset();
    }

    public class BasicSignal : Signal
    {
        public int Bit { get; set; } = 0;
        public bool Inverted { get; set; } = false;

        public override byte GetBits()
        {
            return (byte)(1 << Bit);
        }

        public override byte GetShiftOffset() {
            return (byte)Bit;
        }
    }

    public class MultiplexedSignal : Signal
    {
        private int _bits;
        public int Bits {
            get { return _bits; }
            set {
                _bits = value;
                var newsig = new MultiSubSignal[1 << _bits];
                if (SubSignals != null) Array.Copy(SubSignals, newsig, Math.Min(newsig.Length, SubSignals.Length));
                SubSignals = newsig;
                for (int i = 0; i < SubSignals.Length; i++)
                {
                    if (SubSignals[i] != null) continue;
                    SubSignals[i] = new MultiSubSignal(Offset, i);
                    SubSignals[i].Chip = Chip;
                }
            }
        }
        public int Offset { get; set; } = 0;
        public MultiSubSignal[] SubSignals { get; set; } = null;

        public MultiplexedSignal(int chip = 0, int bits = 2)
        {
            Chip = chip;
            Bits = bits;
            FullName = "Multiplexed Signal";
        }

        public MultiplexedSignal()
        {
            Chip = 0;
            Bits = 2;
            FullName = "Multiplexed Signal";
        }

        public override byte GetBits()
        {
            return (byte)((0xff >> (8 - Bits)) << Offset);
        }

        public override byte GetShiftOffset() {
            return (byte)Offset;
        }
    }

    public class MultiSubSignal : Signal {
        public int Value { get; set; } = 0;
        public int Offset = 0;

        public MultiSubSignal(int offset, int value)
        {
            Value = value;
            Offset = offset;
        }

        public MultiSubSignal() { }

        public override byte GetBits()
        {
            return (byte)(Value << Offset);
        }

        public override byte GetShiftOffset() {
            return (byte)Offset;
        }
    }

    public class SignalState
    {
        public string SigName { get; set; } = "";
        public int Value { get; set; } = 0;
        public Signal Signal { get { return Program.getSignal(SigName); } }
        
        public SignalState() { }

        public SignalState(BasicSignal sig)
        {
            SigName = sig.Name;
            Value = 1;
        }

        public SignalState(MultiplexedSignal sig, int value)
        {
            SigName = sig.Name;
            Value = value;
        }

        public SignalState(string name, int value = 0)
        {
            SigName = name;
            Value = value;
        }

        public SignalState(SignalState origin) {
            SigName = origin.SigName;
            Value = origin.Value;
        }

        public byte GetValueBits() {
            return (byte)(Value << Signal.GetShiftOffset());
        }

        public override bool Equals(object obj) {
            if (!(obj is SignalState)) return false;
            var s = (SignalState)obj;
            return SigName == s.SigName && Value == s.Value;
        }
    }
}
