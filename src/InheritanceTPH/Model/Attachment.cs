using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceTPH.Model;


internal abstract class Attachment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

internal class Video : Attachment
{
    public int Lenght { get; set; }
    public string Rating { get; set; }
}

internal class Audio : Attachment
{
    public byte Bitrate { get; set; }
}