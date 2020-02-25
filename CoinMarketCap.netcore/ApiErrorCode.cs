namespace CoinMarketCap
{
    public class ApiErrorCode
    {
        public int ErrorCode { get; }

        public string ErrorName { get; }
        
        public string ErrorMessage { get; }

        public int HttpStatus { get; }

        public static ApiErrorCode ApyKeyInvalid =
            new ApiErrorCode(1001, "API_KEY_INVALID", "This API Key is invalid.", 401);
        //TODO: Add remaining ErrorCodes

        private ApiErrorCode(int errorCode, string errorName, string errorMessage, int httpStatus)
        {
            ErrorCode = errorCode;
            ErrorName = errorName;
            ErrorMessage = errorMessage;
            HttpStatus = httpStatus;
        }

        //TODO: Structured enum operators and conversions

    }
}
