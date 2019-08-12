using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABSsimcorp {
    public class OutputFormat {

        public static string FormatToUpper(string message) => message.ToUpper();

        public static string FormatToLower(string message) => message.ToLower();

        public static string FormatFunish(string message) { 

            var sortedList = new List<char>();

            foreach (char letter in message) {
                sortedList.Add(letter);
            }
            sortedList.Sort();
            var messageBackwards = new StringBuilder();

            foreach (char letter in sortedList) {
                messageBackwards.Append(letter);
            }

            return messageBackwards.ToString();
        }

        public static string FormatShorten(string message) {
            var random = new Random();
            var startPosition = random.Next(0, message.Length - 1);
            return message.Substring(startPosition, message.Length - 1-startPosition);
        }

        public static string FormatReplacer(string message) {
            var returnMessage = new StringBuilder();

            foreach (char letter in message) {
                if (letter == 'S') {
                    returnMessage.Append("M");
                } else if (letter == 'e') {
                    returnMessage.Append('%');
                } else {
                    returnMessage.Append('-');
                }
            }
            return returnMessage.ToString();
        }
    }
}
