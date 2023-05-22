namespace _Scripts.Character
{
    public class Points
    {
        public Points()
        {
            SinPoints = 0;
            VirtuePoints = 0;
        }
        
        public int SinPoints
        {
            get;
            private set;
        }

        public int VirtuePoints
        {
            get;
            private set;
        }

        

        public void AddSinPoint()
        {
            SinPoints++;
        }

        public void AddVirtuePoint()
        {
            VirtuePoints++;
        }
        
        
        public void GetMoralityResults()
        {
            if (SinPoints >= 7)
            {
                    //sin path   
            }
            else if (VirtuePoints >= 7)
            {
                //virtue path
            }
            else
            {
                //neutral
            }
        }
        
        

    }
}
