using System;

namespace LABSsimcorp {
    public interface IMessageInisiator {
        MobilePhone PhoneToMessage { get; set; }

        void GenerateMessages();
        void OnElapsedHandler(object sender, EventArgs e);
        void StartService();
        void StopMessages();
        void StopService();
    }
}