using System.Collections.Generic;

namespace NEFd
{
    public class ColecaoH001 : List<dRegH001> { }

    public class dRegH001
    {
        public string reg { get; set; }
        public string ind_mov { get; set; }
    }
}
