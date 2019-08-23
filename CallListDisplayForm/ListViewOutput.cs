using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LABSsimcorp;

namespace CallListDisplayForm {
    class ListViewOutput : IOutput {

        public ListView CallListView { get; set; }

        public ListViewOutput(ListView listView) {
            CallListView = listView;
        }

        public void Write(string text) {
            throw new NotImplementedException();
        }

        public void WriteLine(string text) {
            CallListView.Items.Clear();
            CallListView.Items.Add(new ListViewItem(new[] { text }));
        }

        public void WriteLine(List<Call> calls) {
            CallListView.Items.Clear();
            foreach (Call call in calls) {
                var user = call.Contact.Name;
                var calltime = call.CallTime.ToLongTimeString();
                var number = call.ContactNumber.ToString();
                var consequtiveCallsAmount = call.AssociatedCalls.Count.ToString();
                var item = new ListViewItem();
                item.Text = user;
                item.SubItems.Add(calltime);
                item.SubItems.Add(number);
                item.SubItems.Add(consequtiveCallsAmount);
                CallListView.Items.Add(item);
            }
        }

        public void WriteLine(List<LABSsimcorp.Message> messages, MobilePhone.FormatDelegate formatter) {
            throw new NotImplementedException();
        }
    }
}
