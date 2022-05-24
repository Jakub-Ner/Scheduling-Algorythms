namespace zad3{

public class Reference
{
    public readonly Process parent;
    public readonly  int value;

        public Reference(Process parent)
        {
            this.parent = parent;
            value = this.parent.getNext();
        }
        
}
}