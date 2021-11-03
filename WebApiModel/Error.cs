namespace WebApiModel
{
    public class ErrorModel
    {
        private static string _servererror;
        public static string ServerError
        {
            get { return _servererror; }
            set { _servererror = "Server error try after some time."; }
        }
    }
}
