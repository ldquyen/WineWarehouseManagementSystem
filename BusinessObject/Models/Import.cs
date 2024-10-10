    using System;
    using System.Collections.Generic;

    namespace BusinessObject.Models;

    public partial class Import
    {
        public int ImportId { get; set; }

        public DateOnly? ImportDate { get; set; }

        public int? AccountId { get; set; }

        public string? Note { get; set; }

        public virtual Account? Account { get; set; }

        public virtual ICollection<ImportDetail> ImportDetails { get; set; } = new List<ImportDetail>();
    }
