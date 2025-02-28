//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MartoyanWGUP2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Partner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partner()
        {
            this.PartnerProducts = new HashSet<PartnerProduct>();
        }
    
        public int ID { get; set; }
        public int PartnerTypeID { get; set; }
        public string PartnerName { get; set; }
        public string DirectorFirstName { get; set; }
        public string DirectorLastName { get; set; }
        public string DirectorPatronymic { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string LegalAddress { get; set; }
        public string INN { get; set; }
        public Nullable<double> Rating { get; set; }
        public Nullable<decimal> Discount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartnerProduct> PartnerProducts { get; set; }
        public virtual PartnersType PartnersType { get; set; }
    }
}
