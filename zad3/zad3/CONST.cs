namespace zad3
{
    public class CONST
    {
        public static int N => 20_000;
        public static int Frames => 100; // <- the higher, the closest results
        public static int Pages => 1000;
        public static int DistanceOfReferenceLocality => 10;
        public static int SizeOfBaseReferenceLocality => 8;
        public static double chanceOfLocality => 0.3;
        
        
         /* processes: */
         public static int[] totalReferencesNum => new int []{10, 15, 4};
         public static int[] diffReferencesNum =>  new int []{3,   5, 2}; 
         
    }
}