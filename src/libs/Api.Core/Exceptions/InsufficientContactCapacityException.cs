namespace Api.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class InsufficientContactCapacityException : ValidationException
    {
        public readonly int ContactCount;
        public readonly int RemainingCapacity;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactCount"></param>
        /// <param name="remainingCapacity"></param>
        public InsufficientContactCapacityException(int contactCount, int remainingCapacity) : 
            base($"The customer only has {contactCount} contact capacity which is insufficient to insert {remainingCapacity} contacts.")
        {
            ContactCount = contactCount;
            RemainingCapacity = remainingCapacity;
        }
        
        public InsufficientContactCapacityException() : 
            base($"You have exceeded the current contact capacity.")
        {
            
        }
    }
}
