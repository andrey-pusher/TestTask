namespace Domain.Extensions
{
    public static class ValidationExtensions
    {
        public static void ThrowExceptionIfNull(this object element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }
        }
    }
}