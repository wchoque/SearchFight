using System;
using System.Collections.Generic;
using System.Text;

namespace Tranzact.Cignium.SearchFight.Services.DTOs
{
    public class SearchResponseDTO
    {
        public string SearchEngineName { get; set; }
        public string Term { get; set; }
        public long TotalResults { get; set; }
    }
}
