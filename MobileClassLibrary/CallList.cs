using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABSsimcorp {
    public class CallList {
        public List<Call> incommingCallList = new List<Call>();
        public List<Call> outgoingCallList = new List<Call>();
        public CallList() {

        }

        public void AddIncommingCall(Call call) {
            incommingCallList.Add(call);
            incommingCallList.Sort();
        }

        public void AddOutgoingCall(Call call) {
            outgoingCallList.Add(call);
            outgoingCallList.Sort();
        }

        public void RemoveIncommingCall(Call call) {
            if(incommingCallList.IndexOf(call) != -1) {
                incommingCallList.RemoveAt(incommingCallList.IndexOf(call));
            }
        }

        public void RemoveOutgoingCall(Call call) {
            if (outgoingCallList.IndexOf(call) != -1) {
                outgoingCallList.RemoveAt(outgoingCallList.IndexOf(call));
            }
        }
    }
}
