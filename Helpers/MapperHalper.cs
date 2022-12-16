namespace Rick_And_Morty.Helpers
{
    public static class MapperHalper
    {
        //String to Uri parser.
        public static Uri? ToUri(this string value)
        {
            try
            {
                var isnull = String.IsNullOrEmpty(value);
                var isWFUS = !Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute);
                if (isnull || isWFUS)
                {
                    return null;
                }
                else
                {
                    return new Uri(value);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
        //String to DataTime parser.
        public static DateTime ToDataTime(this string value) => 
            String.IsNullOrEmpty(value) ? DateTime.MinValue : DateTime.Parse(value);
            
    }
}
