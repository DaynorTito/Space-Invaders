using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersDaynorTito.Model;
public class Score
{
    public string PlayerName { get; set; }
    public int Points { get; set; }

    public Score(String name, int point)
    {
        PlayerName = name;
        Points = point; 

    }
}
