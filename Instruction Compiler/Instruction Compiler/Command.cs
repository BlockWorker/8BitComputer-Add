using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instruction_Compiler {
    public class Command {
        public List<HashSet<SignalState>> SignalSteps { get; set; } = new List<HashSet<SignalState>>();
        public string Name { get; set; } = "";
        public byte Code { get; set; } = 0;
        public List<Command> Variants { get; set; } = new List<Command>();

        public Command() {
            
        }

        public Command(Command origin, bool variant) {
            InitEmpty();
            Name = origin.Name;
            if (!variant) foreach (var v in origin.Variants) Variants.Add(new Command(v, true));
            for (int i = 0; i < 16; i++) {
                var newSet = new HashSet<SignalState>();
                foreach (var sig in origin.SignalSteps[i]) newSet.Add(new SignalState(sig));
                SignalSteps[i] = newSet;
            }
        }

        public void InitEmpty() {
            for (int i = 0; i < 16; i++) SignalSteps.Add(new HashSet<SignalState>());
        }
    }
}
