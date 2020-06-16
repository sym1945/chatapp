using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatapp.web.server
{
    /// <summary>
    /// A response to a SendGrid SendMessage call
    /// </summary>
    public class SendGridResponse
    {
        /// <summary>
        /// Any errors from a response
        /// </summary>
        public List<SendGridResponseError> Errors { get; set; }
    }
}
