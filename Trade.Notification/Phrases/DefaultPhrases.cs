namespace Trade.Notification.Phrases
{
    public static class DefaultPhrases
    {
        #region OPERATIONAL ERRORS
        public static readonly string GENERIC_ERROR = "An error has occurred, please contact your administrator.";
        public static readonly string PERSISTENCE_ERROR = "A persistence error has occurred, please contact your administrator.";
        public static readonly string STORAGE_ERROR = "A storage error has occurred, please contact your administrator.";
        #endregion

        #region INPUT DATA VALIDATION ERRORS
        public static readonly string DYNAMIC_REQUIRED_FIELD_ERROR = "Invalid Input. Field {0} required.";
        public static readonly string DYNAMIC_INVALID_FIELD_DATA_ERROR = "Invalid Data. Check field {0}.";
        public static readonly string DYNAMIC_REQUIRED_FIELD_WITH_LINE_ERROR = "Invalid Input. Field {0} on line {1} required.";
        public static readonly string DYNAMIC_INVALID_FIELD_DATA_WITH_LINE_ERROR = "Invalid Data. Check field {0} on line {1}.";
        public static readonly string DYNAMIC_MESSAGE_WITH_LINE_ERROR = "Error found on line {1}.{0}";
        public static readonly string DYNAMIC_MESSAGE_ERROR = "Error found. {0}";

        #endregion


    }
}
