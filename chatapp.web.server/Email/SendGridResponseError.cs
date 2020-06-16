using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatapp.web.server
{
    /// <summary>
    /// An error response for a <see cref="SendGridResponse"/>
    /// </summary>
    public class SendGridResponseError
    {
        /// <summary>
        /// The error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The filed inside the email message details that the error is related to
        /// </summary>
        public string Filed { get; set; }

        /// <summary>
        /// Useful information for resolving the error
        /// </summary>
        public string Help { get; set; }
    }
}
