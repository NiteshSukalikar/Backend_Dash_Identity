using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Identity.Common
{
    public static class Constants
    {
        /// <summary>
        /// Gets or sets the DbConn
        /// </summary>
        public static string DbConn { get; set; }

        /// <summary>
        /// Defines the DefaultPageSize
        /// </summary>
        public const int DefaultPageSize = 10;

        /// <summary>
        /// Defines the DefaultPageNo
        /// </summary>
        public const int DefaultPageNo = 1;

        /// <summary>
        /// Defines the MaxPageSize
        /// </summary>
        public const int MaxPageSize = 500;

        /// <summary>
        /// Defines the CommentMaxLength
        /// </summary>
        public const int CommentMaxLength = 300;

        /// <summary>
        /// Defines the TextMaxLenght
        /// </summary>
        public const int TextMaxLenght = 5000;

        /// <summary>
        /// Gets or sets the TokenSecretKey
        /// </summary>
        public static string TokenSecretKey { get; set; }

        /// <summary>
        /// Gets or sets the TokenIssuer
        /// </summary>
        public static string TokenIssuer { get; set; }

        /// <summary>
        /// Gets or sets the TokenAudience
        /// </summary>
        public static string TokenAudience { get; set; }

        /// <summary>
        /// Gets or sets the TokenExpiryDays
        /// </summary>
        public static int TokenExpiryDays { get; set; }

        /// <summary>
        /// Gets or sets the LogFilePath
        /// </summary>
        public static string LogFilePath { get; set; }

        /// <summary>
        /// Credentials error message
        /// </summary>
        public static string InvalidCredentialsErrorMessage = "Invalid username or password";

    }
}
