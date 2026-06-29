using System.Collections.Generic;

namespace NEFd
{
    public class ColecaoG001 : List<dRegG001> { }

    public class dRegG001
    {
        public string reg { get; set; }
        public string ind_mov { get; set; }
    }
}
