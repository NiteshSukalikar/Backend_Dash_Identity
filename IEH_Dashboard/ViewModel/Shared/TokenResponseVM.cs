namespace IEH_Dashboard.ViewModel.Shared
{
    /// <summary>
    /// Defines the TokenResponseVM
    /// </summary>
    public class TokenResponseVM
    {
        /// <summary>
        /// Gets or sets the Data
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the StatusCode
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether HasUpdatedToken
        /// Gets or sets the HasUpdatedToken
        /// </summary>
        public bool HasUpdatedToken { get; set; }

        /// <summary>
        /// Gets or sets the Token
        /// </summary>
        public object Token { get; set; }

        /// <summary>
        /// Gets or sets the Code
        /// </summary>
        public string Code { get; set; }
    }
}
