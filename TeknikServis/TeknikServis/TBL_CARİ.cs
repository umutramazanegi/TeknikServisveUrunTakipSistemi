//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknikServis
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_CARİ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_CARİ()
        {
            this.TBL_FATURABILGI = new HashSet<TBL_FATURABILGI>();
            this.TBL_URUNHAREKET = new HashSet<TBL_URUNHAREKET>();
            this.TBL_URUNKABUL = new HashSet<TBL_URUNKABUL>();
        }
    
        public int ID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string TELEFON { get; set; }
        public string MAIL { get; set; }
        public string IL { get; set; }
        public string ILCE { get; set; }
        public string BANKA { get; set; }
        public string VERGIDAIRESI { get; set; }
        public string VERGINO { get; set; }
        public string STATU { get; set; }
        public string ADRES { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_FATURABILGI> TBL_FATURABILGI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_URUNHAREKET> TBL_URUNHAREKET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_URUNKABUL> TBL_URUNKABUL { get; set; }
    }
}
