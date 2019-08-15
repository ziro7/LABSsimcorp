using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LABSsimcorp;

namespace DelegateMessageForm {
    class ListViewOutput : IOutput {

        public ListView MessageListView { get; set; }

        public ListViewOutput(ListView listView) {
            MessageListView = listView;
        }

        public void Write(string text) {
            throw new NotImplementedException();
        }

        public void WriteLine(string text) {
            MessageListView.Items.Clear();
            MessageListView.Items.Add(new ListViewItem(new[] { text }));
        }

        public void WriteLine(List<LABSsimcorp.Message> messages, MobilePhone.FormatDelegate formatter) {

            MessageListView.Items.Clear();
            foreach (LABSsimcorp.Message message in messages) {
                var user = message.User.Name;
                var text = formatter.Invoke(message.Text);
                MessageListView.Items.Add(new ListViewItem(new string [2] { user, text }));
            }
        }
    }
}
