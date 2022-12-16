namespace Rick_And_Morty.Helpers
{
    public static class ConvertHalper
    {
        //String to Uri parser.
        public static Uri? ToUri(this string value) => 
            String.IsNullOrEmpty(value) || !Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute) 
            ? null : 
            new Uri(value);
        
        //String to DataTime parser.
        public static DateTime ToDataTime(this string value) => 
            String.IsNullOrEmpty(value) ? DateTime.MinValue : DateTime.Parse(value);
            
    }
}
