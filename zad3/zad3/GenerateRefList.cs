using System;
using System.Collections.Generic;

namespace zad3;

public static class GenerateRefList
{
    public static void generateReferenceList(List<int> l)
    {
        for (int time = 0; time < CONST.DistanceOfReferenceLocality; time++)
            l.Add(new Random().Next(CONST.Pages));


        int size = 0;
        for (int time = CONST.DistanceOfReferenceLocality; time < CONST.N; time++)
        {
            if (new Random().NextDouble() < CONST.chanceOfLocality)
                size = CONST.SizeOfBaseReferenceLocality;

            if (size > 0)
            {
                int index = new Random().Next(time - CONST.DistanceOfReferenceLocality, time);
                l.Add(l[index]);
            }
            else
                l.Add(new Random().Next(CONST.Pages));

            size--;
        }
    }
}