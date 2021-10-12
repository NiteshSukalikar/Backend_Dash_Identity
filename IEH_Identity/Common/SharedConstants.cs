using System;
using System.Collections.Generic;
using System.Text;

namespace IEH_Shared.StaticConstants
{
    /// <summary>
    /// Defines the <see cref="SharedConstants" />
    /// </summary>
    public static class SharedConstants
    {
        public const string IdentityURL = "https://localhost:44322";
        public const string ClientId = "3X=nNv?Sgu$S";
        public const string ClientSecret = "1554db43-3015-47a8-a748-55bd76b6af48";
        public const string Scope = "openid app.api.weather offline_access ";

        /// <summary>
        /// Gets or sets the GeneralException
        /// </summary>
        public static string GeneralException = "Something went wrong! Please try after sometime.";

        public static string OperationSuccessful = "Operation Successful.";

        public static string LogFilePath = @"..\LogFolder\";

        /// <summary>
        /// Gets or sets the DbConn
        /// </summary>
        public static string DbConn { get; set; }

        /// <summary>
        /// Defines the DefaultPageSize
        /// </summary>
        public const int DefaultPageSize = 30;

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
        /// Defines the RecordSavedSuccessfully
        /// </summary>
        public const string RecordSavedSuccessfully = "C200";

        /// <summary>
        /// Defines the RecordUpdatedSuccessfully
        /// </summary>
        public const string RecordUpdatedSuccessfully = "C201";

        /// <summary>
        /// Defines the RecordAlreadyExists
        /// </summary>
        public const string RecordAlreadyExists = "C203";
        /// <summary>
        /// Defines the RecordAlreadyExists
        /// </summary>
        public const string DeletedSuccessfully = "C204";

        public const string FailedToDelete = "C224";
        public const string RecordDeletedSuccessfully = "C204";
        public const string RecordNotExists = "C205";
        public const string UnAuthorized = "401";

        public const string OfferDescAlreadyExist = "C211";

        public const string MemberActiveDeactiveSuccess = "C300";

        /// <summary>
        /// Defines the InchoraCompanyId
        /// </summary>
        public const int InchoraCompanyId = 1;

        /// <summary>
        /// Defines the keybytes
        /// </summary>
        public const string keybytes = "7061737323313233";

        /// <summary>
        /// Defines the iv
        /// </summary>
        public const string iv = "7061737323313233";

        public static string Ok = "200";

        public static int NumberOfOldPasswords = 5;
    }
}
