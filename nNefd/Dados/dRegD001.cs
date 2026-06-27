using System.Collections.Generic;

namespace nsEfd
{
    public class ColecaoD001 : List<dRegD001> { }

    public class dRegD001
    {
        public string reg { get; set; }
        public string ind_mov { get; set; }
    }
}
