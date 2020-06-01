using System;
using System.Collections.Generic;
using System.Text;

namespace Tranzact.Cignium.SearchFight.Services.DTOs
{
    public class DetailTermDTO
    {
        public string Term { get; set; }
        public List<DetailSearchEngineResultDTO> DetailSearchEngineResult { get; set; }
    }
}
