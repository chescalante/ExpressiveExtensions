namespace ExpressiveExtensions.Core
{
    public class Configuration
    {
        private static string _EmailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                              + "@"
                                              + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

        private static string _IPPattern = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

        private static string _UrlPattern = @"(file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp):\/\/"
                                            + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" // user@
                                            + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
                                            + "|" // allows either IP or domain
                                            + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
                                            + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]" // second level domain
                                            + @"(\.[a-z]{2,6})?)" // first level domain- .com or .museum is optional
                                            + "(:[0-9]{1,5})?" // port number- :80
                                            + "((/?)|" // a slash isn't required if there is no file name
                                            + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";

        public static string EmailPattern
        {
            get { return _EmailPattern; }
        }

        public static string IPPattern
        {
            get { return _IPPattern; }
        }

        public static string UrlPattern
        {
            get { return _UrlPattern; }
        }

        public Configuration SetEmailPattern(string pattern)
        {
            _EmailPattern = pattern;

            return this;
        }

        public Configuration SetIPPattern(string pattern)
        {
            _IPPattern = pattern;

            return this;
        }

        public Configuration SetUrlPattern(string pattern)
        {
            _UrlPattern = pattern;

            return this;
        }
    }
}
