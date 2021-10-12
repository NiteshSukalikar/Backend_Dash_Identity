namespace IEH_Dashboard.ViewModel.Shared
{
    /// <summary>
    /// Defines the AuditLogVM
    /// </summary>
    public class AuditLogVM
    {
        /// <summary>
        /// Gets or sets the Payload
        /// </summary>
        public string Payload { get; set; }

        /// <summary>
        /// Gets or sets the Method
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the Endpoint
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Gets or sets the RequestType
        /// </summary>
        public long RequestType { get; set; }

        /// <summary>
        /// Gets or sets the Response
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy
        /// </summary>
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedOn
        /// </summary>
        public long CreatedOn { get; set; }
    }
}
