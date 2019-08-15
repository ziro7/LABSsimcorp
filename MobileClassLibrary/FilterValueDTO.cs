using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABSsimcorp {
    public class FilterValueDTO {
        public string UserName { get; set; }
        public string MessageSearchText { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public FilterValueDTO(string username, string messageSearchText, DateTime fromDate, DateTime toDate) {
            UserName = username;
            MessageSearchText = messageSearchText;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
