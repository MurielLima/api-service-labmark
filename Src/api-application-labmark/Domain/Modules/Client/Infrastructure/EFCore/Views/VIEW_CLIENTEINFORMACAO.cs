﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace Labmark.Domain.Modules.Client.Infrastructure.EFCore.Views
{
    [Keyless]
    public partial class VIEW_CLIENTEINFORMACAO
    {
        [StringLength(255)]
        public string NOME { get; set; }
        [StringLength(14)]
        public string CPFCNPJ { get; set; }
        [StringLength(1)]
        public string TIPOPESSOA { get; set; }
        [StringLength(319)]
        public string ENDERECO { get; set; }
        [StringLength(8)]
        public string CEP { get; set; }
        [StringLength(63)]
        public string TELEFONE { get; set; }
        [StringLength(100)]
        public string EMAIL { get; set; }
    }
}
