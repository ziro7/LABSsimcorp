using System.Collections.Generic;

namespace LABSsimcorp {
    public class CallList {
        public List<Call> incommingCallList = new List<Call>();
        public List<Call> outgoingCallList = new List<Call>();
        public CallList() {

        }

        public void AddIncommingCall(Call call) {
            if (IsNewCallSameAsLatestIncommingCall(call)){ return; }

            incommingCallList.Add(call);
            incommingCallList.Sort();
        }



        public void AddOutgoingCall(Call call) {
            if (IsNewCallSameAsLatestOutgoingCall(call)) { return; };
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

        private bool IsNewCallSameAsLatestIncommingCall(Call call) {
            if(incommingCallList.Count>0 && call.Equals(incommingCallList[0])) {
                incommingCallList[0].AssociatedCalls.Add(call);
                return true;
            }
            return false;
        }

        private bool IsNewCallSameAsLatestOutgoingCall(Call call) {
            if (outgoingCallList.Count > 0 && call.Equals(outgoingCallList[0])) {
                outgoingCallList[0].AssociatedCalls.Add(call);
                return true;
            }
            return false;
        }
    }
}
