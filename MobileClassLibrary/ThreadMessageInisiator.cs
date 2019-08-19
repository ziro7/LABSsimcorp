using System.Threading;

namespace LABSsimcorp {
    public class ThreadMessageInisiator : MessageInisiator {

        Thread messageThread;

        public ThreadMessageInisiator (MobilePhone phoneToMessage, int intervalBetweenTicks = 1000)
            : base(phoneToMessage, intervalBetweenTicks = 1000) {
        }

        public override void StartService() {
            messageThread = new Thread(new ThreadStart(GenerateMessages));
            messageThread.Start();
        }

        public override void StopService() {
            if (messageThread == null) { return; }
            messageThread.Abort();
            StopMessages();
        }
    }
}
