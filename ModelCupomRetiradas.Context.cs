﻿//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarbaSoftware
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class bd_CupomVendas : DbContext
    {
        public bd_CupomVendas()
            : base("name=bd_CupomVendas")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<PreencherCupomRetirada_Result> PreencherCupomRetirada(string operador)
        {
            var operadorParameter = operador != null ?
                new ObjectParameter("operador", operador) :
                new ObjectParameter("operador", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PreencherCupomRetirada_Result>("PreencherCupomRetirada", operadorParameter);
        }
    }
}
