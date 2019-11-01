namespace Core {
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a transaction used by sample code.
    /// </summary>
    public class Transaction {
        /// <summary>
        /// Gets or sets account id for the transaction.
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets amount for the transaction.
        /// </summary>
        [Range (0, double.MaxValue)]
        public decimal Amount { get; set; }
    }
    /// <summary>
    /// Class representing an Account for samples.
    /// </summary>

    public class Account {
        /// <summary>
        /// Gets or sets account id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets account balance.
        /// </summary>
        public decimal Balance { get; set; }
    }

}