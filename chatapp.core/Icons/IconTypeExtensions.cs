namespace chatapp.core
{
    public static class IconTypeExtensions
    {
        public static string ToFontAwesome(this IconType type)
        {
            switch (type) 
            {
                case IconType.File:
                    return "\uf15b";
                case IconType.Picture:
                    return "\uf1c5";
                default:
                    return null;
            }
        }
    }
}
