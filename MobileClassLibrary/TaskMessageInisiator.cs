using System;
using System.Threading.Tasks;

namespace LABSsimcorp {
    public class TaskMessageInisiator : MessageInisiator {

        Task generatingMessages;

        public TaskMessageInisiator(MobilePhone phoneToMessage, int intervalBetweenTicks = 1000)
            : base(phoneToMessage, intervalBetweenTicks = 1000) {
        }

        public override void StartService() {

            generatingMessages = new Task(() => {
                GenerateMessages();
            });
            generatingMessages.Start();

        }

        public override void StopService() {
            if(generatingMessages == null) { return; }
            generatingMessages.Dispose();
            StopMessages();
        }
    }
}
